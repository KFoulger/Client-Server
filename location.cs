using System;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using location;
public class locationClient
{

    static List<string> response = new List<string>();

    static void Main(string[] args)
    {
        if(args.Length > 0)
        {
            runClient(args);
        }
        //(13-16) Runs the client if there are arguments
        else
        {
            try
            {
                ClientInterface Interface = new ClientInterface();
                Interface.ShowDialog();
            }
            catch
            {
                Console.WriteLine("Error reading details");
            }
        }
        //(18-29) Runs the client and UI if there are no arguments
    }
    public static string runClient(string[] args)
    {
        TcpClient client = new TcpClient();

        List<string> arg = new List<string>();
        string address = "whois.net.dcs.hull.ac.uk";
        string consoleOutput = null;
        int port = 43;
        string protocol = "whois";
        //(37-40) Sets up the variables that need to have a preset value
            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "-h":
                            address = args[i + 1];
                            args[i] = null;
                            args[i + 1] = null;
                            break;
                        case "-h1":
                            protocol = args[i];
                            args[i] = null;
                            break;
                        case "-h0":
                            protocol = args[i];
                            args[i] = null;
                            break;
                        case "-h9":
                            protocol = args[i];
                            args[i] = null;
                            break;
                        case "-p":
                            port = int.Parse(args[i + 1]);
                            args[i] = null;
                            args[i + 1] = null;
                            break;
                        default:
                            break;
                    }
                    //(46-72) Loops through the arguments to find the address, port and protocol.
                    if (args[i] != null)
                    {
                        arg.Add(args[i]);
                    }
                    //(74-77) Adds anything that isn't the address, port or protocol to a new list.
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Arguments were not read in properly: ");
                Console.WriteLine(e.ToString());
            }
        try
        {
            client.Connect(address, port);

            client.ReceiveTimeout = 1000;
            client.SendTimeout = 1000;

            StreamWriter sw = new StreamWriter(client.GetStream());
            StreamReader sr = new StreamReader(client.GetStream());
            //(89-95) Connects to a server, sets up a timeout and sets up the reader and writer.

            if (arg.Count == 1 || arg.Count == 2)
            {
                switch (protocol)
                {
                    case "whois":
                        consoleOutput = WhoisMethod(arg, sw, sr, consoleOutput);
                        break;
                    case "-h1":
                        consoleOutput = HTTP11Method(arg, sw, sr, address, port, consoleOutput);
                        break;
                    case "-h0":
                        consoleOutput = HTTP10Method(arg, sw, sr, consoleOutput);
                        break;
                    case "-h9":
                        consoleOutput = HTTP09Method(arg, sw, sr, consoleOutput);
                        break;
                    default:
                        break;
                }
                //(100-116) Checks the protocol and chooses which method to use.
            }
            else
            {
                Console.WriteLine("Please supply at least 1 argument and no more than two");
            }
        }
        catch
        {
            Console.WriteLine("Failed to connect to the server");
        }
        return consoleOutput;
        //Returns a string to be entered into the UI if used
    }

    /// <summary>
    /// Method used to communicate with the server if the whois protocol is chosen.
    /// </summary>
    /// <param name="arg"></param>
    /// <param name="sw"></param>
    /// <param name="sr"></param>
    static string WhoisMethod(List<string> arg, StreamWriter sw, StreamReader sr, string consoleOutput)
    {
        if (arg.Count == 1)
        {
            sw.WriteLine(arg[0]);
            sw.Flush();

            response = ReadResponse(sr);
            if (response[0] == "ERROR: no entries found")
            {
                Console.WriteLine(response[0]);
                consoleOutput += response[0] + "\r\n";
            }
            //(146-150) If no user is found, the error message is printed
            else
            {
                Console.WriteLine(arg[0] + " is " + response[0]);
                consoleOutput += (arg[0] + " is " + response[0] + "\r\n");
            }
        }
        //(140-157) Sends the name to the server and writes the location sent back.
        else if (arg.Count == 2)
        {
            sw.WriteLine(arg[0] + " " + arg[1]);
            sw.Flush();

            response = ReadResponse(sr);
            if (response[0] == "OK")
            {
                Console.WriteLine(arg[0] + " location changed to be " + arg[1]);
                consoleOutput += (arg[0] + " location changed to be " + arg[1] + "\r\n");
            }
            else
            {
                Console.WriteLine("Unable to update " + arg[0]);
                consoleOutput += ("Unable to update " + arg[0] + "\r\n");
            }
        }
        //(159-175) Sends the name and a new location to the server for the name to be updated.
        return consoleOutput;
    }

    /// <summary>
    /// Method used to communicate with the server if the HTTP/0.9 protocol is chosen.
    /// </summary>
    /// <param name="arg"></param>
    /// <param name="sw"></param>
    /// <param name="sr"></param>
    static string HTTP09Method(List<string> arg, StreamWriter sw, StreamReader sr, string consoleOutput)
    {
        if (arg.Count == 1)
        {
            sw.WriteLine("GET /" + arg[0]);
            sw.Flush();

            response = ReadResponse(sr);
            if (response[0].Contains("OK"))
            {
                Console.WriteLine(arg[0] + " is " + response[3]);
                consoleOutput += (arg[0] + " is " + response[3] + "\r\n");
            }
            else if (response[0].Contains("404"))
            {
                Console.WriteLine(response[0]);
                consoleOutput += response[0] + "\r\n";
            }
        }
        //(188-204) Sends the name to the server and writes the location sent back.
        else if (arg.Count == 2)
        {
            sw.WriteLine("PUT /" + arg[0] + "\r\n" + "\r\n" + arg[1]);
            sw.Flush();

            response = ReadResponse(sr);
            if (response[0].Contains("OK"))
            {
                Console.WriteLine(arg[0] + " location changed to be " + arg[1]);
                consoleOutput += (arg[0] + " location changed to be " + arg[1] + "\r\n");
            }
            else
            {
                Console.WriteLine("Unable to update " + arg[0]);
                consoleOutput += ("Unable to update " + arg[0] + "\r\n");
            }
        }
        //(206-222) Sends the name and a new location to the server for the name to be updated.
        return consoleOutput;
    }

    /// <summary>
    /// Method used to communicate with the server if the HTTP/1.0 protocol is chosen.
    /// </summary>
    /// <param name="arg"></param>
    /// <param name="sw"></param>
    /// <param name="sr"></param>
    static string HTTP10Method(List<string> arg, StreamWriter sw, StreamReader sr, string consoleOutput)
    {
        if (arg.Count == 1)
        {
            sw.WriteLine("GET /?" + arg[0] + " HTTP/1.0" + "\r\n");
            sw.Flush();

            response = ReadResponse(sr);
            if (response[0].Contains("OK"))
            {
                Console.WriteLine(arg[0] + " is " + response[3]);
                consoleOutput += (arg[0] + " is " + response[3] + "\r\n");
            }
            else if (response[0].Contains("404"))
            {
                Console.WriteLine(response[0]);
                consoleOutput += (response[0] + "\r\n");
            }
        }
        //(235-251) Sends the name to the server and writes the location sent back.
        else if (arg.Count == 2)
        {
            int length = arg[1].Length;
            sw.Write("POST /" + arg[0] + " HTTP/1.0" + "\r\n" + "Content-Length: " + length + "\r\n" + "\r\n" + arg[1]);
            sw.Flush();

            response = ReadResponse(sr);
            if (response[0].Contains("OK"))
            {
                Console.WriteLine(arg[0] + " location changed to be " + arg[1]);
                consoleOutput += (arg[0] + " location changed to be " + arg[1] + "\r\n");
            }
            else if (response[0].Contains("404"))
            {
                Console.WriteLine("Unable to update " + arg[0]);
                consoleOutput += ("Unable to update " + arg[0] + "\r\n");
            }
        }
        //(253-270) Sends the name and a new location to the server for the name to be updated.
        return consoleOutput;
    }

    /// <summary>
    /// Method used to communicate with the server if the HTTP/1.1 protocol is chosen.
    /// </summary>
    /// <param name="arg"></param>
    /// <param name="sw"></param>
    /// <param name="sr"></param>
    /// <param name="address"></param>
    /// <param name="port"></param>
    static string HTTP11Method(List<string> arg, StreamWriter sw, StreamReader sr, string address, int port, string consoleOutput)
    {
        if (port == 80)
        {
            sw.WriteLine("GET /?name=" + arg[0] + " HTTP/1.1" + "\r\n" + "Host: " + address + "\r\n");
            sw.Flush();
            bool rightLine = false;
            bool loop = true;
            do
            {
                string currentLine = sr.ReadLine();
                if (rightLine == true)
                {
                    Console.WriteLine(currentLine);
                    consoleOutput += currentLine + "\r\n";
                }
                if (currentLine == "<!DOCTYPE html>")
                {
                    Console.WriteLine(arg[0] + " is " + currentLine);
                    consoleOutput += (arg[0] + " is " + currentLine + "\r\n");
                    rightLine = true;
                }
                if (currentLine == "</html>")
                {
                    loop = false;
                }
            } while (loop == true);
        }
        //(285-310) If the port number is 80, prints out the response from the website starting at doctype.
        else if (port == 43)
        {
            if (arg.Count == 1)
            {
                sw.WriteLine("GET /?name=" + arg[0] + " HTTP/1.1" + "\r\n" + "Host: " + address + "\r\n");
                sw.Flush();

                response = ReadResponse(sr);
                if (response[0].Contains("OK"))
                {
                    Console.WriteLine(arg[0] + " is " + response[3]);
                    consoleOutput += (arg[0] + " is " + response[3] + "\r\n");
                }
                else if (response[0].Contains("404"))
                {
                    Console.WriteLine(response[0]);
                    consoleOutput += (response[0] + "\r\n");
                }
            }
            //(312-330) Sends the name to the server and writes the location sent back.
            else if (arg.Count == 2)
            {
                int length = (arg[0].Length + arg[1].Length + 15);
                sw.Write("POST / HTTP/1.1\r\n" + "Host: " + address + "\r\n" + "Content-Length: " + length.ToString() + "\r\n" + "\r\n" + "name=" + arg[0] + "&location=" + arg[1]);
                sw.Flush();

                response = ReadResponse(sr);
                if (response[0].Contains("OK"))
                {
                    Console.WriteLine(arg[0] + " location changed to be " + arg[1]);
                    consoleOutput += (arg[0] + " location changed to be " + arg[1] + "\r\n");
                }
                else
                {
                    Console.WriteLine("Unable to update " + arg[0]);
                    consoleOutput += ("Unable to update " + arg[0] + "\r\n");
                }
            }
            //(332-349) Sends the name and a new location to the server for the name to be updated.
        }
        return consoleOutput;
    }

    /// <summary>
    /// Reads the response from the server line by line and adds it to a list.
    /// </summary>
    /// <param name="sr"></param>
    /// <returns></returns>
    static List<string> ReadResponse(StreamReader sr)
    {
        try
        {
            List<string> response = new List<string>();
            bool loop = true;
            do
            {
                string currentLine = sr.ReadLine();
                if (currentLine != null)
                {
                    response.Add(currentLine);
                }
                else
                {
                    loop = false;
                }
            } while (loop == true);
            return response;
        }
        catch
        {
            Console.WriteLine("Error while reading response");
            return null;
        }
        //(366-379) Loops through all lines sent by the server and writes them into a list.
    }
}
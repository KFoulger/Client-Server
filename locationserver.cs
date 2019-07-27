using System;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using locationserver;

namespace locationserver
{
    class Server
    {
        static Dictionary<string, string> dict = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            int port = 43;
            int timeout = 1000;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-w")
                {
                    serverInterface Interface = new serverInterface();
                    Interface.ShowDialog();
                }
                else if (args[i] == "-t")
                {
                    timeout = int.Parse(args[i + 1]);
                }
                else if (args[i] == "-p")
                {
                    port = int.Parse(args[i + 1]);
                }
            }
            //(18-33) Checks if the arguments have the interface call, timeout setter or port setter and runs the server
            RunServer(port, timeout);
        }

        public static void RunServer(int port, int timeout)
        {
            try
            {
                TcpListener listener;
                Socket connection;
                Handler requestHandler;

                listener = new TcpListener(IPAddress.Any, port);

                listener.Start();
                listener.Server.ReceiveTimeout = timeout;
                listener.Server.SendTimeout = timeout;
                Console.WriteLine("Server started listening");
                while (true)
                {
                    connection = listener.AcceptSocket();
                    requestHandler = new Handler();
                    Thread t = new Thread(() => requestHandler.DoRequest(connection));
                    t.Start();
                }
                //(52-58) Sets up threads and goes through the protocol methods
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        class Handler
        {
            public void DoRequest(Socket connection)
            {
                NetworkStream socketStream= new NetworkStream(connection);
                try
                {
                    Console.WriteLine("Connection Received");
                    StreamWriter sw = new StreamWriter(socketStream);
                    StreamReader sr = new StreamReader(socketStream);

                    string line = sr.ReadLine(); //Reads the first line for it to be checked later
                    if (line.EndsWith(" HTTP/1.0"))
                    {
                        HTTP1Method(sr, sw, line, dict);
                    }
                    else if (line.EndsWith(" HTTP/1.1"))
                    {
                        HTTP11Method(sr, sw, line, dict);
                    }
                    else if (line.StartsWith("GET /") || line.StartsWith("PUT /"))
                    {
                        HTTP09Method(sr, sw, line, dict);
                    }
                    else
                    {
                        WhoisMethod(sw, line);
                    }
                    //(74-94) Choose which method to go through based on the first line inputted by the client
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    socketStream.Close();
                    connection.Close();
                }
                //(101-105) Closes the current thread of the server
            }
        }
        /// <summary>
        /// Method used to read whois protocol messages
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="line"></param>
        private static void WhoisMethod(StreamWriter sw, string line)
        {
            try
            {
                Console.WriteLine("Connected via whois protocol");

                string[] clientData = line.Split(new char[] { ' ' }, 2);
                if (clientData.Length == 1)
                {
                    Console.WriteLine("Obtaining location");
                    if (dict.ContainsKey(clientData[0]) != true)
                    {
                        sw.WriteLine("ERROR: no entries found\r\n");
                        sw.Flush();
                        Console.WriteLine("No user found, response sent");
                    }
                    if (dict.ContainsKey(clientData[0]) == true)
                    {
                        sw.WriteLine(dict[clientData[0]]);
                        sw.Flush();
                        Console.WriteLine("User found, response sent");
                    }
                }
                //(120-136) Sends the location of the user to the client if it can be found
                else if (clientData.Length == 2)
                {
                    Console.WriteLine("Changing location");
                    EditDict(clientData[0], clientData[1]);
                    sw.WriteLine("OK");
                    sw.Flush();
                    Console.WriteLine("Location updated, response sent");
                }
                //(138-145) Updates the dictionary with the new location and notifies the client of the update
            }
            catch (Exception e)
            {
                Console.WriteLine("Error at whois: " + e.ToString());
            }
        }
        /// <summary>
        /// Method used to read HTTP/0.9 messages
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="sw"></param>
        /// <param name="line"></param>
        /// <param name="dict"></param>
        static void HTTP09Method(StreamReader sr, StreamWriter sw, string line, Dictionary<string, string> dict)
        {
            Console.WriteLine("Connected via HTTP/0.9 protocol");

            if (line.StartsWith("GET /"))
            {
                try
                {
                    Console.WriteLine("Obtaining location");

                    string name = line.Remove(0, 5);
                    if (dict.ContainsKey(name) == true)
                    {
                        sw.WriteLine("HTTP/0.9 200 OK\r\nContent-Type: text/plain\r\n\r\n" + dict[name]);
                        sw.Flush();

                        Console.WriteLine("User found, response sent");
                    }
                    else if (dict.ContainsKey(name) == false)
                    {
                        sw.WriteLine("HTTP/0.9 404 Not Found\r\nContent-Type: text/plain\r\n");
                        sw.Flush();

                        Console.WriteLine("No user found, response sent");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error returning user information (HTTP/0.9): " + e.ToString());
                }
            }
            //(164-190) If the first line starts with GET /, the server checks for the user and returns a location if found
            else if (line.Contains("PUT /"))
            {
                try
                {
                    Console.WriteLine("Changing location");

                    string name = line.Remove(0, 5);
                    sr.ReadLine();
                    string location = sr.ReadLine();
                    EditDict(name, location);
                    sw.WriteLine("HTTP/0.9 200 OK\r\nContent-Type: text/plain\r\n");
                    sw.Flush();

                    Console.WriteLine("Location updated, response sent");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error updating user (HTTP/0.9): " + e.ToString());
                }
            }
            //(192-211) If the first line contains PUT /, the server updates the user's location and notifies the client
        }
        /// <summary>
        /// Method used to read HTTP/1.0 messages
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="sw"></param>
        /// <param name="line"></param>
        /// <param name="dict"></param>
        static void HTTP1Method(StreamReader sr, StreamWriter sw, string line, Dictionary<string, string> dict)
        {
            Console.WriteLine("Connected via HTTP/1.0 protocol");

            if (line.StartsWith("GET /?"))
            {
                Console.WriteLine("Obtaining location");

                string nameLine = line.Remove(0, 6);
                string[] name = nameLine.Split(' ');
                sr.ReadLine();
                if (dict.ContainsKey(name[0]) == true)
                {
                    sw.WriteLine("HTTP/1.0 200 OK\r\nContent-Type: text/plain\r\n\r\n" + dict[name[0]]);
                    sw.Flush();

                    Console.WriteLine("User found, response sent");
                }
                else if (dict.ContainsKey(name[0]) == false)
                {
                    sw.WriteLine("HTTP/1.0 404 Not Found\r\nContent-Type: text/plain");
                    sw.Flush();

                    Console.WriteLine("No user found, response sent");
                }
            }
            //(225-246) If the first line starts with GET /?, the server looks for the user's location
            else if (line.StartsWith("POST /"))
            {
                Console.WriteLine("Changing location");

                string nameLine = line.Remove(0, 6); //Removes the first six lines to get just the name
                string[] name = nameLine.Split(' ');
                int length = int.Parse(sr.ReadLine().Remove(0, 16)); //Gets the amount of characters for the last line
                sr.ReadLine();
                char[] infoLine = new char[length];
                int arrayFiller = sr.Read(infoLine, 0, length); //Reads the amount of characters specified by the client message
                string location = "";
                for (int i = 0; i < length; i++)
                {
                    string currentChar = infoLine[i].ToString();
                    location = location.Insert(i, currentChar);
                }
                //(259-263) Inserts the characters of the last line array into one string
                EditDict(name[0], location);
                sw.WriteLine("HTTP/1.0 200 OK\r\nContent-Type: text/plain\r\n");
                sw.Flush();

                Console.WriteLine("Location updated, response sent");
            }
            //(248-270) If the first line starts with POST /, the server updates the user's location
        }
        /// <summary>
        /// Method used to read HTTP/1.1 messages
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="sw"></param>
        /// <param name="line"></param>
        /// <param name="dict"></param>
        static void HTTP11Method(StreamReader sr, StreamWriter sw, string line, Dictionary<string, string> dict)
        {
            Console.WriteLine("Connected via HTTP/1.1 protocol");

            if (line.StartsWith("GET /?"))
            {
                Console.WriteLine("Obtaining location");

                string nameLine = line.Remove(0, 11);
                string[] name = nameLine.Split(' ');
                if (dict.ContainsKey(name[0]) == true)
                {
                    sw.WriteLine("HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\n" + dict[name[0]]);
                    sw.Flush();

                    Console.WriteLine("User found, response sent");
                }
                else if (dict.ContainsKey(name[0]) == false)
                {
                    sw.WriteLine("HTTP/1.1 404 Not Found\r\nContent-Type: text/plain\r\n");
                    sw.Flush();

                    Console.WriteLine("No user found, response sent");
                }
            }
            //(284-304) if the first line starts with GET /?, server find the user's location 
            else if (line.StartsWith("POST /"))
            {
                Console.WriteLine("Changing location");

                sr.ReadLine();
                int length = int.Parse(sr.ReadLine().Remove(0, 16));//Removes the first sixteen lines to get just the length of the last line
                sr.ReadLine();
                char[] infoLine = new char[length];
                int arrayFiller = sr.Read(infoLine, 0, length);
                string userInfoLine = "";
                for (int i = 0; i < length; i++)
                {
                    string currentChar = infoLine[i].ToString();
                    userInfoLine = userInfoLine.Insert(i, currentChar);
                }
                //(316-320) Inserts characters from the last line array into one string
                string[] userInfo = userInfoLine.Split('&');
                userInfo[0] = userInfo[0].Remove(0, 5);
                userInfo[1] = userInfo[1].Remove(0, 9);
                //(322-324) Splits at the '&' to get the name and location separately. Then trims the "name=" and "location=" off them
                EditDict(userInfo[0], userInfo[1]);
                sw.WriteLine("HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n");
                sw.Flush();

                Console.WriteLine("Location updated, response sent");
            }
            //(306-331) If the first line starts with POST /, the server updates the user's location
    }
        /// <summary>
        /// Makes changes to the dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        static void EditDict(string key, string value)
        {
            if (dict.ContainsKey(key) != true)
            {
                dict.Add(key, value);
            }
            //(341-344) If there is no corresponding key in the dictionary it adds one
            else if (dict.ContainsKey(key) == true)
            {
                dict[key] = value;
            }
            //(346-349) If there is a corresponding key in the dictionary ith
        }
    }
}
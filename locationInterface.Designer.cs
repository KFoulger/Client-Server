namespace location
{
    partial class ClientInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.locationBox = new System.Windows.Forms.TextBox();
            this.IPBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.whoisRadio = new System.Windows.Forms.RadioButton();
            this.http09Radio = new System.Windows.Forms.RadioButton();
            this.http10Radio = new System.Windows.Forms.RadioButton();
            this.http11Radio = new System.Windows.Forms.RadioButton();
            this.runClient = new System.Windows.Forms.Button();
            this.closeWindow = new System.Windows.Forms.Button();
            this.clearResponse = new System.Windows.Forms.Button();
            this.infoName = new System.Windows.Forms.Button();
            this.infoProtocol = new System.Windows.Forms.Button();
            this.infoPort = new System.Windows.Forms.Button();
            this.infoIP = new System.Windows.Forms.Button();
            this.infoLocation = new System.Windows.Forms.Button();
            this.responseBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Response";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // nameBox
            // 
            this.nameBox.BackColor = System.Drawing.SystemColors.Info;
            this.nameBox.Location = new System.Drawing.Point(15, 301);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(276, 20);
            this.nameBox.TabIndex = 5;
            // 
            // locationBox
            // 
            this.locationBox.BackColor = System.Drawing.SystemColors.Info;
            this.locationBox.Location = new System.Drawing.Point(15, 349);
            this.locationBox.Name = "locationBox";
            this.locationBox.Size = new System.Drawing.Size(276, 20);
            this.locationBox.TabIndex = 6;
            // 
            // IPBox
            // 
            this.IPBox.BackColor = System.Drawing.SystemColors.Info;
            this.IPBox.Location = new System.Drawing.Point(15, 397);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(276, 20);
            this.IPBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "IP Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Port Number";
            // 
            // portBox
            // 
            this.portBox.BackColor = System.Drawing.SystemColors.Info;
            this.portBox.Location = new System.Drawing.Point(15, 445);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(276, 20);
            this.portBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(379, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Protocol";
            // 
            // whoisRadio
            // 
            this.whoisRadio.AutoSize = true;
            this.whoisRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whoisRadio.Location = new System.Drawing.Point(391, 323);
            this.whoisRadio.Name = "whoisRadio";
            this.whoisRadio.Size = new System.Drawing.Size(81, 28);
            this.whoisRadio.TabIndex = 14;
            this.whoisRadio.TabStop = true;
            this.whoisRadio.Text = "Whois";
            this.whoisRadio.UseVisualStyleBackColor = true;
            this.whoisRadio.CheckedChanged += new System.EventHandler(this.whoisRadio_CheckedChanged);
            // 
            // http09Radio
            // 
            this.http09Radio.AutoSize = true;
            this.http09Radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.http09Radio.Location = new System.Drawing.Point(391, 357);
            this.http09Radio.Name = "http09Radio";
            this.http09Radio.Size = new System.Drawing.Size(108, 28);
            this.http09Radio.TabIndex = 17;
            this.http09Radio.TabStop = true;
            this.http09Radio.Text = "HTTP/0.9";
            this.http09Radio.UseVisualStyleBackColor = true;
            this.http09Radio.CheckedChanged += new System.EventHandler(this.http09Radio_CheckedChanged);
            // 
            // http10Radio
            // 
            this.http10Radio.AutoSize = true;
            this.http10Radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.http10Radio.Location = new System.Drawing.Point(391, 391);
            this.http10Radio.Name = "http10Radio";
            this.http10Radio.Size = new System.Drawing.Size(108, 28);
            this.http10Radio.TabIndex = 18;
            this.http10Radio.TabStop = true;
            this.http10Radio.Text = "HTTP/1.0";
            this.http10Radio.UseVisualStyleBackColor = true;
            this.http10Radio.CheckedChanged += new System.EventHandler(this.http10Radio_CheckedChanged);
            // 
            // http11Radio
            // 
            this.http11Radio.AutoSize = true;
            this.http11Radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.http11Radio.Location = new System.Drawing.Point(391, 425);
            this.http11Radio.Name = "http11Radio";
            this.http11Radio.Size = new System.Drawing.Size(108, 28);
            this.http11Radio.TabIndex = 19;
            this.http11Radio.TabStop = true;
            this.http11Radio.Text = "HTTP/1.1";
            this.http11Radio.UseVisualStyleBackColor = true;
            this.http11Radio.CheckedChanged += new System.EventHandler(this.http11Radio_CheckedChanged);
            // 
            // runClient
            // 
            this.runClient.BackColor = System.Drawing.SystemColors.Control;
            this.runClient.Location = new System.Drawing.Point(539, 301);
            this.runClient.Name = "runClient";
            this.runClient.Size = new System.Drawing.Size(75, 164);
            this.runClient.TabIndex = 20;
            this.runClient.Text = "Run Client";
            this.runClient.UseVisualStyleBackColor = false;
            this.runClient.Click += new System.EventHandler(this.runClient_Click);
            // 
            // closeWindow
            // 
            this.closeWindow.BackColor = System.Drawing.SystemColors.Control;
            this.closeWindow.Location = new System.Drawing.Point(539, 488);
            this.closeWindow.Name = "closeWindow";
            this.closeWindow.Size = new System.Drawing.Size(97, 23);
            this.closeWindow.TabIndex = 22;
            this.closeWindow.Text = "Close Window";
            this.closeWindow.UseVisualStyleBackColor = false;
            this.closeWindow.Click += new System.EventHandler(this.closeWindow_Click);
            // 
            // clearResponse
            // 
            this.clearResponse.BackColor = System.Drawing.SystemColors.Control;
            this.clearResponse.Location = new System.Drawing.Point(504, 259);
            this.clearResponse.Name = "clearResponse";
            this.clearResponse.Size = new System.Drawing.Size(132, 23);
            this.clearResponse.TabIndex = 23;
            this.clearResponse.Text = "Clear server response";
            this.clearResponse.UseVisualStyleBackColor = false;
            this.clearResponse.Click += new System.EventHandler(this.clearResponse_Click);
            // 
            // infoName
            // 
            this.infoName.BackColor = System.Drawing.SystemColors.Control;
            this.infoName.Font = new System.Drawing.Font("Mathcad UniMath", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoName.Location = new System.Drawing.Point(307, 301);
            this.infoName.Name = "infoName";
            this.infoName.Size = new System.Drawing.Size(21, 21);
            this.infoName.TabIndex = 24;
            this.infoName.Text = "i";
            this.infoName.UseVisualStyleBackColor = false;
            this.infoName.Click += new System.EventHandler(this.infoName_Click);
            // 
            // infoProtocol
            // 
            this.infoProtocol.BackColor = System.Drawing.SystemColors.Control;
            this.infoProtocol.Font = new System.Drawing.Font("Mathcad UniMath", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoProtocol.Location = new System.Drawing.Point(504, 298);
            this.infoProtocol.Name = "infoProtocol";
            this.infoProtocol.Size = new System.Drawing.Size(21, 21);
            this.infoProtocol.TabIndex = 25;
            this.infoProtocol.Text = "i";
            this.infoProtocol.UseVisualStyleBackColor = false;
            this.infoProtocol.Click += new System.EventHandler(this.infoProtocol_Click);
            // 
            // infoPort
            // 
            this.infoPort.BackColor = System.Drawing.SystemColors.Control;
            this.infoPort.Font = new System.Drawing.Font("Mathcad UniMath", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoPort.Location = new System.Drawing.Point(307, 444);
            this.infoPort.Name = "infoPort";
            this.infoPort.Size = new System.Drawing.Size(21, 21);
            this.infoPort.TabIndex = 26;
            this.infoPort.Text = "i";
            this.infoPort.UseVisualStyleBackColor = false;
            this.infoPort.Click += new System.EventHandler(this.infoPort_Click);
            // 
            // infoIP
            // 
            this.infoIP.BackColor = System.Drawing.SystemColors.Control;
            this.infoIP.Font = new System.Drawing.Font("Mathcad UniMath", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoIP.Location = new System.Drawing.Point(307, 396);
            this.infoIP.Name = "infoIP";
            this.infoIP.Size = new System.Drawing.Size(21, 21);
            this.infoIP.TabIndex = 27;
            this.infoIP.Text = "i";
            this.infoIP.UseVisualStyleBackColor = false;
            this.infoIP.Click += new System.EventHandler(this.infoIP_Click);
            // 
            // infoLocation
            // 
            this.infoLocation.BackColor = System.Drawing.SystemColors.Control;
            this.infoLocation.Font = new System.Drawing.Font("Mathcad UniMath", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLocation.Location = new System.Drawing.Point(307, 348);
            this.infoLocation.Name = "infoLocation";
            this.infoLocation.Size = new System.Drawing.Size(21, 21);
            this.infoLocation.TabIndex = 28;
            this.infoLocation.Text = "i";
            this.infoLocation.UseVisualStyleBackColor = false;
            this.infoLocation.Click += new System.EventHandler(this.infoLocation_Click);
            // 
            // responseBox
            // 
            this.responseBox.Location = new System.Drawing.Point(13, 26);
            this.responseBox.Name = "responseBox";
            this.responseBox.ReadOnly = true;
            this.responseBox.Size = new System.Drawing.Size(623, 227);
            this.responseBox.TabIndex = 29;
            this.responseBox.Text = "";
            // 
            // ClientInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(648, 514);
            this.Controls.Add(this.responseBox);
            this.Controls.Add(this.infoLocation);
            this.Controls.Add(this.infoIP);
            this.Controls.Add(this.infoPort);
            this.Controls.Add(this.infoProtocol);
            this.Controls.Add(this.infoName);
            this.Controls.Add(this.clearResponse);
            this.Controls.Add(this.closeWindow);
            this.Controls.Add(this.runClient);
            this.Controls.Add(this.http11Radio);
            this.Controls.Add(this.http10Radio);
            this.Controls.Add(this.http09Radio);
            this.Controls.Add(this.whoisRadio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IPBox);
            this.Controls.Add(this.locationBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "ClientInterface";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Client Interface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox locationBox;
        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton whoisRadio;
        private System.Windows.Forms.RadioButton http09Radio;
        private System.Windows.Forms.RadioButton http10Radio;
        private System.Windows.Forms.RadioButton http11Radio;
        private System.Windows.Forms.Button runClient;
        private System.Windows.Forms.Button closeWindow;
        private System.Windows.Forms.Button clearResponse;
        private System.Windows.Forms.Button infoName;
        private System.Windows.Forms.Button infoProtocol;
        private System.Windows.Forms.Button infoPort;
        private System.Windows.Forms.Button infoIP;
        private System.Windows.Forms.Button infoLocation;
        private System.Windows.Forms.RichTextBox responseBox;
    }
}
namespace locationserver
{
    partial class serverInterface
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
            this.label4 = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.timeoutBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.infoPort = new System.Windows.Forms.Button();
            this.infoTimeout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Port Number";
            // 
            // portBox
            // 
            this.portBox.BackColor = System.Drawing.SystemColors.Info;
            this.portBox.Location = new System.Drawing.Point(12, 25);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(175, 20);
            this.portBox.TabIndex = 10;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.SystemColors.Control;
            this.closeButton.Location = new System.Drawing.Point(221, 112);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(91, 23);
            this.closeButton.TabIndex = 17;
            this.closeButton.Text = "Close Window";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.SystemColors.Control;
            this.runButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.runButton.Location = new System.Drawing.Point(237, 25);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 81);
            this.runButton.TabIndex = 18;
            this.runButton.Text = "Run Server";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // timeoutBox
            // 
            this.timeoutBox.BackColor = System.Drawing.SystemColors.Info;
            this.timeoutBox.Location = new System.Drawing.Point(12, 86);
            this.timeoutBox.Name = "timeoutBox";
            this.timeoutBox.Size = new System.Drawing.Size(175, 20);
            this.timeoutBox.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Timeout";
            // 
            // infoPort
            // 
            this.infoPort.BackColor = System.Drawing.SystemColors.Control;
            this.infoPort.Font = new System.Drawing.Font("Mathcad UniMath", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoPort.Location = new System.Drawing.Point(193, 25);
            this.infoPort.Name = "infoPort";
            this.infoPort.Size = new System.Drawing.Size(21, 21);
            this.infoPort.TabIndex = 25;
            this.infoPort.Text = "i";
            this.infoPort.UseVisualStyleBackColor = false;
            this.infoPort.Click += new System.EventHandler(this.infoPort_Click);
            // 
            // infoTimeout
            // 
            this.infoTimeout.BackColor = System.Drawing.SystemColors.Control;
            this.infoTimeout.Font = new System.Drawing.Font("Mathcad UniMath", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoTimeout.Location = new System.Drawing.Point(193, 85);
            this.infoTimeout.Name = "infoTimeout";
            this.infoTimeout.Size = new System.Drawing.Size(21, 21);
            this.infoTimeout.TabIndex = 26;
            this.infoTimeout.Text = "i";
            this.infoTimeout.UseVisualStyleBackColor = false;
            this.infoTimeout.Click += new System.EventHandler(this.infoTimeout_Click);
            // 
            // serverInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(320, 139);
            this.Controls.Add(this.infoTimeout);
            this.Controls.Add(this.infoPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeoutBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.label4);
            this.Name = "serverInterface";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Location server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TextBox timeoutBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button infoPort;
        private System.Windows.Forms.Button infoTimeout;
    }
}
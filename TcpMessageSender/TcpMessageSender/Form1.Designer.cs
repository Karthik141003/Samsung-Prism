using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace TcpMessageSender
{
    public partial class Form1 : Form
    {
        

        private void InitializeComponent()
        {
            this.sendButton = new System.Windows.Forms.Button();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.responseLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sendButton.FlatAppearance.BorderSize = 0;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sendButton.ForeColor = System.Drawing.Color.White;
            this.sendButton.Location = new System.Drawing.Point(60, 180);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(150, 40);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "Send Message";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // ipTextBox
            // 
            this.ipTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ipTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ipTextBox.Location = new System.Drawing.Point(60, 40);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(200, 25);
            this.ipTextBox.TabIndex = 1;
            this.ipTextBox.Text = "Enter IP Address";
            this.ipTextBox.Enter += new System.EventHandler(this.ipTextBox_Enter);
            this.ipTextBox.Leave += new System.EventHandler(this.ipTextBox_Leave);
            // 
            // portTextBox
            // 
            this.portTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.portTextBox.ForeColor = System.Drawing.Color.Gray;
            this.portTextBox.Location = new System.Drawing.Point(60, 100);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(200, 25);
            this.portTextBox.TabIndex = 2;
            this.portTextBox.Text = "Enter Port Number";
            this.portTextBox.Enter += new System.EventHandler(this.portTextBox_Enter);
            this.portTextBox.Leave += new System.EventHandler(this.portTextBox_Leave);
            // 
            // responseLabel
            // 
            this.responseLabel.AutoSize = true;
            this.responseLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.responseLabel.ForeColor = System.Drawing.Color.DimGray;
            this.responseLabel.Location = new System.Drawing.Point(60, 150);
            this.responseLabel.Name = "responseLabel";
            this.responseLabel.Size = new System.Drawing.Size(129, 19);
            this.responseLabel.TabIndex = 3;
            this.responseLabel.Text = "Response: Waiting...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 250);
            this.Controls.Add(this.responseLabel);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.sendButton);
            this.Name = "Form1";
            this.Text = "TCP Message Sender";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ipTextBox_Enter(object sender, EventArgs e)
        {
            if (ipTextBox.Text == "Enter IP Address")
            {
                ipTextBox.Text = "";
                ipTextBox.ForeColor = Color.Black;
            }
        }

        private void ipTextBox_Leave(object sender, EventArgs e)
        {
            if (ipTextBox.Text == "")
            {
                ipTextBox.Text = "Enter IP Address";
                ipTextBox.ForeColor = Color.Gray;
            }
        }

        private void portTextBox_Enter(object sender, EventArgs e)
        {
            if (portTextBox.Text == "Enter Port Number")
            {
                portTextBox.Text = "";
                portTextBox.ForeColor = Color.Black;
            }
        }

        private void portTextBox_Leave(object sender, EventArgs e)
        {
            if (portTextBox.Text == "")
            {
                portTextBox.Text = "Enter Port Number";
                portTextBox.ForeColor = Color.Gray;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string ipAddress = ipTextBox.Text;
            int port = int.Parse(portTextBox.Text);
            string message = "Hello from PC!";

            try
            {
                // Connect to the TCP server (Android device)
                using (TcpClient client = new TcpClient(ipAddress, port))
                {
                    NetworkStream stream = client.GetStream();

                    // Send message to the server (Android device)
                    byte[] data = Encoding.ASCII.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    // Receive response from the server
                    byte[] responseData = new byte[1024];
                    int bytesRead = stream.Read(responseData, 0, responseData.Length);
                    string response = Encoding.ASCII.GetString(responseData, 0, bytesRead);

                    // Update response label
                    responseLabel.Text = "Response: " + response;
                }
            }
            catch (Exception ex)
            {
                responseLabel.Text = "Error: " + ex.Message;
            }
        }

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label responseLabel;
    }
}

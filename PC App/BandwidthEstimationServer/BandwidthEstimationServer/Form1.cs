using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BandwidthEstimationServer
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener;
        private TcpClient tcpClient;
        private Thread listenThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtStatus.Text = "Server ready to start...";
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            listenThread = new Thread(new ThreadStart(StartListening));
            listenThread.Start();
            txtStatus.AppendText("Server started...\n");
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            tcpListener.Stop();
            listenThread.Abort();
            txtStatus.AppendText("Server stopped...\n");
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                NetworkStream clientStream = tcpClient.GetStream();
                byte[] buffer = Encoding.ASCII.GetBytes(txtMessage.Text);
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
                txtStatus.AppendText("Message sent: " + txtMessage.Text + "\n");
            }
            else
            {
                txtStatus.AppendText("No client connected.\n");
            }
        }

        private void StartListening()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 5000);
                tcpListener.Start();

                while (true)
                {
                    tcpClient = tcpListener.AcceptTcpClient();
                    txtStatus.Invoke(new Action(() => txtStatus.AppendText("Client connected...\n")));
                }
            }
            catch (SocketException ex)
            {
                txtStatus.Invoke(new Action(() => txtStatus.AppendText("SocketException: " + ex.Message + "\n")));
            }
            catch (Exception ex)
            {
                txtStatus.Invoke(new Action(() => txtStatus.AppendText("Exception: " + ex.Message + "\n")));
            }
        }
    }
}

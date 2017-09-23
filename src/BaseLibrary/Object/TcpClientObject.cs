using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BaseLibrary.Object
{
    public class TcpClientObject : LogEventObject
    {
        private TcpClient client;


        public void Connect(string addr, int port)
        {
            if (client == null)
            {
                client = new TcpClient();
                client.Connect(IPAddress.Parse(addr).ToString(), port);
                OnLogEvent(string.Format("{0}:{1} Connected!", addr, port));
            }
        }


        public void Disconnect()
        {
            if (client != null)
            {
                client.Close();
                client = null;
                OnLogEvent(string.Format("{0} Disconnected!", client.Client.RemoteEndPoint));
            }
        }

        public void Send(string data)
        {
            if (client != null)
            {
                if (client.Connected)
                {
                    var s = client.GetStream();
                    s.Write(Encoding.ASCII.GetBytes(data), 0, data.Length);
                }
            }
        }


        public string Recv()
        {
            if (client != null)
            {
                if (client.Available > 0)
                {
                    var s = client.GetStream();

                    var buffer = new byte[client.Available];
                    s.Read(buffer, 0, buffer.Length);

                    return Encoding.ASCII.GetString(buffer);
                }
            }

            return null;
        }
    }
}
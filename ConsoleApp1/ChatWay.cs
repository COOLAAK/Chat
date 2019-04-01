using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ChatWay
    {

        static void MsgReceive()
        {
            try
            {


                byte[] buffer = new byte[1024];

                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ip = ipHostInfo.AddressList[1];
                foreach (var item in ipHostInfo.AddressList)
                {
                    Console.WriteLine($"Ip addr - {item}");
                }
                var serverIp = new IPAddress(new byte[] { 10, 7, 180, 104 });
                // IPEndPoint remotePort = new IPEndPoint(ip, 11001);
                IPEndPoint remotePort = new IPEndPoint(serverIp, 11000);

                Socket socket = new Socket(serverIp.AddressFamily, SocketType.Stream, ProtocolType.Tcp);


                try
                {
                    socket.Connect(remotePort);
                    Console.WriteLine($"Connected to {socket.RemoteEndPoint}");

                    byte[] msg = Encoding.ASCII.GetBytes("Budka Dlia Diatla!!! EOT");
                    int sendBytes = socket.Send(msg);
                    int receivedBytess = socket.Receive(buffer);
                    Console.WriteLine($"Received: {Encoding.ASCII.GetString(buffer, 0, receivedBytess)}");

                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


    }
}

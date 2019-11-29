using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpModtager
{
    class Program
    {
        static void Main(string[] args)
        {

            UdpClient udpClient = new UdpClient(5005);

            IPEndPoint remoteIpEnd = new IPEndPoint(IPAddress.Any, 0); //

            try
            {
                Console.WriteLine("Trying to receive client data");


                while (true)
                {
                    byte[] receiveBytes = udpClient.Receive(ref remoteIpEnd);
                    string receivedData = Encoding.UTF8.GetString(receiveBytes);
                    //Object object = Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(receiveBytes);
                    Console.WriteLine(receivedData);
                    Console.WriteLine("Data received on port: " + remoteIpEnd.Port);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }





            UdpClient cli = new UdpClient(5005);
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] bytes = cli.Receive(ref ep);
                Console.WriteLine(Encoding.UTF8.GetString(bytes));
            }
                      
        }
    }
}
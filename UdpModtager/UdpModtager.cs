using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using HotelLibrary;
using RestTempProvider.Controllers;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace UdpModtager
{
    class UdpModtager
    {
        static void Main(string[] args)
        {

            //TempSensorController tsController = new TempSensorController();

            Consumer restConsumer = new Consumer("/HotelTemps");

            Temperaturmaaling tMaaling;

            TemperaturData data;

            UdpClient udpClient = new UdpClient(5005);

            IPEndPoint remoteIpEnd = new IPEndPoint(IPAddress.Any, 0); //

            try
            {
                Console.WriteLine("Trying to receive client data");

                List<Temperaturmaaling> maalinger;
                List<Temperaturmaaling> sletMaalinger=new List<Temperaturmaaling>();

                while (true)
                {
                    byte[] receiveBytes = udpClient.Receive(ref remoteIpEnd);
                    string receivedData = Encoding.UTF8.GetString(receiveBytes);
                    data = Newtonsoft.Json.JsonConvert.DeserializeObject<TemperaturData>(receivedData);
                    tMaaling = new Temperaturmaaling(data.HotelID, DateTime.Now, data.Temperature);
                    //Object object = Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(receiveBytes);
                    restConsumer.Post(tMaaling);
                    maalinger = restConsumer.GetAll();
                    sletMaalinger.Clear();
                    foreach (Temperaturmaaling m in maalinger)
                    {
                        TimeSpan tt = DateTime.Now - m.DatoTid;
                        if(tt.Days>=60)
                        {
                            sletMaalinger.Add(m);
                        }
                    }
                    foreach (Temperaturmaaling m in sletMaalinger)
                    {
                        restConsumer.Delete(m.DatoTid);
                    }
                    //tsController.Post(tMaaling);
                    Console.WriteLine(receivedData);
                    Console.WriteLine(tMaaling);
                    Console.WriteLine("Data received on port: " + remoteIpEnd.Port);
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }




            /*
            UdpClient cli = new UdpClient(5005);
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] bytes = cli.Receive(ref ep);
                Console.WriteLine(Encoding.UTF8.GetString(bytes));
            }
            */          
        }
    }
}
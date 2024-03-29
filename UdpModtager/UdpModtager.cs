﻿using System;
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

            Consumer restConsumer = new Consumer("hoteltemps");

            TemperaturData tMaaling;

            TemperaturData data;

            UdpClient udpClient = new UdpClient(5005);

            IPEndPoint remoteIpEnd = new IPEndPoint(IPAddress.Any, 0); //

            try
            {
                Console.WriteLine("Trying to receive client data");

                while (true)
                {
                    byte[] receiveBytes = udpClient.Receive(ref remoteIpEnd);
                    string receivedData = Encoding.UTF8.GetString(receiveBytes);
                    data = Newtonsoft.Json.JsonConvert.DeserializeObject<TemperaturData>(receivedData);
                    restConsumer.Post(data);
                    Console.WriteLine(receivedData);
                    Console.WriteLine(data);
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
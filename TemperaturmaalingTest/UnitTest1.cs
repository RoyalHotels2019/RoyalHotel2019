using HotelLibrary;
using RestTempProvider.DBUtil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UdpModtager;

namespace TemperaturmaalingTest
{
    [TestClass]
    public class UnitTest1
    {
        Temperaturmaaling testClass = new Temperaturmaaling();
        TempSensorManager manager = new TempSensorManager();
            DateTime date = DateTime.Now;
        Consumer consumer= new Consumer("hoteltemps");
        

        [TestMethod]
        public void TestPost1()
        {
            Assert.AreEqual(manager.Post(new TemperaturData(0, 26.0)), true);
        }
        [TestMethod]
        public void TestPost2()
        {
            Assert.AreEqual(consumer.Post(new TemperaturData(0, 26.0)), true);
        }


        [TestMethod]
        public void TestMethod1()
        {
            testClass=new Temperaturmaaling(0, date, 20.1);
            Assert.AreEqual(testClass.DatoTid, date);
            Assert.AreEqual(testClass.HotelID, 0);
            Assert.AreEqual(testClass.Temperature, 20.1);
        }
        [TestMethod]
        public void TestMethod3()
        {
            testClass.HotelID = 2;
            Assert.AreEqual(testClass.HotelID, 2);
        }


        [TestMethod]
        public void TestMethod4()
        {
            testClass.Temperature = 2;
            Assert.AreEqual(testClass.Temperature, 2);
        }
    }
}

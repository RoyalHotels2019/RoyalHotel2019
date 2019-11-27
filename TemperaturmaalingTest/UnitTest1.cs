using HotelLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemperaturmaalingTest
{
    [TestClass]
    public class UnitTest1
    {
        Temperaturmaaling testClass = new Temperaturmaaling();
            DateTimeOffset date = DateTimeOffset.Now;
        

        [TestMethod]
        public void TestMethod1()
        {
            testClass=new Temperaturmaaling(0, date, 20.1);
            Assert.AreEqual(testClass.DatoTid, date);
            Assert.AreEqual(testClass.HotelID, 0);
            Assert.AreEqual(testClass.Temperature, 20.1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(false, testClass.CheckTempLength(20.1234556));
            Assert.AreEqual(true, testClass.CheckTempLength(20.1));
            Assert.AreEqual(true, testClass.CheckTempLength(20));
            Assert.AreEqual(false, testClass.CheckTempLength(20.12));
            Assert.AreEqual(true, testClass.CheckTempLength(20.10));
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

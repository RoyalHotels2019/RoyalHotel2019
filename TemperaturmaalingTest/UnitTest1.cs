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
        

        [TestMethod]
        public void TestMethod1()
        {
            DateTimeOffset date = DateTimeOffset.Now;
            testClass=new Temperaturmaaling(0, date, 20.12);
        }

        [TestMethod]
        public void TestMethod2()
        {

        }

        [TestMethod]
        public void TestMethod3()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HotelLibrary
{
    public class Temperaturmaaling
    {
        private int _hotelID;
        private DateTime _datoTid;
        private double _temperature;

        public int HotelID
        {
            get { return _hotelID; }
            set { _hotelID = value; }
        }
        public DateTime DatoTid
        {
            get { return _datoTid; }
            set { _datoTid = value; }
        }
        public double Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }
        public Temperaturmaaling()
        {

        }

        public Temperaturmaaling(int hotelID, DateTime datoTid, double temperature)
        {
            _hotelID = hotelID;
            _datoTid = datoTid;
            _temperature = temperature;
        }
        

    }
}

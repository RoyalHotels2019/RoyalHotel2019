using System;
using System.Collections.Generic;
using System.Text;

namespace HotelLibrary
{
    public class TemperaturData
    {
        private int _hotelID;
        private double _temperature;

        public int HotelID
        {
            get { return _hotelID; }
            set { _hotelID = value; }
        }
        public double Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }
        public TemperaturData(int hotelID, double temperature)
        {
            _hotelID = hotelID;
            _temperature = temperature;
        }
        public override string ToString()
        {
            return $"HotelID: {_hotelID},Temperature: {_temperature}";
        }
    }
}

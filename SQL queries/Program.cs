using System;

namespace SQL_queries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

/*
  
 
Du starter en query ved at rightclicke på 

CREATE DATABASE RoyalHotel2019;

USE RoyalHotel2019;

CREATE TABLE Hotels(
    Hotel_Id int NOT NULL PRIMARY KEY,
    City Nvarchar(70) NOT NULL
);



CREATE TABLE Hoteltemps(
    Tempe_Date datetime NOT NULL,
    Hotel_Id int NOT NULL,
    Tempe_Value float,

Primary KEY (Tempe_Date, Hotel_Id),
FOREIGN KEY (Hotel_Id) REFERENCES Hotels (Hotel_Id)
);
*/
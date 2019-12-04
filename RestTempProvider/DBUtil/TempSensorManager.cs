using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HotelLibrary;

namespace RestTempProvider.DBUtil
{
    public class TempSensorManager
    {
        //thomas
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ThomasTestRoyalHotels;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //christian
        //private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RoyalHotel2019;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //azure
        //private const string ConnectionString = @"Server=tcp:thofoserver.database.windows.net,1433;Initial Catalog = thofodatabase; Persist Security Info=False;User ID = adminthofo; Password=grt45Lde; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";



        private const string INSERT = "INSERT INTO Hoteltemps (Tempe_Date, Hotel_Id, Tempe_Value) VALUES (@Tempe_Date, @Hotel_Id, @Tempe_Value)";
        

        public bool Post(Temperaturmaaling maaling)
        {
            bool retValue;

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(INSERT, connection);
            cmd.Parameters.AddWithValue("@Tempe_Date", maaling.DatoTid);
            cmd.Parameters.AddWithValue("@Hotel_Id", maaling.HotelID);
            cmd.Parameters.AddWithValue("@Tempe_Value", maaling.Temperature);


            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1;
            connection.Close();


            return retValue;
        }
    }
}

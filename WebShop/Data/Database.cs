using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebShop.Data
{
    public class Database
    {
        private static readonly string ConnectionString = "Data Source=mssql.fhict.local;Initial Catalog=dbi343862;User ID=dbi343862;Password=jedikkeoma";

        private static SqlConnection connection = new SqlConnection(ConnectionString);

        private static SqlCommand command;

        public static SqlCommand Command
        {
            get { return command; }
        }

        public static void OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }
        public static void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        public static string Query
        {
            set
            {
                // Zorg ervoor dat er een verbinding gemaakt kan worden
                OpenConnection();

                // Stel het SQL commando in met de gegeven query
                command = new SqlCommand(value, connection);

                //CloseConnection();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WebShop.Models.Classes;

namespace WebShop.Data
{
    public class DataBestelling
    {
        public static bool SetBestellingWithProcedure(List<Product> plist, Bestelling b)
        {
            //maak een nieuwe datatable aan met de juiste kolommen.
            DataTable datalist = new DataTable();
            datalist.Columns.Add("productid");
            datalist.Columns.Add("bestelnummer");

            //zet nieuwe rijen in de datatable.
            foreach (Product p in plist)
            {
                DataRow row = datalist.NewRow();
                row["productid"] = p.ProductID;
                row["bestelnummer"] = b.Bestelnummer;
                datalist.Rows.Add(row);
            }

            try
            {
                Database.OpenConnection();
                Database.Query = "SetBestelling";
                Database.Command.CommandType = CommandType.StoredProcedure;
                Database.Command.Parameters.AddWithValue("@bestelorderlist", datalist);
                Database.Command.Parameters.AddWithValue("@KlantID", b.klantID);
                Database.Command.Parameters.AddWithValue("@DatumBestelling", b.DatumBestelling.ToShortDateString());
                Database.Command.Parameters.AddWithValue("@Betalingswijze", b.Betaalwijze);
                Database.Command.Parameters.AddWithValue("@Verzendkosten", b.Verzendkosten);
                Database.Command.Parameters.AddWithValue("@Korting", b.Korting);
                Database.Command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                Database.CloseConnection();
            }
        }
        public static int GetLatestBestelnummer()
        {
            int bestelnummer = 0;
            try
            {
                Database.OpenConnection();

                Database.Query = "select MAX(bestelnummer) as bestelnummer from bestelling;";
                SqlDataReader reader = Database.Command.ExecuteReader();
                while (reader.Read())
                {
                    bestelnummer = Convert.ToInt32(reader["bestelnummer"]);
                }

                return bestelnummer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return bestelnummer;
            }
            finally
            {
                Database.CloseConnection();
            }
        }
        public static bool SetKorting(int bestelnummer)
        {
            try
            {
                Database.Query = "SetKorting";
                Database.Command.CommandType = CommandType.StoredProcedure;
                Database.Command.Parameters.AddWithValue("@bestelnummer", bestelnummer);
                Database.Command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                Database.CloseConnection();
            }
        }
    }
}
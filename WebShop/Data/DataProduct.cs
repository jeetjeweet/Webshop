using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WebShop.Models.Classes;

namespace WebShop.Data
{
    public class DataProduct
    {
        public static List<Product> GetAllProducts()
        {
            List<Product> Producten = new List<Product>();
            try
            {
                Database.Query = "SELECT * FROM Product ORDER BY ProductID";
                Database.OpenConnection();

                SqlDataReader reader = Database.Command.ExecuteReader();

                while (reader.Read())
                {
                    Producten.Add(new Product(Convert.ToInt32(reader["ProductID"]),
                                             Convert.ToInt32(reader["categorieCategorieID"]),
                                             Convert.ToInt32(reader["leverancierLeveranciersID"]),
                                             Convert.ToDouble(reader["Prijs"]),
                                             Convert.ToDouble(reader["Korting"]),
                                             Convert.ToBoolean(reader["Nieuw"]),
                                             Convert.ToString(reader["Naam"]),
                                             Convert.ToDateTime(reader["Datum Geleverd"])));
                }
                return Producten;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Producten;
            }
            finally
            {
                Database.CloseConnection();
            }
        }
        public static int GetProductKorting(int productid)
        {
            int korting = 0;
            try
            {
                Database.Query = "SELECT [dbo].[GetProductKorting](@productid)";
                Database.Command.CommandType = CommandType.Text;
                Database.Command.Parameters.AddWithValue("@productid", productid);
                korting = Convert.ToInt32(Database.Command.ExecuteScalar());
                return korting;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return korting;
            }
            finally
            {
                Database.CloseConnection();
            }
        }
        public static bool EditSale(int productid, double korting)
        {
            try
            {
                Database.Query = "UPDATE product SET korting = " + korting + " where productid = " + productid + ";";
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
        public static List<Product> SpecialeActie(string datum)
        {
            List<Product> lp = new List<Product>();
            try
            {
                Database.Query = "specialeactie";
                Database.Command.CommandType = CommandType.StoredProcedure;
                Database.Command.Parameters.AddWithValue("@datum", datum);
                SqlDataReader reader = Database.Command.ExecuteReader();
                while (reader.Read())
                {
                    lp.Add(new Product(Convert.ToInt32(reader["ProductID"]),
                                                 Convert.ToInt32(reader["categorieCategorieID"]),
                                                 Convert.ToInt32(reader["leverancierLeveranciersID"]),
                                                 Convert.ToDouble(reader["Prijs"]),
                                                 Convert.ToDouble(reader["Korting"]),
                                                 Convert.ToBoolean(reader["Nieuw"]),
                                                 Convert.ToString(reader["Naam"]),
                                                 Convert.ToDateTime(reader["Datum Geleverd"])));
                }
                return lp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return lp;
            }
            finally
            {
                Database.CloseConnection();
            }
        }
        public static string GetDate()
        {
            string datum = "";
            try
            {
                Database.Query = "select * from datum";
                datum = Convert.ToString(Database.Command.ExecuteScalar());
                return datum;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return datum;
            }
            finally
            {
                Database.CloseConnection();
            }
        }
        public static bool SetDate(string date)
        {
            try
            {
                Database.Query = "Update datum set datum ='" + date + "' where datum = '" + GetDate() + "'";
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
        public static Product GetProductById(int productid)
        {
            try
            {

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models.Classes;
using System.Data.SqlClient;
using System.Data;

namespace WebShop.Data
{
    public class DataAdres
    {
        public static bool AddAdres(Adres adres,Klant klant)
        {
            try
            {
                Database.Query = "INSERT INTO adres (straatnaam,huisnummer,land,postcode,woonplaats) values ('" + adres.Straatnaam + "','" + adres.Huisnummer + "','" + adres.Land + "','" + adres.Postcode + "','" + adres.Woonplaats + "')";
                Database.Command.ExecuteNonQuery();
                Database.Query = "Update klant set adresadresid =" + GetAdresID(adres) + " where email = '" + klant.Email + "'";
                Database.Command.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                Database.CloseConnection();
            }
        }
        public static int GetAdresID(Adres adres)
        {
            int adresid = 0;
            try
            {
                Database.Query = "select adresid from adres where straatnaam = '" + adres.Straatnaam + "' and huisnummer = '" + adres.Huisnummer + "'";
                adresid = Convert.ToInt32(Database.Command.ExecuteScalar());
                return adresid;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return adresid;
            }
            finally
            {
                Database.CloseConnection();
            }
        }
        public static bool CheckKlantAdres(Klant k)
        {
            try
            {
                Database.Query = "select adresadresid from klant where email = '" + k.Email + "';";
                if(Database.Command.ExecuteScalar() == DBNull.Value)
                {
                    return false;
                }
                else
                {
                    return true;
                }   
            }
            catch(NullReferenceException ex)
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
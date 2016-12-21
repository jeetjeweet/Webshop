using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WebShop.Models.Classes;

namespace WebShop.Data
{
    public class DataKlant
    {
        private static string Email;
        private static string Password;
        /// <summary>
        /// Methode voor een account in te loggen.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Returns de ingelogde klant.</returns>
        public static Klant GetPerson(string email, string password)
        {
            try
            {
                //Query check of username + password overeenkomen met iemand uit de database
                Database.OpenConnection();
                //Haal email en wachtwoord op.
                Database.Query = "SELECT * FROM klant WHERE email like '" + email + "'AND wachtwoord like '" + password + "';";
                Database.Command.ExecuteScalar();
                SqlDataReader reader = Database.Command.ExecuteReader();
                while (reader.Read())
                {
                    Email = Convert.ToString(reader["email"]);
                    Password = Convert.ToString(reader["wachtwoord"]);
                    string admin = Convert.ToString(reader["beheerder"]);
                    int klantid = Convert.ToInt32(reader["klantid"]);
                    int dagenlid = Convert.ToInt32(reader["DagenLid"]);
                    int rekeningnummer = Convert.ToInt32(reader["rekeningnummer"]);
                    string naam = Convert.ToString(reader["Naam"]);

                    if (email == Email && password == Password && admin != "wel")
                    {
                        string date = Convert.ToString(reader["datum aangemaakt"]);
                        DateTime d;
                        d = DateTime.Parse(date);
                        Klant k;
                        if(Convert.ToString(reader["adresadresid"]) == "")
                        {
                            k = new Klant(klantid, 0,dagenlid ,rekeningnummer, Email, Password, naam, d, admin);
                        }
                        else
                        {
                            k = new Klant(Convert.ToInt32(reader["klantid"]), Convert.ToInt32(reader["adresadresid"]), Convert.ToInt32(reader["dagenlid"]), Convert.ToInt32(reader["rekeningnummer"]), Email, Password, Convert.ToString(reader["naam"]), d, admin);
                        }
                        Login.loginbool = true;
                        return k;
                    }
                    else if (email == Email && password == Password && admin == "wel")
                    {
                        string date = Convert.ToString(reader["datum aangemaakt"]);
                        DateTime d;
                        d = DateTime.Parse(date);
                        Klant k = new Klant(Convert.ToInt32(reader["klantid"]), Convert.ToInt32(reader["adresadresid"]), Convert.ToInt32(reader["dagenlid"]), Convert.ToInt32(reader["rekeningnummer"]), Email, Password, Convert.ToString(reader["naam"]), d, admin);
                        Login.loginbool = true;
                        return k;
                    }
                    else if (email != Email && password != Password)
                    {
                        Login.loginbool = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Login.loginbool = false;
                return null;
            }
            finally
            {
                Database.CloseConnection();
            }
            return Login.loggedinUser;
        }
        /// <summary>
        /// Checks of an email already exists in the database.
        /// </summary>
        /// <param name="person">Person</param>
        /// <returns>Bool (False to continue)</returns>
        public static bool CheckPerson(Klant klant)
        {
            string email = "";
            try
            {
                Database.Query = "SELECT email FROM klant WHERE email = '" + klant.Email + "';";
                SqlDataReader reader = Database.Command.ExecuteReader();
                while (reader.Read())
                {
                    email = Convert.ToString(reader["email"]);
                }
                if (email == "")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                return true;
            }
            finally
            {
                Database.CloseConnection();
            }
        }
        /// <summary>
        /// Inserts a new account in the database.
        /// </summary>
        /// <param name="person">Person</param>
        /// <returns>bool (true for succes)</returns>
        public static bool SetPerson(Klant klant)
        {
            //Makes sure that the date format is Day, Month, Year

            if (CheckPerson(klant) == false)
            {
                try
                {
                    string today = DateTime.Now.ToShortDateString();
                    Database.Query = "INSERT INTO klant([datum aangemaakt],email,wachtwoord,naam,dagenlid,rekeningnummer,beheerder) VALUES ('" + today + "', '" + klant.Email + "','" + klant.Wachtwoord + "','" + klant.Naam + "'," + 1 + "," + klant.Rekeningnummer + ",'niet');";
                    Database.Command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
                finally
                {
                   Database.CloseConnection();
                }
            }
            else
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Data;

namespace WebShop.Models.Classes
{
    public class Login
    {
        public static Klant loggedinUser;
        public static bool loginbool;

        public Login()
        {

        }

        public static bool LogInUser(string email, string password)
        {
            loggedinUser = DataKlant.GetPerson(email, password);
            if (loginbool == true && loggedinUser != null)
            {
                loginbool = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models.Classes
{
    public class Datum
    {
        private string date;
        public string Date { get { return date; } set { date = value; } }

        public Datum()
        {

        }
        public Datum(string date)
        {
            Date= date;
        }
    }
}
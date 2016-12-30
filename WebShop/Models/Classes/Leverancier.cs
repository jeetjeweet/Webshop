using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models.Classes
{
    public class Leverancier
    {
        private int adresID;
        private int leveranciersID;
        private string naam;

        public int AdresID { get { return adresID; } set { adresID = value; } }
        public int LeveranciersID { get { return leveranciersID; } set { leveranciersID = value; } }
        public string Naam { get { return naam; } set { naam = value; } }

        public Leverancier(int leveranciersid, string naam, int adresid)
        {
            LeveranciersID = leveranciersid;
            Naam = naam;
            AdresID = adresid;
        }
    }
}
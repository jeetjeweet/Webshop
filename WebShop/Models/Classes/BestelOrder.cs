using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models.Classes
{
    public class BestelOrder
    {
        private int productID;
        private int bestelnummer;
        public int ProductID { get { return productID; } set { productID = value; } }
        public int Bestelnummer { get { return bestelnummer; } set { bestelnummer = value; } }

        public BestelOrder(int productid, int bestelnummer)
        {
            ProductID = productid;
            Bestelnummer = bestelnummer;
        }
    }
}
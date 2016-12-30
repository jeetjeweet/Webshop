using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models.Classes
{
    public class Rating
    {
        private int klantID;
        private int productID;
        private int cijfer;

        public int KlantID { get { return klantID; } set { klantID = value; } }
        public int ProductID { get { return productID; } set { productID = value; } }
        public int Cijfer { get { return cijfer; } set { cijfer = value; } }

        public Rating(int klantid, int productid, int cijfer)
        {
            Cijfer = cijfer;
            
            KlantID = klantid;
            ProductID = productid;
        }
    }
}
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

        private double gemiddeldeCijfer;

        public int KlantID { get { return klantID; } set { klantID = value; } }
        public int ProductID { get { return productID; } set { productID = value; } }
        public int Cijfer { get { return cijfer; } set { cijfer = value; } }
        public double GemiddeldeCijfer { get { return gemiddeldeCijfer; } set { gemiddeldeCijfer = value; } }
        public Rating(int klantid, int productid, int cijfer, double gemiddeldecijfer)
        {
            Cijfer = cijfer;
            GemiddeldeCijfer = gemiddeldecijfer;
            KlantID = klantid;
            ProductID = productid;
        }
    }
}
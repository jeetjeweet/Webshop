using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models.Classes
{
    public class Product
    {
        private int leveranciersID;
        private int categorieID;
        private int productID;
        private double prijs;
        private double korting;
        private bool nieuw;
        private string naam;
        private DateTime datumgeleverd;
        public int LeveranciersID { get { return leveranciersID; } set { leveranciersID = value; } }
        public int CategorieID { get { return categorieID; } set { categorieID = value; } }
        public int ProductID { get { return productID; } set { productID = value; } }

        public double Prijs { get { return prijs; } set { prijs = value; } }
        public double Korting { get { return korting; } set { korting = value; } }

        public bool Nieuw { get { return nieuw; } set { nieuw = value; } }

        public string Naam { get { return naam; } set { naam = value; } }

        public DateTime DatumGeleverd { get { return datumgeleverd; } set { datumgeleverd = value; } }
        public Product()
        {

        }

        public Product(int productid, int categorieid, int leveranciersid, double prijs, double korting, bool nieuw, string naam, DateTime datumgeleverd)
        {
            ProductID = productid;
            Prijs = prijs;
            Korting = korting;
            Nieuw = nieuw;
            Naam = naam;
            categorieID = categorieid;
            LeveranciersID = leveranciersid;
            DatumGeleverd = datumgeleverd;
        }
        public override string ToString()
        {
            return $"Naam: {Naam} | Prijs:€ {Prijs} Kortingspercentage: {Korting}%";
        }
    }
}
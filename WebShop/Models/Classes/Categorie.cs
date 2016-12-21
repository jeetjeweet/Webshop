using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models.Classes
{
    public class Categorie
    {
        private int subCategorie;
        private int categorieID;

        private string naam;

        public int SubCategorie { get { return subCategorie; } set { subCategorie = value; } }
        public int CategorieID { get { return categorieID; }set { categorieID = value; } }
        public string Naam { get { return naam; } set { naam = value; } }

        public Categorie(int categorieid, string naam, int subcategorie)
        {
            CategorieID = categorieid;
            Naam = naam;
            SubCategorie = subcategorie;
        }
    }
}
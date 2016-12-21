using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models.Classes
{
    public class Bestelling
    {
        private int klantid;
        private int bestelnummer;
        private double totaalprijs;
        private int verzendkosten;
        private double korting;
        private DateTime datumbestelling;

        public int klantID { get { return klantid; }set { klantid = value; } }
        public int Bestelnummer { get { return bestelnummer; } set { bestelnummer = value; } }

        public double TotaalPrijs { get { return totaalprijs; } set { totaalprijs = value; } }
        public int Verzendkosten { get { return verzendkosten; }set { verzendkosten = value; } }

        public double Korting { get { return korting; } set { korting = value; } }

        public string Betaalwijze { get { return Betaalwijze; } set { Betaalwijze = value; } }

        public DateTime DatumBestelling { get { return datumbestelling; } set { datumbestelling = value; } }

        public Bestelling(int bestelnummer, int klantid, int verzendkosten, double korting, string betaalwijze, DateTime datumbestelling)
        {
            Bestelnummer = bestelnummer;
            Verzendkosten = verzendkosten;
            Korting = korting;
            Betaalwijze = betaalwijze;
            DatumBestelling = datumbestelling;
            klantID = klantid;
        }
    }
}
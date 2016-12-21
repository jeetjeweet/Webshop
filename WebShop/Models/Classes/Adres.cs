using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.Classes
{
    public class Adres
    {
        private int adresID;
        private string straatnaam;
        private int huisnummer;
        private string land;
        private string postcode;
        private string woonplaats;

        public int AdresID
        {
            get { return adresID; }
            set { adresID = value; }
        }
        [Required(ErrorMessage ="Huisnummer is required.")]
        public int Huisnummer
        {
            get { return huisnummer; }
            set { huisnummer = value; }
        }
        [Required(ErrorMessage = "Straatnaam is required.")]
        public string Straatnaam
        {
            get { return straatnaam; }
            set { straatnaam = value; }
        }
        [Required(ErrorMessage = "Land is required.")]
        public string Land
        {
            get { return land; }
            set { land = value; }
        }
        [Required(ErrorMessage = "Postcode is required.")]
        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        [Required(ErrorMessage = "Woonplaats is required.")]
        public string Woonplaats
        {
            get { return woonplaats; }
            set { woonplaats = value; }
        }
        public Adres()
        {

        }
        public Adres(int adresid, string straatnaam, int huisnummer, string land, string postcode, string woonplaats)
        {
            AdresID = adresid;
            Straatnaam = straatnaam;
            Huisnummer = huisnummer;
            Land = land;
            Postcode = postcode;
            Woonplaats = woonplaats;
        }
    }
}
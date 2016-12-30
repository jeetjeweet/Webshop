using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebShop.Models.Classes
{
    public class Klant
    {
        private int klantID;
        private int adresID;
        private int dagenLid;
        private int rekeningnummer;
        private string email;
        private string wachtwoord;
        private string naam;
        private DateTime datumAangemaakt;
        private string admin;

        
        public int KlantID { get { return klantID; } set { klantID = value; } }
        public int DagenLid { get { return dagenLid; } set { dagenLid = value; } }
        public int AdresID { get { return adresID; } set { adresID = value; } }

        [Display(Name ="Rekeningnummer")]
        [Required(ErrorMessage ="Accountnumber is required.")]
        public int Rekeningnummer { get { return rekeningnummer; } set { rekeningnummer = value; } }

        [Display(Name ="Email")]
        [Required(ErrorMessage ="Email is required.")]
        public string Email { get { return email; } set { email = value; } }

        [Display(Name ="Wachtwoord")]
        [Required(ErrorMessage ="Password is required.")]
        [DataType(DataType.Password)]
        public string Wachtwoord { get { return wachtwoord; } set { wachtwoord = value; } }

        [Display(Name ="Voornaam & achternaam")]
        [Required(ErrorMessage ="Name is required.")]
        public string Naam { get { return naam; } set { naam = value; } }

        public string Admin { get { return admin; } set { admin = value; } }
        public DateTime DatumAangemaakt { get { return datumAangemaakt; } set { datumAangemaakt = value; } }
        public List<Product> winkelwagenlist { get; set; }
        public Klant()
        {

        }

        public Klant(int klantid, int adresid, int dagenlid, int rekeningnummer, string email, string wachtwoord, string naam, DateTime datumaangemaakt, string admin)
        {
            KlantID = klantid;
            DagenLid = dagenlid;
            Rekeningnummer = rekeningnummer;
            Email = email;
            Wachtwoord = wachtwoord;
            Naam = naam;
            DatumAangemaakt = datumaangemaakt;
            AdresID = adresid;
            Admin = admin;
            winkelwagenlist = new List<Product>();
        }
    }
}
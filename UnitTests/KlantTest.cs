using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop.Models.Classes;
using System.ComponentModel.DataAnnotations;

namespace UnitTests
{
    [TestClass]
    public class KlantTest
    {
        [TestMethod]
        public void Klant_Constructor()
        {
            //Arrange
            string naam = "Henk";
            int klantid = 1;
            int adresid = 1;
            int dagenlid = 1;
            string email = "Henk@mail.nl";
            int rekeningnummer = 123;
            string wachtwoord = "ww";
            DateTime datumAangemaakt = DateTime.Now;
            string admin = "wel";
            //Act
            Klant p1 = new Klant(klantid, adresid, dagenlid, rekeningnummer, email, wachtwoord, naam, datumAangemaakt, admin);
            //Assert
            Assert.AreEqual(1, p1.KlantID);
            Assert.AreEqual(1,p1.AdresID);
            Assert.AreEqual(1,p1.DagenLid);
            Assert.AreEqual("Henk@mail.nl",p1.Email);
            Assert.AreEqual(123,p1.Rekeningnummer);
            Assert.AreEqual("ww",p1.Wachtwoord);
            Assert.AreEqual("wel",p1.Admin);
            Assert.AreEqual("Henk",p1.Naam);
        }
    }
}

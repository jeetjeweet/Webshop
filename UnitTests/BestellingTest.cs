using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop.Models.Classes;
using System.ComponentModel.DataAnnotations;

namespace UnitTests
{
    [TestClass]
    public class BestellingTest
    {
        [TestMethod]
        public void Bestelling_Constructor()
        {
            //Arrange
            int klantid = 1;
            int bestelnummer = 2;
            string betaalwijze = "12";
            int verzendkosten = 10;
            double korting = 5;
            DateTime dt = DateTime.Now;
            //Act
            Bestelling b = new Bestelling(bestelnummer, klantid, verzendkosten, korting, betaalwijze, dt);
            //Assert
            Assert.AreEqual(2, b.Bestelnummer);
            Assert.AreEqual(1, b.klantID);
            Assert.AreEqual("12", b.Betaalwijze);
            Assert.AreEqual(10, b.Verzendkosten);
            Assert.AreEqual(5, b.Korting);
        }
    }
}

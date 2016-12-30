using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop.Models.Classes;
using System.ComponentModel.DataAnnotations;

namespace UnitTests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            int productid = 1;
            int categorieid = 2;
            int leveranciersid = 3;
            double prijs = 10;
            double korting = 5;
            bool nieuw = false;
            string naam = "naam";
            //Act
            Product p = new Product(productid, categorieid, leveranciersid, prijs, korting, nieuw, naam, DateTime.Now);
            //Assert
            Assert.AreEqual(1,p.ProductID);
            Assert.AreEqual(2,p.CategorieID);
            Assert.AreEqual(3,p.LeveranciersID);
            Assert.AreEqual(10,p.Prijs);
            Assert.AreEqual(5,p.Korting);
            Assert.AreEqual(false,p.Nieuw);
            Assert.AreEqual("naam",p.Naam);
        }
    }
}

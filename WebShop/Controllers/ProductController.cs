using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models.Classes;
using System.Data;
using WebShop.Data;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AlleProducten()
        {
            List<Product> alleproducten = DataProduct.GetAllProducts();
            return View(alleproducten);
        }
        public ActionResult SpecialeActie()
        {
            List<Product> specialactieproductlist = DataProduct.SpecialeActie(DataProduct.GetDate());
            return View(specialactieproductlist);
        }

        [HttpPost]
        public ActionResult EditSale(double korting, int productid)
        {
            if (DataProduct.EditSale(productid, korting))
            {
                return RedirectToAction("AlleProducten");
            }
            else
            {
                ViewBag.Message = "Er is iets mis gegaan, probeer het opnieuw.";
                return View("AlleProducten");
            }
        }
    }
}
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

        [HttpPost]
        public ActionResult AlleProducten(int productid)
        {
            Product p = DataProduct.GetProductById(productid);
           if( p != null)
            {
                return RedirectToAction("EditSale", p);
            }
            return View();
        }

        public ActionResult SpecialeActie()
        {
            List<Product> specialactieproductlist = DataProduct.SpecialeActie(DataProduct.GetDate());
            return View(specialactieproductlist);
        }

        public ActionResult EditSale(Product p)
        {
            return View(p);
        }

        [HttpPost]
        public ActionResult EditSale(double Korting, int productid)
        {
            if (DataProduct.EditSale(productid, Korting))
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
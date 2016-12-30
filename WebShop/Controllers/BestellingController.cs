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
    public class BestellingController : Controller
    {
        // GET: Bestelling
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Winkelwagen()
        {
            if(Login.loggedinUser == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            else
            {
                return View(Login.loggedinUser.winkelwagenlist);
            }
        }

        [HttpPost]
        public ActionResult Winkelwagen(int productid)
        {
            if(Login.loggedinUser == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            else
            {
                Product p = DataProduct.GetProductById(productid);
                Login.loggedinUser.winkelwagenlist.Add(p);
                return View(Login.loggedinUser.winkelwagenlist);
            }
        }

        [HttpPost]
        public ActionResult Verwijder(int productid)
        {
            Product p = DataProduct.GetProductById(productid);
            foreach(Product product in Login.loggedinUser.winkelwagenlist)
            {
                if (p.ProductID == product.ProductID)
                {
                   Login.loggedinUser.winkelwagenlist.Remove(product);
                   return View("Winkelwagen", Login.loggedinUser.winkelwagenlist);
                }
            }
            return View("Winkelwagen", Login.loggedinUser.winkelwagenlist);
        }

        [HttpPost]
        public ActionResult Bestellen()
        {
            if (Login.loggedinUser.winkelwagenlist == null)
            {
                return RedirectToAction("Winkelwagen");
            }
            else
            {
                //implementeer if(3x een productid == een productid in de lijst met speciale acties)
                //{doe shit}
                Bestelling b = new Bestelling(DataBestelling.GetLatestBestelnummer() + 1, Login.loggedinUser.KlantID, 10, 0, "1", DateTime.Now);
                if (DataBestelling.SetBestellingWithProcedure(Login.loggedinUser.winkelwagenlist, b))
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return RedirectToAction("Winkelwagen");
                }
            }
        }
    }
}
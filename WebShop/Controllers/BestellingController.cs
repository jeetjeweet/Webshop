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
            return View();
        }
        [HttpPost]
        public ActionResult Winkelwagen(int productid)
        {
            Product p = DataProduct.GetProductById();
            Login.loggedinUser.winkelwagenlist.Add(p);
            return View(Login.loggedinUser.winkelwagenlist);
        }
    }
}
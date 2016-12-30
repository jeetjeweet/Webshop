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
    public class AdresController : Controller
    {
        // GET: Adres
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddAdres()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdres(Adres adres)
        {
            if (DataAdres.AddAdres(adres, Login.loggedinUser))
            {
                ViewBag.Message = "Adres is toegevoegd aan uw account!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Er is wat fout gegaan, probeer het opnieuw.";
            }
            return View();
        }
    }
}
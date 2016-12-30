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
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Klant klant)
        {
            if (ModelState.IsValid)
            {
                if (DataKlant.CheckPerson(klant))
                {
                    ViewBag.message = "De ingevulde email is al in gebruik.";
                }
                else
                {
                    if (DataKlant.SetPerson(klant))
                    {
                        ViewBag.Message = "Uw account is succesvol aangemaakt.";
                        return RedirectToAction("LogIn", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Er is wat mis gegaan met uw account aanmaken, probeer het opnieuw.";
                    }
                }
            }
            return View();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models.Classes;
using System.Data;
using WebShop.Data;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Klant klant)
        {
            if (Login.LogInUser(klant.Email, klant.Wachtwoord))
            {
                if (Login.loggedinUser != null)
                {
                    Session["Loggedin"] = Login.loggedinUser.Admin;
                    if (DataAdres.CheckKlantAdres(Login.loggedinUser))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("AddAdres", "Adres");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is incorrect.");
                }
            }
            else
            {
                ViewBag.message = "Email en/of wachtwoord zijn niet correct.";
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.RemoveAll();
            Login.loggedinUser = null;
            return Redirect(Url.Action("Index","Home"));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FooMoviesRental.Models;
using FooMoviesRental.Services;

namespace FooMoviesRental.Controllers
{
    public class AccountController : Controller
    {
        MoviesRentalDbService db = new MoviesRentalDbService();

        // GET: /Account/Login
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return Login(model);
            else
            {
                var klant = db.GetKlant(model.Naam, model.Postcode);
                if (klant != null)
                {
                    Session["Username"] = $"{klant.Voornaam} {klant.Naam}";
                    Session["UserId"] = klant.KlantNr;
                    return RedirectToAction("Genres", "MoviesRental");
                }
                else return View("LoginError");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
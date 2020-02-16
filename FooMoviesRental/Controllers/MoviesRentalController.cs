using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FooMoviesRental.Controllers
{
    public class MoviesRentalController : Controller
    {
        // GET: MoviesRental
        public ActionResult Genres()
        {
            return View();
        }
    }
}
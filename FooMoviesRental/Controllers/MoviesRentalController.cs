using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FooMoviesRental.Services;

namespace FooMoviesRental.Controllers
{
    public class MoviesRentalController : Controller
    {
        MoviesRentalDbService db = new MoviesRentalDbService();

        // GET: ~/MoviesRental/Genres
        public ActionResult Genres()
        {
            var genres = db.GetGenres();
            return View(genres);
        }

        // GET: ~/MoviesRental/Films
        public ActionResult Films(int genreNr)
        {
            var films = db.GetFilms(genreNr);
            return View(films);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FooMoviesRental.Services;
using FooMoviesRental.Models;

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

        // GET: ~/MoviesRental/Films?genreNr=5
        public ActionResult Films(int genreNr)
        {
            ViewBag.genre = db.GetGenre(genreNr).GenreNaam;
            var films = db.GetFilms(genreNr);
            return View(films);
        }
        
        // GET: ~/MoviesRental/Huren?bandNr=5
        public ActionResult Huren(int bandNr)
        {
            var film = db.GetFilm(bandNr);
            if (film.InVoorraad < 1)
            {
                TempData["FilmTitel"] = film.Titel;
                return RedirectToAction("Films", new { genreNr = film.GenreNr });
            }
                
            Session[bandNr.ToString()] = 1;
            return RedirectToAction("Mandje");
        }

        // GET: ~/MoviesRental/Mandje
        public ActionResult Mandje()
        {
            List<MandjeItem> mandjeItems = new List<MandjeItem>();
            foreach (string key in Session)
            {
                if (int.TryParse(key, out int bandNr))
                {
                    Film film = db.GetFilm(bandNr);
                    if (film != null)
                    {
                        MandjeItem mandjeItem = new MandjeItem(film.BandNr, film.Titel, film.Prijs);
                        mandjeItems.Add(mandjeItem);
                    }
                }
            }
            return View(mandjeItems);
        }
    }
}
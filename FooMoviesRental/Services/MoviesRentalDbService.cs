using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FooMoviesRental.Models;

namespace FooMoviesRental.Services
{
    public class MoviesRentalDbService
    {
        public Klant GetKlant(string naam, int? postcode)
        {
            using (var db = new FooMoviesRentalEntities())
            {
                var query = from k in db.Klanten
                            where k.Naam == naam && k.PostCode == postcode
                            select k;
                return query.FirstOrDefault();
            }
        }

        public Klant GetKlant(int id)
        {
            using (var db = new FooMoviesRentalEntities())
            {
                return db.Klanten.Find(id);
            }
        }


        public List<Genre> GetGenres()
        {
            using (var db = new FooMoviesRentalEntities())
            {
                var query = from g in db.Genres
                            orderby g.GenreNaam
                            select g;
                return query.ToList();
            }
        }

        public Genre GetGenre(int genreNr)
        {
            using (var db = new FooMoviesRentalEntities())
            {
                var query = from g in db.Genres
                            where g.GenreNr == genreNr
                            select g;
                return query.FirstOrDefault();
            }
        }

        public List<Film> GetFilms(int genreNr)
        {
            using (var db = new FooMoviesRentalEntities())
            {
                var query = from f in db.Films
                            where f.GenreNr == genreNr
                            select f;
                return query.ToList();
            }
        }

        public Film GetFilm(int bandNr)
        {
            using (var db = new FooMoviesRentalEntities())
            {
                var query = from film in db.Films
                            where film.BandNr == bandNr
                            select film;
                return query.FirstOrDefault();
            }
        }

        public void UpdateDatabase(int klantNr, int bandNr)
        {
            Verhuur verhuur = new Verhuur();
            verhuur.KlantNr = klantNr;
            verhuur.BandNr = bandNr;
            verhuur.VerhuurDatum = DateTime.Now.Date;

            using (var db = new FooMoviesRentalEntities())
            {
                //Record verhuur
                db.Verhuren.Add(verhuur);
                //Updtae invoorraad & outvoorraad
                Film film = db.Films.Find(bandNr);
                film.InVoorraad -= 1;
                film.UitVoorraad += 1;
                film.TotaalVerhuurd += 1;
                db.SaveChanges();
            }
        }
    }
}
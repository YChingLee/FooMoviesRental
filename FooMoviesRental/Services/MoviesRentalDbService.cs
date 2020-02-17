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

    }
}
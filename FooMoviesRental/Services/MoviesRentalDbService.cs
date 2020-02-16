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

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FooMoviesRental.Models
{
    public class MandjeItem
    {
        public MandjeItem(int bandNr, string titel, decimal prijs)
        {
            BandNr = bandNr;
            Titel = titel;
            Prijs = prijs;
        }

        public int BandNr { get; set; }
        public string Titel { get; set; }

        [DisplayFormat(DataFormatString = "€ {0:#,##0.00}")]
        public decimal Prijs { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FooMoviesRental.Models
{
    public class AfrekenenViewModel
    {
        public AfrekenenViewModel(Klant klant)
        {
            GelukteVerhuringen = new List<MandjeItem>();
            MislukteVerhuringen = new List<MandjeItem>();
            Klant = klant;
        }
        public List<MandjeItem> GelukteVerhuringen { get; set; }
        public List<MandjeItem> MislukteVerhuringen { get; set; }
        public Klant Klant { get; set; }
    }
}

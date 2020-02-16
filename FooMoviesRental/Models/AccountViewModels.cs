using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FooMoviesRental.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Naam { get; set; }

        [Required]
        public int? Postcode { get; set; }
    }
}
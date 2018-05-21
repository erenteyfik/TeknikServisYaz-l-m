using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeknikServisYazılım.Entity;

namespace TeknikServisYazılım.Models
{
    public class GunlukKasaModel
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public DateTime srftime { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-mm-yyyy HH:mm:ss}")]
        public DateTime Start { get; set; } = DateTime.Now;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-mm-yyyy HH:mm:ss}")]
        public DateTime End { get; set; }

        public List<ServiceRegistrationForm> ServiceRegistrationForms { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeknikServisYazılım.Entity
{
    public class Sellproduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SName { get; set; }
        public string SBrand { get; set; }
        public string SModel { get; set; }
        public int SNumber { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; } 

    }
}

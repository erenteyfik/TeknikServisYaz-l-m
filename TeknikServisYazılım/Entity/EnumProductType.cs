using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeknikServisYazılım.Entity
{
    public enum EnumProductType
    {
        [Display(Name = "TÜR SEÇ")]
        SFRState,
        [Display(Name = "CEP TELEFON")]
        Phone,
        [Display(Name = "TABLET")]
        Tablet,
        [Display(Name = "NOTEBOOK")]
        Notebook,
        [Display(Name = "MASAÜSTÜ")]
        Desktop,
        [Display(Name = "DİĞER")]
        Other,
    }
}
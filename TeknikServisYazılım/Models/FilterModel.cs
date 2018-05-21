using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TeknikServisYazılım.Entity;
using TeknikServisYazılım.Identity;

namespace TeknikServisYazılım.Models
{
    public class FilterModel
    {
        public IEnumerable<ServiceRegistrationForm> ServiceRegistrationForm { get; set; }
        public IEnumerable<Suppliers> Suppliers { get; set; }

 
        public string StateFilter { get; set; }
        public string UserFilter { get; set; }

        public EnumProductState EnumState { get; set; }
        public virtual ICollection<ApplicationUser> TransferUserS { get; set; }
    }
}
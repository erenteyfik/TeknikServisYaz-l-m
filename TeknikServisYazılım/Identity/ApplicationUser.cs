using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknikServisYazılım.Identity
{
    public class ApplicationUser : IdentityUser
    {
        //extra özellikler eklemek icin ApplicationUser oluşturduk.
        public string Name { get; set; }

    }
}
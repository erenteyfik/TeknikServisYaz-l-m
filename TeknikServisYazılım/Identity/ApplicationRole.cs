using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknikServisYazılım.Identity
{
    public class ApplicationRole : IdentityRole
    {
        //extra özellikler eklemek icin ApplicationRole oluşturduk.
        public string Description { get; set; }

    }
}
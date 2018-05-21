using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeknikServisYazılım.Entity
{
    public class TechnicalServiceLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string LogWho { get; set; }
        public string LogDescription { get; set; }
        public DateTime LogDatetime { get; set; }

        public string LogWhichCustomer { get; set; }
        //public string LogWhichProduct { get; set; }
        //public string LogWhichSRF { get; set; }

        public int ServiceRegistrationFormID { get; set; }

    }
}
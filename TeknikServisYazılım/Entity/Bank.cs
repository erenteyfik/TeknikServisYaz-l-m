using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeknikServisYazılım.Entity
{
    public class Bank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserName { get; set; }
        public int Payment { get; set; }
        public string WhoUser { get; set; }
        public string BankDescription { get; set; }
        public DateTime BankTime { get; set; }
    }
}
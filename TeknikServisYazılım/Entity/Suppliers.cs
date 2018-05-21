﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeknikServisYazılım.Entity
{
    public class Suppliers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        [NotMapped]
        public virtual ICollection<SupplierPaymentList> SPaymentList { get; set; }
    }
}
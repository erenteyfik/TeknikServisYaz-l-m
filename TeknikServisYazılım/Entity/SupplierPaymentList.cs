using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeknikServisYazılım.Entity
{
    public class SupplierPaymentList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Income { get; set; } = 0;
        public int Expense { get; set; } = 0;
        public string Description { get; set; }
        public DateTime? SupplierDate { get; set; }

        public int SupplierId { get; set; }

    }
}
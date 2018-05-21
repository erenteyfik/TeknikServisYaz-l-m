using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeknikServisYazılım.Entity;

namespace TeknikServisYazılım.Models
{
    public class SafeModel
    {
        public int Id { get; set; }
        public int ServiceFormTotal { get; set; } 
        public int SupplierIncome { get; set; } 
        public int SupplierExpense { get; set; }
        public int TotalGain { get; set; }
        public DateTime Start { get; set; } 
        public DateTime End { get; set; } = DateTime.Now;
        public int Total { get; set; }

        public List<ServiceRegistrationForm> ServiceRegistrationForms { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeknikServisYazılım.Entity;

namespace TeknikServisYazılım.Models
{
    public class BankModel
    {
        public int Id { get; set; }

        public List<ServiceRegistrationForm> ServiceRegistrationForm { get; set; }
        public List<Bank> Bank { get; set; }

        public string BankModelUserName { get; set; }
        //Totalborç -yapılanödeme -kalanborç
        public int TotalDebt{ get; set; }
        public int PaymentMade { get; set; }
        public int RemainingMade { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; } = DateTime.Now;

    }
}
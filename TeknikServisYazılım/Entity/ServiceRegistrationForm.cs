using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServisYazılım.Identity;
using TeknikServisYazılım.Models;

namespace TeknikServisYazılım.Entity
{
    public class ServiceRegistrationForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Price { get; set; }
        public EnumProductState SFRState { get; set; }
        public string SupplierName { get; set; } = "CNH";
        public bool Active { get; set; }
        public bool PaymentCheck { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-mm-yyyy HH:mm:ss}")]
        public DateTime SRFDatetime { get; set; }
        public DateTime? SRFArrivalDatetime { get; set; }
        public bool? SRFWhoUser { get; set; }
        public string KimeAit { get; set; } = "CNH";
        public bool SRFDevrettiUser { get; set; }
        public string KimeDevretti { get; set; }
        public string KimeDevrettiControl { get; set; }

        //Getirilen Ürün
        public Product product { get; set; }
        public int ProductId { get; set; }

        //Müşteri
        public Customer customer { get; set; }
        public int CustomerId { get; set; }

        //Değişen Satılan Ürün
        public Sellproduct sellproduct { get; set; }
        public int SellproductId { get; set; }
        [NotMapped]
        public virtual ICollection<Sellproduct> Sproducts { get; set; }

        //Dış Servis
        [NotMapped]
        public int? SuppliersId { get; set; }
        [NotMapped]
        public Suppliers Supplier { get; set; }
        [NotMapped]
        public virtual ICollection<Suppliers> Suppliers { get; set; }

        //Servise ait log
        [NotMapped]
        public virtual ICollection<TechnicalServiceLog> TLogs { get; set; }


        [NotMapped]
        public int? TransferUserId { get; set; }
        [NotMapped]
        public ApplicationUser TransferUser { get; set; }
        [NotMapped]
        public virtual ICollection<ApplicationUser> TransferUserS { get; set; }

    }
}
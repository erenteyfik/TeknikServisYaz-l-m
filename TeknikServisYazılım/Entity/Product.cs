using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeknikServisYazılım.Entity
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public EnumProductType ProductType { get; set; }
        public string PBrand { get; set; }
        public string PModel { get; set; }
        public string PSerialNumber { get; set; }
        public string PBatterySerialNumber { get; set; }
        public string Ekparcalar { get; set; }
        public bool PBattery { get; set; }
        public bool PChanger { get; set; }

        //müşteri için istenildi ayrı
        public string PFaultrecord { get; set; }

        //cihazın durum tespitini yapacak personelin notu için ayrı 
        public string PFaultpersonel { get; set; }

    }
}
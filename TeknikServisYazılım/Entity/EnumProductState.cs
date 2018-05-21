using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeknikServisYazılım.Entity
{
    public enum EnumProductState
    {
        [Display(Name = "DURUM SEÇ")]
        SFRState,

        [Display(Name = "YENİ GELEN ÜRÜN")]
        SFRNew,

        [Display(Name = "İŞLEMDE")]
        SFRProcess,

        [Display(Name = "FİYAT VERİLECEK")]
        SFRPricegive,

        [Display(Name = "TESLİM EDİLDİ")]
        SFRWasDelivered,

        [Display(Name = "İADE")]
        SFRReturn,

        [Display(Name = "İADEDEN TESLİM")]
        SFRWasReturn,

        [Display(Name = "TEST AŞAMASINDA")]
        SFRTest,

        [Display(Name = "ONAY BEKLİYOR")]
        Waiting,

        [Display(Name = "ONAYLANDI")]
        Approved,

        [Display(Name = "TAMİR EDİLDİ")]
        Repair,

        [Display(Name = "PARÇA BEKLİYOR")]
        Item,

        [Display(Name = "DIŞ SERVİS")]
        Suppliers,

        [Display(Name = "İKİNCİ GELİŞ")]
        SFRSecond,

        [Display(Name = "TAMAMLANDI")]
        Completed,
    }
}
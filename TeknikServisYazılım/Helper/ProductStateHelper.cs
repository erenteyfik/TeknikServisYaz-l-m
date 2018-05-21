using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeknikServisYazılım.Entity;

namespace TeknikServisYazılım.Helper
{
    public static class ProductStateHelper
    {
        public static string GetProductState(this EnumProductState productState)
        {
            string result = "";

            switch (productState)
            {
                case EnumProductState.SFRState:
                    result = "";
                    break;
                case EnumProductState.SFRNew:
                    result = "YENİ ÜRÜN";   
                    break;
                case EnumProductState.SFRProcess:
                    result = "İŞLEMDE";
                    break;
                case EnumProductState.SFRPricegive:
                    result = "FİYAT VERİLECEK";
                    break;
                case EnumProductState.SFRWasDelivered:
                    result = "TESLİM EDİLDİ";
                    break;
                case EnumProductState.SFRReturn:
                    result = "İADE";
                    break;
                case EnumProductState.SFRTest:
                    result = "TEST AŞAMASINDA";
                    break;
                case EnumProductState.Waiting:
                    result = "ONAY BEKLİYOR";
                    break;
                case EnumProductState.Approved:
                    result = "ONAYLANDI";
                    break;
                case EnumProductState.Repair:
                    result = "TAMİR EDİLDİ";
                    break;
                case EnumProductState.Item:
                    result = "PARÇA BEKLİYOR";
                    break;
                case EnumProductState.Suppliers:
                    result = "DIŞ SERVİSTE";
                    break;
                case EnumProductState.SFRSecond:
                    result = "İKİNCİ GELİŞ";
                    break;
                case EnumProductState.Completed:
                    result = "TAMAMLANDI";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
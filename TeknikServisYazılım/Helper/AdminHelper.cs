using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServisYazılım.Models;

namespace TeknikServisYazılım.Helper
{
    public class AdminHelper
    {
        DataContext db = new DataContext();
        [HttpGet]
        public JsonResult GetSearchBrandValue(string search)
        {
            DataContext db = new DataContext();
            List<ProductBrandModel> allsearch = db.Products.Where(x => x.PBrand.StartsWith(search)).Select(w => new ProductBrandModel
            {
                Id = w.Id,
                PBrand = w.PBrand
            }).ToList();
            if (allsearch.Count() == 0)
            {
                return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public JsonResult GetSearchModelValue(string search)
        {
            DataContext db = new DataContext();
            List<ProductModelModel> allsearch = db.Products.Where(x => x.PModel.StartsWith(search)).Select(w => new ProductModelModel
            {
                Id = w.Id,
                PModel = w.PModel
            }).ToList();
            if (allsearch.Count() == 0)
            {
                return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        [HttpGet]
        public JsonResult GetSearchSellProductValue(string search)
        {
            List<SellProductModel> allsearch = db.Sellproducts.Where(x => x.SName.StartsWith(search)).Select(w => new SellProductModel
            {
                Id = w.Id,
                Name = w.SName,
            }).ToList();
            if (allsearch.Count() == 0)
            {
                return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
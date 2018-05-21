using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServisYazılım.Entity;
using TeknikServisYazılım.Identity;
using TeknikServisYazılım.Models;

namespace TeknikServisYazılım.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SafeController : Controller
    {
        private DataContext db = new DataContext();

        // Kasa
        public ActionResult Index(SafeModel model)
        {
            var aaax = db.SRFs.Where(w => w.Active == true && w.SFRState == EnumProductState.SFRWasDelivered).ToList();
            foreach (var item in aaax)
            {
                var y = db.Customers.Where(w => w.Id == item.CustomerId).FirstOrDefault();
                if (y != null)
                {
                    item.customer.UserName = y.UserName;
                }
                var z = db.Products.Where(w => w.Id == item.ProductId).FirstOrDefault();
                if (z != null)
                {
                    item.product.PBrand = z.PBrand;
                    item.product.PModel = z.PModel;
                }
            }
            var datetime1 = new DateTime(0001, 01, 01);
            if (model.Start == datetime1)
            {
                model.Start = new DateTime(2018, 01, 01);
            }

            SafeModel Safe = new SafeModel()
            {
                Start = model.Start,
                End = model.End,
            };
            if (Safe.End.Hour < 24)
            {
                int x = 23 - Safe.End.Hour;
                Safe.End = Safe.End.AddHours(x);
            }
            if (Safe.Start.Hour > 0)
            {
                int y = Safe.Start.Hour - 0;
                Safe.Start = Safe.Start.AddHours(-y);
            }
            //var Bank = db.Banks.Where(w => w.BankTime >= Safe.Start && w.BankTime <= Safe.End).ToList();
            //foreach (var item in Bank)
            //{
            //    Safe.TotalGain = item.Payment + Safe.TotalGain;
            //}
  
            Safe.ServiceRegistrationForms = aaax.Where(w => w.SRFDatetime >= model.Start && w.SRFDatetime <= model.End).ToList();
            Safe.Total = Safe.ServiceRegistrationForms.Sum(s => s.Price);
            return View(Safe);
        }

        [HttpPost]
        public ActionResult SafePost(SafeModel safe)
        {

            return RedirectToAction("Index", safe);
        }


        public ActionResult Gunluk(GunlukKasaModel model)
        {
            var x = db.SRFs.Where(w => w.Active == true && w.SFRState == EnumProductState.SFRWasDelivered).ToList();
            foreach (var item in x)
            {
                var y = db.Customers.Where(w => w.Id == item.CustomerId).FirstOrDefault();
                if (y != null)
                {
                    item.customer.UserName = y.UserName;
                }
                var z = db.Products.Where(w => w.Id == item.ProductId).FirstOrDefault();
                if (z != null)
                {
                    item.product.PBrand = z.PBrand;
                    item.product.PModel = z.PModel;
                }
            }
            if (model.Start.Hour > 0)
            {
                int k = model.Start.Hour - 0;
                model.Start = model.Start.AddHours(-k);
                model.End = model.Start;
                model.End = model.End.AddHours(23);
                model.ServiceRegistrationForms = x.Where(w => w.SRFDatetime >= model.Start && w.SRFDatetime <= model.End).ToList();
                model.Total = model.ServiceRegistrationForms.Sum(s => s.Price);
                return View(model);
            }
         
                model.End = model.Start;
                model.End = model.End.AddHours(23);
                model.ServiceRegistrationForms = x.Where(w => w.SRFDatetime >= model.Start && w.SRFDatetime <= model.End).ToList();
                model.Total = model.ServiceRegistrationForms.Sum(s => s.Price);
                return View(model);

        }

        [HttpPost]
        public ActionResult GunlukPost(GunlukKasaModel model)
        {

            return RedirectToAction("Gunluk",model);
        }
    }
}
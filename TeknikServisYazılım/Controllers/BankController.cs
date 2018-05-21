using Microsoft.AspNet.Identity;
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
    public class BankController : Controller
    {
        private DataContext db = new DataContext();

        // KASA
        // Sallamasyon ilerledik burda ilerde düzelt
        public ActionResult Bank(BankModel model)
        {
            if (model != null)
            {
                var yyyyy = db.Banks.Where(w => w.UserName == model.BankModelUserName && w.Payment > 0).OrderByDescending(w => w.BankTime).ToList();
                var xx = db.SRFs.Where(w => w.customer.UserName == model.BankModelUserName && w.Price > 0 && w.Active == true).ToList();
                foreach (var item in xx)
                {
                    var yy = db.Customers.Where(w => w.Id == item.CustomerId).FirstOrDefault();
                    if (yy != null)
                    {
                        item.customer.UserName = yy.UserName;
                        item.customer.Phone = yy.Phone;
                    }
                    var z = db.Products.Where(w => w.Id == item.ProductId).FirstOrDefault();
                    if (z != null)
                    {
                        item.product.PBrand = z.PBrand;
                        item.product.PModel = z.PModel;
                    }
                }
                BankModel bankk = new BankModel();
                bankk.ServiceRegistrationForm = xx.Where(w => w.SFRState == EnumProductState.SFRWasDelivered).ToList();
                bankk.Bank = yyyyy;
                bankk.BankModelUserName = model.BankModelUserName;
                bankk.TotalDebt = xx.Where(w => w.SFRState == EnumProductState.SFRWasDelivered).Sum(w => w.Price);
                bankk.PaymentMade = yyyyy.Sum(w => w.Payment);
                bankk.RemainingMade = (bankk.TotalDebt) - (bankk.PaymentMade);
                return View(bankk);
            }
            else
            {
                var x = db.SRFs.Where(w => w.Active == true && w.Price < -10000).OrderByDescending(w => w.SRFDatetime).ToList();
                var y = db.Banks.Where(w => w.UserName == "mahmdsadsadsaut").ToList();
                BankModel bank = new BankModel();
                bank.BankModelUserName = "";
                bank.Bank = y;
                bank.ServiceRegistrationForm = x;
                return View(bank);
            }
        }

        [HttpPost]
        public ActionResult BankPost(BankModel model)
        {

            var yyyyy = db.Banks.Where(w => w.UserName == model.BankModelUserName && w.Payment > 0).OrderByDescending(w => w.BankTime).ToList();
            var x = db.SRFs.Where(w => w.customer.UserName == model.BankModelUserName && w.Price > 0 && w.Active == true).ToList();
            foreach (var item in x)
            {
                var y = db.Customers.Where(w => w.Id == item.CustomerId).FirstOrDefault();
                if (y != null)
                {
                    item.customer.UserName = y.UserName;
                    item.customer.Phone = y.Phone;
                }
                var z = db.Products.Where(w => w.Id == item.ProductId).FirstOrDefault();
                if (z != null)
                {
                    item.product.PBrand = z.PBrand;
                    item.product.PModel = z.PModel;
                }
            }
            BankModel bank = new BankModel();
            bank.ServiceRegistrationForm = x.Where(w => w.SFRState == EnumProductState.SFRWasDelivered).ToList();
            bank.Bank = yyyyy;
            bank.BankModelUserName = model.BankModelUserName;
            bank.TotalDebt = x.Where(w => w.SFRState == EnumProductState.SFRWasDelivered).Sum(w => w.Price);
            bank.PaymentMade = yyyyy.Sum(w => w.Payment);
            bank.RemainingMade = (bank.TotalDebt) - (bank.PaymentMade);

            return View(bank);
        }


        public ActionResult Payment(string UserName)
        {
            Bank payment = new Bank();
            payment.UserName = UserName;

            return View(payment);
        }

        [HttpPost]
        public ActionResult PaymentPost(Bank model)
        {
            Bank payment = new Bank()
            {
                Payment = model.Payment,
                BankDescription = model.BankDescription,
                UserName = model.UserName,
                WhoUser = User.Identity.Name,
                BankTime = DateTime.Now
            };

            db.Banks.Add(payment);
            db.SaveChanges();

            BankModel bank = new BankModel()
            {
                BankModelUserName = model.UserName,
            };

            return RedirectToAction("Bank", bank);
        }


        public ActionResult Delete(int id)
        {
            var bank = db.Banks.Find(id);
            BankModel bankmodel = new BankModel()
            {
                BankModelUserName = bank.UserName,
            };
            if (bank != null)
            {
                var result = db.Banks.Remove(bank);
                db.SaveChanges();

                return RedirectToAction("Bank", bankmodel);
            }
            else
            {
                return View("Error", new string[] { "Ödeme Bulunamadı" });
            }
        }

        [HttpGet]
        public JsonResult GetSearchPaymentValue(string search)
        {
            List<BankPaymentModel> allsearch = db.Customers.Where(x => x.UserName.StartsWith(search)).Select(w => new BankPaymentModel
            {
                Id = w.Id,
                UserName = w.UserName,
            }).ToList();

            var myList = new List<string>();
            foreach (var item in allsearch)
            {
                foreach (var item2 in myList)
                {
                    if (item2 == item.UserName)
                    {
                        item.UserName = null;
                    }
                }
                myList.Add(item.UserName);
            }

            var y = allsearch.Where(w => w.UserName != null).ToList();

            if (allsearch.Count() == 0)
            {
                return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = y, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
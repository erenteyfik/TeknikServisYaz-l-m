using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TeknikServisYazılım.Entity;
using TeknikServisYazılım.Helper;
using TeknikServisYazılım.Identity;
using TeknikServisYazılım.Models;

namespace TeknikServisYazılım.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private DataContext db = new DataContext();
        private UserManager<ApplicationUser> userManager;

        public AdminController()
        {
            var userStore = new UserStore<ApplicationUser>(new DataContext());
            userManager = new UserManager<ApplicationUser>(userStore);
        }

        public ActionResult Index()
        {
            return View();
            //return View(db.TSLogs.OrderByDescending(w => w.LogDatetime).ToList());
        }

        // Sisteme kayıt olan kullanıcıları listelesin oluşturdugumuz userManager ile
        public ActionResult Kullanıcılar()
        {
            return View(userManager.Users);
        }

        public ActionResult ServisFormlarım()
        {

            var x = db.SRFs.Where(w => w.Active == true).OrderByDescending(w => w.SRFDatetime).ToList();
            foreach (var item in x)
            {

                var y = db.Customers.Where(w => w.Id == item.CustomerId).FirstOrDefault();
                if (y != null)
                {
                    item.customer.Id = y.Id;
                    item.customer.UserName = y.UserName;
                    item.customer.Email = y.Email;
                    item.customer.Phone = y.Phone;
                }
                var z = db.Products.Where(w => w.Id == item.ProductId).FirstOrDefault();
                if (z != null)
                {
                    item.product.Id = z.Id;
                    item.product.ProductType = z.ProductType;
                    item.product.PBrand = z.PBrand;
                    item.product.PModel = z.PModel;
                    item.product.PSerialNumber = z.PSerialNumber;
                    item.product.PBatterySerialNumber = z.PBatterySerialNumber;
                    item.product.Ekparcalar = z.Ekparcalar;
                    item.product.PFaultrecord = z.PFaultrecord;
                    item.product.PFaultpersonel = z.PFaultpersonel;
                }
            }

            FilterModel filter = new FilterModel();
            filter.ServiceRegistrationForm = x.OrderByDescending(w => w.SRFDatetime);
            filter.Suppliers = db.Suppliers.ToList();
            filter.TransferUserS = db.Users.ToList();


            return View(filter);
        }

        //duruma ve kullanıcıya göre filtrele
        public ActionResult ServisFormlarımState(string EnumState, string UserFilter)
        {
            //tamamı
            if (EnumState == "" && UserFilter == "" || EnumState == "0" && UserFilter == "")
            {
                return RedirectToAction("ServisFormlarım", "Admin");
            }

            //duruma göre hepsi.. Yeni ürünler
            else if (UserFilter == "" && EnumState != "")
            {
                var x = db.SRFs.Where(w => w.Active == true).OrderByDescending(w => w.SRFDatetime).ToList();
                foreach (var item in x)
                {
                    var y = db.Customers.Where(w => w.Id == item.CustomerId).FirstOrDefault();
                    if (y != null)
                    {
                        item.customer.Id = y.Id;
                        item.customer.UserName = y.UserName;
                        item.customer.Email = y.Email;
                        item.customer.Phone = y.Phone;
                    }
                    var z = db.Products.Where(w => w.Id == item.ProductId).FirstOrDefault();
                    if (z != null)
                    {
                        item.product.Id = z.Id;
                        item.product.ProductType = z.ProductType;
                        item.product.PBrand = z.PBrand;
                        item.product.PModel = z.PModel;
                        item.product.PBatterySerialNumber = z.PBatterySerialNumber;
                        item.product.PSerialNumber = z.PSerialNumber;
                        item.product.Ekparcalar = z.Ekparcalar;
                        item.product.PFaultrecord = z.PFaultrecord;
                        item.product.PFaultpersonel = z.PFaultpersonel;
                    }
                }
                var filterstate = "";
                if (EnumState == "1")
                {
                    filterstate = "YENİ ÜRÜN";
                }
                else if (EnumState == "2")
                {
                    filterstate = "İŞLEMDE";
                }
                else if (EnumState == "3")
                {
                    filterstate = "FİYAT VERİLECEK";
                }
                else if (EnumState == "4")
                {
                    filterstate = "TESLİM EDİLDİ";
                }
                else if (EnumState == "5")
                {
                    filterstate = "İADE";
                }
                else if (EnumState == "6")
                {
                    filterstate = "TEST AŞAMASINDA";
                }
                else if (EnumState == "7")
                {
                    filterstate = "ONAY BEKLİYOR";
                }
                else if (EnumState == "8")
                {
                    filterstate = "ONAYLANDI";
                }
                else if (EnumState == "9")
                {
                    filterstate = "TAMİR EDİLDİ";
                }
                else if (EnumState == "10")
                {
                    filterstate = "PARÇA BEKLİYOR";
                }
                else if (EnumState == "11")
                {
                    filterstate = "DIŞ SERVİSTE";
                }
                else if (EnumState == "12")
                {
                    filterstate = "İKİNCİ GELİŞ";
                }
                else if (EnumState == "13")
                {
                    filterstate = "TAMAMLANDI";
                }

                var p = x.Where(w => w.SFRState.GetProductState() == filterstate).OrderByDescending(w => w.SRFDatetime).ToList();

                FilterModel filter = new FilterModel();
                filter.ServiceRegistrationForm = p;
                filter.Suppliers = db.Suppliers.ToList();
                filter.TransferUserS = db.Users.ToList();
                return View("ServisFormlarım", filter);
            }


            //kişiye göre
            else if (UserFilter != "" && EnumState == "" || UserFilter != "" && EnumState == "0")
            {
                var FilteruserNAME = (db.Users.Find(UserFilter)).UserName;

                var x = db.SRFs.Where(w => w.Active == true).ToList();
                foreach (var item in x)
                {
                    var y = db.Customers.Where(w => w.Id == item.CustomerId).FirstOrDefault();
                    if (y != null)
                    {
                        item.customer.Id = y.Id;
                        item.customer.UserName = y.UserName;
                        item.customer.Email = y.Email;
                        item.customer.Phone = y.Phone;
                    }
                    var z = db.Products.Where(w => w.Id == item.ProductId).FirstOrDefault();
                    if (z != null)
                    {
                        item.product.Id = z.Id;
                        item.product.ProductType = z.ProductType;
                        item.product.PBrand = z.PBrand;
                        item.product.PModel = z.PModel;
                        item.product.PSerialNumber = z.PSerialNumber;
                        item.product.PBatterySerialNumber = z.PBatterySerialNumber;
                        item.product.Ekparcalar = z.Ekparcalar;
                        item.product.PFaultrecord = z.PFaultrecord;
                        item.product.PFaultpersonel = z.PFaultpersonel;
                    }
                }
                var filterstate = "";
                if (EnumState == "1")
                {
                    filterstate = "YENİ ÜRÜN";
                }
                else if (EnumState == "2")
                {
                    filterstate = "İŞLEMDE";
                }
                else if (EnumState == "3")
                {
                    filterstate = "FİYAT VERİLECEK";
                }
                else if (EnumState == "4")
                {
                    filterstate = "TESLİM EDİLDİ";
                }
                else if (EnumState == "5")
                {
                    filterstate = "İADE";
                }
                else if (EnumState == "6")
                {
                    filterstate = "TEST AŞAMASINDA";
                }
                else if (EnumState == "7")
                {
                    filterstate = "ONAY BEKLİYOR";
                }
                else if (EnumState == "8")
                {
                    filterstate = "ONAYLANDI";
                }
                else if (EnumState == "9")
                {
                    filterstate = "TAMİR EDİLDİ";
                }
                else if (EnumState == "10")
                {
                    filterstate = "PARÇA BEKLİYOR";
                }
                else if (EnumState == "11")
                {
                    filterstate = "DIŞ SERVİSTE";
                }
                else if (EnumState == "12")
                {
                    filterstate = "İKİNCİ GELİŞ";
                }
                else if (EnumState == "13")
                {
                    filterstate = "TAMAMLANDI";
                }
                var p = x.Where(w => w.KimeAit == FilteruserNAME || w.KimeDevretti == FilteruserNAME).OrderByDescending(w => w.SRFDatetime).ToList();
                FilterModel filter = new FilterModel();
                filter.ServiceRegistrationForm = p;
                filter.Suppliers = db.Suppliers.ToList();
                filter.TransferUserS = db.Users.ToList();
                return View("ServisFormlarım", filter);

            }

            //kişi ve duruma göre
            else if (UserFilter != "" && EnumState != "" || UserFilter != "" && EnumState != "0")
            {
                var FilteruserNAME = (db.Users.Find(UserFilter)).UserName;

                var x = db.SRFs.Where(w => w.Active == true).ToList();
                foreach (var item in x)
                {
                    var y = db.Customers.Where(w => w.Id == item.CustomerId).FirstOrDefault();
                    if (y != null)
                    {
                        item.customer.Id = y.Id;
                        item.customer.UserName = y.UserName;
                        item.customer.Email = y.Email;
                        item.customer.Phone = y.Phone;
                    }
                    var z = db.Products.Where(w => w.Id == item.ProductId).FirstOrDefault();
                    if (z != null)
                    {
                        item.product.Id = z.Id;
                        item.product.ProductType = z.ProductType;
                        item.product.PBrand = z.PBrand;
                        item.product.PModel = z.PModel;
                        item.product.PSerialNumber = z.PSerialNumber;
                        item.product.PBatterySerialNumber = z.PBatterySerialNumber;
                        item.product.Ekparcalar = z.Ekparcalar;
                        item.product.PFaultrecord = z.PFaultrecord;
                        item.product.PFaultpersonel = z.PFaultpersonel;
                    }
                }
                var filterstate = "";
                if (EnumState == "1")
                {
                    filterstate = "YENİ ÜRÜN";
                }
                else if (EnumState == "2")
                {
                    filterstate = "İŞLEMDE";
                }
                else if (EnumState == "3")
                {
                    filterstate = "FİYAT VERİLECEK";
                }
                else if (EnumState == "4")
                {
                    filterstate = "TESLİM EDİLDİ";
                }
                else if (EnumState == "5")
                {
                    filterstate = "İADE";
                }
                else if (EnumState == "6")
                {
                    filterstate = "TEST AŞAMASINDA";
                }
                else if (EnumState == "7")
                {
                    filterstate = "ONAY BEKLİYOR";
                }
                else if (EnumState == "8")
                {
                    filterstate = "ONAYLANDI";
                }
                else if (EnumState == "9")
                {
                    filterstate = "TAMİR EDİLDİ";
                }
                else if (EnumState == "10")
                {
                    filterstate = "PARÇA BEKLİYOR";
                }
                else if (EnumState == "11")
                {
                    filterstate = "DIŞ SERVİSTE";
                }
                else if (EnumState == "12")
                {
                    filterstate = "İKİNCİ GELİŞ";
                }
                else if (EnumState == "13")
                {
                    filterstate = "TAMAMLANDI";
                }
                var p = x.Where(w => w.SFRState.GetProductState() == filterstate && w.KimeAit == FilteruserNAME || w.SFRState.GetProductState() == filterstate && w.KimeDevretti == FilteruserNAME).OrderByDescending(w => w.SRFDatetime).ToList();
                FilterModel filter = new FilterModel();
                filter.ServiceRegistrationForm = p;
                filter.Suppliers = db.Suppliers.ToList();
                filter.TransferUserS = db.Users.ToList();
                return View("ServisFormlarım", filter);

            }

            else
            {
                return RedirectToAction("ServisFormlarım", "Admin");
            }
        }

        //Form Kayıt
        public ActionResult ServisFormuKayıt2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ServisFormuKayıt2(ServiceRegistrationForm model)
        {
            var SRF = new ServiceRegistrationForm
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                ProductId = model.ProductId,
                SellproductId = model.SellproductId,
                Price = model.Price,
                SFRState = EnumProductState.SFRNew,
                SupplierName = "CNH",
                SRFDatetime = DateTime.Now,
                SRFArrivalDatetime = DateTime.Now,
                Active = true,
                PaymentCheck = false,
                SRFWhoUser = false,
                KimeAit = "CNH",
                SRFDevrettiUser = false,
                KimeDevretti = ".",
                KimeDevrettiControl = ".",
                customer = new Customer
                {
                    Id = model.customer.Id,
                    UserName = model.customer.UserName,
                    Email = model.customer.Email,
                    Phone = model.customer.Phone,
                },
                product = new Product
                {
                    Id = model.product.Id,
                    ProductType = model.product.ProductType,
                    PBrand = model.product.PBrand,
                    PModel = model.product.PModel,
                    PSerialNumber = model.product.PSerialNumber,
                    PBatterySerialNumber = model.product.PBatterySerialNumber,
                    PBattery = model.product.PBattery,
                    PChanger = model.product.PChanger,
                    PFaultrecord = model.product.PFaultrecord,
                    PFaultpersonel = model.product.PFaultpersonel,
                    Ekparcalar = model.product.Ekparcalar,

                },
                sellproduct = new Sellproduct
                {
                    Id = model.sellproduct.Id,
                },
            };
            //var sssss = db.SRFs.FirstOrDefault(w=>w.product.PSerialNumber == SRF.product.PSerialNumber);
            //if (sssss==null)
            //{
            db.SRFs.Add(SRF);
            db.SaveChanges();
            //}
            //else
            //{
            //    SRF.SFRState = EnumProductState.SFRSecond;
            //    db.SRFs.Add(SRF);
            //    db.SaveChanges();
            //}

            TechnicalServiceLog TSLog = new TechnicalServiceLog()
            {
                LogWho = User.Identity.Name,
                LogDescription = "KAYIT İŞLEMİ.",
                LogDatetime = DateTime.Now,
                ServiceRegistrationFormID = SRF.Id,
                LogWhichCustomer = SRF.customer.UserName,
            };
            db.TSLogs.Add(TSLog);
            db.SaveChanges();

            return RedirectToAction("SRFPrint", SRF);
        }

        public ActionResult SRFKAYITPOST(ServiceRegistrationForm model)
        {
            var x = db.SRFs.FirstOrDefault(w => w.customer.UserName == model.customer.UserName);
            ServiceRegistrationForm SRF = new ServiceRegistrationForm()
            {
                customer = db.Customers.FirstOrDefault(w => w.Id == x.CustomerId),
            };

            return View(SRF);
        }

        //Yazıcı
        public ActionResult SRFPrint(ServiceRegistrationForm srf)
        {
            Product product = db.Products.Where(i => i.Id == srf.ProductId).FirstOrDefault();
            Customer customer = db.Customers.Where(i => i.Id == srf.CustomerId).FirstOrDefault();

            var SRF = new ServiceRegistrationForm
            {
                Id = srf.Id,
                CustomerId = srf.CustomerId,
                ProductId = srf.ProductId,
                customer = new Customer
                {
                    Id = customer.Id,
                    UserName = customer.UserName,
                    Email = customer.Email,
                    Phone = customer.Phone,
                },
                product = new Product
                {
                    Id = product.Id,
                    ProductType = product.ProductType,
                    PBrand = product.PBrand,
                    PModel = product.PModel,
                    PChanger = product.PChanger,
                    PFaultpersonel = product.PFaultpersonel,
                    PSerialNumber = product.PSerialNumber,
                    PBatterySerialNumber = product.PBatterySerialNumber,
                    PBattery = product.PBattery,
                    PFaultrecord = product.PFaultrecord,
                    Ekparcalar = product.Ekparcalar
                }
            };
            return View(SRF);
        }

        //Tamire al
        public ActionResult SRFEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRegistrationForm SRF = db.SRFs.Find(id);
            SRF.product = db.Products.FirstOrDefault(w => w.Id == SRF.ProductId);
            SRF.customer = db.Customers.FirstOrDefault(w => w.Id == SRF.CustomerId);
            SRF.sellproduct = db.Sellproducts.FirstOrDefault(w => w.Id == SRF.SellproductId);

            SRF.Suppliers = db.Suppliers.ToList();
            SRF.Sproducts = db.Sellproducts.Where(w => (w.Stock) > 0).ToList();

            //db.TSLogs.OrderByDescending(w => w.LogDatetime).ToList()
            SRF.TLogs = db.TSLogs.Where(w => w.ServiceRegistrationFormID == id).OrderByDescending(w => w.LogDatetime).ToList();

            //var allUsers = db.Users.ToList();
            SRF.TransferUserS = db.Users.ToList();
            //SelectList list = new SelectList(SRF.ApplicationUsers);
            //ViewBag.Users = list;   
            SRF.SRFDevrettiUser = false;
            if (SRF == null)
            {
                return HttpNotFound();
            }
            return View(SRF);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SRFEdit(ServiceRegistrationForm SRF)
        {

            //kaydete basan ilk kişiye ürünün sorumlulugunu atamaak için
            if (SRF.SRFWhoUser == false)
            {
                SRF.SRFWhoUser = true;
                SRF.KimeAit = User.Identity.Name;
            }
            //chexbox true ise devret işlemi
            if (SRF.SRFDevrettiUser == true)
            {
                var kimedevretti = db.Users.Find(SRF.KimeDevrettiControl);
                SRF.KimeDevretti = kimedevretti.UserName;
            }

            SRF.SRFDatetime = DateTime.Now;
            var xxxxxxxxx = SRF.customer;
            db.Entry(xxxxxxxxx).State = EntityState.Modified;
            db.SaveChanges();
            Suppliers suppliers = db.Suppliers.FirstOrDefault(w => w.Id == SRF.SuppliersId);
            if (SRF.SFRState == EnumProductState.Suppliers && suppliers.Name != "CNH")
            {
                SRF.Supplier = suppliers;

                SRF.SFRState = EnumProductState.Suppliers;
                db.Entry(SRF).State = EntityState.Modified;
                db.SaveChanges();

                var m = SRF.sellproduct;
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();

                TechnicalServiceLog TSLog = new TechnicalServiceLog()
                {
                    LogWho = User.Identity.Name,
                    LogDescription = SRF.SFRState.GetProductState(),
                    LogDatetime = DateTime.Now,
                    ServiceRegistrationFormID = SRF.Id,
                    LogWhichCustomer = SRF.customer.UserName,
                };
                db.TSLogs.Add(TSLog);
                db.SaveChanges();
            }
            else if (SRF.sellproduct.SNumber > 0 && SRF.SFRState == EnumProductState.Repair)
            {
                var y = db.Sellproducts.FirstOrDefault(w => (w.Id).ToString() == SRF.sellproduct.SName);
                if (y.Stock < SRF.sellproduct.SNumber)
                {
                    SRF.SFRState = EnumProductState.Item;

                    db.Entry(SRF).State = EntityState.Modified;
                    db.SaveChanges();

                    TechnicalServiceLog TSLog = new TechnicalServiceLog()
                    {
                        LogWho = User.Identity.Name,
                        LogDescription = SRF.SFRState.GetProductState(),
                        LogDatetime = DateTime.Now,
                        ServiceRegistrationFormID = SRF.Id,
                        LogWhichCustomer = SRF.customer.UserName,
                    };
                    db.TSLogs.Add(TSLog);
                    db.SaveChanges();
                }
                else
                {


                    db.Entry(SRF).State = EntityState.Modified;
                    db.SaveChanges();

                    y.Stock = y.Stock - SRF.sellproduct.SNumber;
                    db.Entry(y).State = EntityState.Modified;
                    db.SaveChanges();

                    var z = SRF.sellproduct;
                    db.Entry(z).State = EntityState.Modified;
                    db.SaveChanges();

                    TechnicalServiceLog TSLog = new TechnicalServiceLog()
                    {
                        LogWho = User.Identity.Name,
                        LogDescription = SRF.SFRState.GetProductState(),
                        LogDatetime = DateTime.Now,
                        ServiceRegistrationFormID = SRF.Id,
                        LogWhichCustomer = SRF.customer.UserName,
                    };
                    db.TSLogs.Add(TSLog);
                    db.SaveChanges();
                }
            }
            else
            {

                db.Entry(SRF).State = EntityState.Modified;
                db.SaveChanges();

                var z = SRF.sellproduct;
                db.Entry(z).State = EntityState.Modified;
                db.SaveChanges();

                TechnicalServiceLog TSLog = new TechnicalServiceLog()
                {
                    LogWho = User.Identity.Name,
                    LogDescription = SRF.SFRState.GetProductState(),
                    LogDatetime = DateTime.Now,
                    ServiceRegistrationFormID = SRF.Id,
                    LogWhichCustomer = SRF.customer.UserName,
                };
                db.TSLogs.Add(TSLog);
                db.SaveChanges();
            }

            //if (SRF.SFRState == EnumProductState.Repair)
            //{
            //    Bank bank = new Bank()
            //    {
            //        UserName = SRF.customer.UserName,
            //        Payment = SRF.Price,
            //        WhoUser = User.Identity.Name,
            //        BankDescription = "",
            //        BankTime = DateTime.Now,
            //    };
            //    db.Banks.Add(bank);
            //    db.SaveChanges();
            //}
            return RedirectToAction("ServisFormlarım");

        }

        //Kasa
        public ActionResult IncomeExpensePage()
        {
            var x = db.SRFs.ToList();
            foreach (var item in x)
            {
                var y = db.Customers.Where(w => w.Id == item.CustomerId).FirstOrDefault();
                if (y != null)
                {
                    item.customer.Id = y.Id;
                    item.customer.UserName = y.UserName;
                    item.customer.Email = y.Email;
                    item.customer.Phone = y.Phone;
                }
                var z = db.Products.Where(w => w.Id == item.ProductId).FirstOrDefault();
                if (z != null)
                {
                    item.product.Id = z.Id;
                    item.product.ProductType = z.ProductType;
                    item.product.PBrand = z.PBrand;
                    item.product.PModel = z.PModel;
                    item.product.PSerialNumber = z.PSerialNumber;
                    item.product.PBatterySerialNumber = z.PBatterySerialNumber;
                    item.product.Ekparcalar = z.Ekparcalar;
                    item.product.PFaultrecord = z.PFaultrecord;
                    item.product.PFaultpersonel = z.PFaultpersonel;
                }
            }
            //active==true ekledim sili kaldırdım
            return View(x.Where(w => w.Price > 0 && w.Active == true).OrderByDescending(w => w.SRFDatetime).ToList());
        }

        public ActionResult IncomeExpensePagePost(int id)
        {
            ServiceRegistrationForm SRF = db.SRFs.Find(id);
            SRF.product = db.Products.FirstOrDefault(w => w.Id == SRF.ProductId);
            SRF.customer = db.Customers.FirstOrDefault(w => w.Id == SRF.CustomerId);
            SRF.sellproduct = db.Sellproducts.FirstOrDefault(w => w.Id == SRF.SellproductId);
            if (SRF.PaymentCheck == true)
            {
                SRF.PaymentCheck = false;
            }
            else
            {
                SRF.PaymentCheck = true;
            }

            SRF.TLogs = db.TSLogs.Where(w => w.ServiceRegistrationFormID == id).OrderByDescending(w => w.LogDatetime).ToList();
            db.Entry(SRF).State = EntityState.Modified;
            db.SaveChanges();
            TechnicalServiceLog TSLog = new TechnicalServiceLog()
            {
                LogWho = User.Identity.Name,
                LogDescription = "ÖDEME İŞLEMİ GERÇEKLEŞTİ",
                LogDatetime = DateTime.Now,
                LogWhichCustomer = SRF.customer.UserName,
            };
            db.TSLogs.Add(TSLog);
            db.SaveChanges();
            return RedirectToAction("IncomeExpensePage");
        }

        //Helper Kayıtta Yeni Marka Kontrolü
        [HttpGet]
        public JsonResult GetSearchBrandValue(string search)
        {
            List<ProductBrandModel> allsearch = db.Products.Where(x => x.PBrand.StartsWith(search)).Select(w => new ProductBrandModel
            {
                Id = w.Id,
                PBrand = w.PBrand
            }).ToList();

            var myList = new List<string>();
            foreach (var item in allsearch)
            {
                foreach (var item2 in myList)
                {
                    if (item2 == item.PBrand)
                    {
                        item.PBrand = null;
                    }
                }
                myList.Add(item.PBrand);
            }

            var y = allsearch.Where(w => w.PBrand != null).ToList();

            if (allsearch.Count() == 0)
            {
                return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = y, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        //Helper Kayıtta Yeni Model Kontrolü
        [HttpGet]
        public JsonResult GetSearchModelValue(string search)
        {
            List<ProductModelModel> allsearch = db.Products.Where(x => x.PModel.StartsWith(search)).Select(w => new ProductModelModel
            {
                Id = w.Id,
                PModel = w.PModel
            }).ToList();

            var myList = new List<string>();
            foreach (var item in allsearch)
            {
                foreach (var item2 in myList)
                {
                    if (item2 == item.PModel)
                    {
                        item.PModel = null;
                    }
                }
                myList.Add(item.PModel);
            }

            var y = allsearch.Where(w => w.PModel != null).ToList();

            if (allsearch.Count() == 0)
            {
                return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = y, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public JsonResult GetSearchUsernameValue(string search)
        {
            List<CustomerUsernameModel> allsearch = db.Customers.Where(x => x.UserName.StartsWith(search)).Select(w => new CustomerUsernameModel
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

        public ActionResult SRFDelete(int id)
        {
            ServiceRegistrationForm SRF = db.SRFs.Find(id);
            SRF.product = db.Products.FirstOrDefault(w => w.Id == SRF.ProductId);
            SRF.customer = db.Customers.FirstOrDefault(w => w.Id == SRF.CustomerId);
            SRF.sellproduct = db.Sellproducts.FirstOrDefault(w => w.Id == SRF.SellproductId);
            SRF.Active = false;
            SRF.TLogs = db.TSLogs.Where(w => w.ServiceRegistrationFormID == id).OrderByDescending(w => w.LogDatetime).ToList();
            db.Entry(SRF).State = EntityState.Modified;
            db.SaveChanges();
            TechnicalServiceLog TSLog = new TechnicalServiceLog()
            {
                LogWho = User.Identity.Name,
                LogDescription = "Silme işlemi.",
                LogDatetime = DateTime.Now,
            };
            db.TSLogs.Add(TSLog);
            db.SaveChanges();
            return RedirectToAction("ServisFormlarım");
        }

        //[HttpGet]
        //public ActionResult LogTechnicalServiceLog()
        //{
        //    return View(db.TSLogs.OrderByDescending(w => w.LogDatetime).ToList());
        //}

    }
}
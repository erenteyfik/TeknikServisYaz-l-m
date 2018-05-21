using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeknikServisYazılım;
using TeknikServisYazılım.Entity;

namespace TeknikServisYazılım.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SupplierPaymentController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index(int id)
        {
            return View(db.SupplierPaymentLists.Where(i=>i.SupplierId == id).ToList());
        }

        public ActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Income,Expense,Description")] SupplierPaymentList supplierPaymentList,int id)
        {
            if (ModelState.IsValid)
            {
                supplierPaymentList.SupplierDate = DateTime.Now;
                supplierPaymentList.SupplierId = id;
                db.SupplierPaymentLists.Add(supplierPaymentList);
                db.SaveChanges();
                return RedirectToAction("Index", "Supplier");
            }

            return View(supplierPaymentList);
        }

        public ActionResult DeleteConfirmed(int id)
        {
            
            SupplierPaymentList supplierPaymentList = db.SupplierPaymentLists.Find(id);
            var y = supplierPaymentList.SupplierId;
            db.SupplierPaymentLists.Remove(supplierPaymentList);
            db.SaveChanges();
            return RedirectToAction("Index", "SupplierPayment", new { id=y });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

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
    public class ProductSellController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ProductSell
        public ActionResult Index()
        {
            return View(db.Sellproducts.Where(w => (w.Stock) > 0).ToList());
        }

        // GET: ProductSell/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sellproduct sellproduct = db.Sellproducts.Find(id);
            if (sellproduct == null)
            {
                return HttpNotFound();
            }
            return View(sellproduct);
        }

        // GET: ProductSell/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductSell/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SName,SBrand,SModel,Description,SNumber,Stock,Price")] Sellproduct sellproduct)
        {
            if (ModelState.IsValid)
            {
                db.Sellproducts.Add(sellproduct);
                db.SaveChanges();
                TechnicalServiceLog TSLog = new TechnicalServiceLog()
                {
                    LogWho = User.Identity.Name,
                    LogDescription = "Ürün ekledi",
                    LogDatetime = DateTime.Now.ToLocalTime(),
                };
                db.TSLogs.Add(TSLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sellproduct);
        }

        // GET: ProductSell/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sellproduct sellproduct = db.Sellproducts.Find(id);
            if (sellproduct == null)
            {
                return HttpNotFound();
            }
            return View(sellproduct);
        }

        // POST: ProductSell/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SName,SBrand,SModel,Description,SNumber,Stock,Price")] Sellproduct sellproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sellproduct);
        }

        public ActionResult Sell(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sellproduct sellproduct = db.Sellproducts.Find(id);
            if (sellproduct == null)
            {
                return HttpNotFound();
            }
            return View(sellproduct);
        }

        [HttpPost]
        public ActionResult Sell(Sellproduct sellproduct)
        {
            if (ModelState.IsValid)
            {
                if (sellproduct.Stock <= 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    Sellproduct product = db.Sellproducts.Find(sellproduct.Id);
                    product.Stock = (product.Stock) - (sellproduct.SNumber);
                    product.SNumber = 0;
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(sellproduct);
        }

        // GET: ProductSell/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sellproduct sellproduct = db.Sellproducts.Find(id);
            if (sellproduct == null)
            {
                return HttpNotFound();
            }
            return View(sellproduct);
        }

        // POST: ProductSell/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sellproduct sellproduct = db.Sellproducts.Find(id);
            db.Sellproducts.Remove(sellproduct);
            db.SaveChanges();
            return RedirectToAction("Index");
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

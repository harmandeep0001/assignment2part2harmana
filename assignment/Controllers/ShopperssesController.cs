using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using assignment.Models;

namespace assignment.Controllers
{
    public class ShopperssesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Shoppersses
        public ActionResult Index()
        {
            var shoppersses = db.Shoppersses.Include(s => s.Shopper);
            return View(shoppersses.ToList());
        }

        // GET: Shoppersses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopperss shopperss = db.Shoppersses.Find(id);
            if (shopperss == null)
            {
                return HttpNotFound();
            }
            return View(shopperss);
        }

        // GET: Shoppersses/Create
        public ActionResult Create()
        {
            ViewBag.Price = new SelectList(db.Shoppers, "Stock", "Products");
            return View();
        }

        // POST: Shoppersses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Price,Stock,Staff,Accessories")] Shopperss shopperss)
        {
            if (ModelState.IsValid)
            {
                db.Shoppersses.Add(shopperss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Price = new SelectList(db.Shoppers, "Stock", "Products", shopperss.Price);
            return View(shopperss);
        }

        // GET: Shoppersses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopperss shopperss = db.Shoppersses.Find(id);
            if (shopperss == null)
            {
                return HttpNotFound();
            }
            ViewBag.Price = new SelectList(db.Shoppers, "Stock", "Products", shopperss.Price);
            return View(shopperss);
        }

        // POST: Shoppersses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Price,Stock,Staff,Accessories")] Shopperss shopperss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopperss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Price = new SelectList(db.Shoppers, "Stock", "Products", shopperss.Price);
            return View(shopperss);
        }

        // GET: Shoppersses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopperss shopperss = db.Shoppersses.Find(id);
            if (shopperss == null)
            {
                return HttpNotFound();
            }
            return View(shopperss);
        }

        // POST: Shoppersses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shopperss shopperss = db.Shoppersses.Find(id);
            db.Shoppersses.Remove(shopperss);
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

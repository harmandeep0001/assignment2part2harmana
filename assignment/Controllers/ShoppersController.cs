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
    [Authorize]
    public class ShoppersController : Controller
    {
        //private Model1 db = new Model1();
        private IShoppersMock db;

        public ShoppersController()
        {
            this.db = new EFShoppers();
        }

        // mock constructor
        public ShoppersController(IShoppersMock mock)
        {
            this.db = mock;
        }

        // GET: Shoppers
        public ActionResult Index()
        {
            var shoppers = db.Shoppers.Include(s => s.Shopperss);
            return View(shoppers.ToList());
        }

        //// GET: Shoppers/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");

            }
            //  Shopper shopper = db.Shoppers.Find(id);
            Shopper shopper = db.Shoppers.SingleOrDefault(a => a.Stock == id);

            if (shopper == null)

            {
                //return HttpNotFound();
                return View("Error");

            }
            return View("Details",shopper);
        }

        //// GET: Shoppers/Create
        public ActionResult Create()
        {
            ViewBag.Stock = new SelectList(db.Shoppers, "Price", "Stock");
            return View();
        }

        //// POST: Shoppers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stock,Products,Food,Medicine")] Shopper shopper)
        {
            if (ModelState.IsValid)
            {
                //db.Shoppers.Add(shopper);
                //db.SaveChanges();
                db.Save(shopper);
                return RedirectToAction("Index");
            }


    ViewBag.Stock = new SelectList(db.Shoppers, "Price", "Stock", shopper.Stock);
                return View("Create",shopper);
}

        //// GET: Shoppers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //Shopper shopper = db.Shoppers.Find(id);
            Shopper shopper = db.Shoppers.SingleOrDefault(a => a.Stock == id);

            if (shopper == null)
            {
                // return HttpNotFound();
                return View("Error");


            }
            ViewBag.Stock = new SelectList(db.Shoppers, "Price", "Stock", shopper.Stock);
            return View("Edit",shopper);
        }

        //// POST: Shoppers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stock,Products,Food,Medicine")] Shopper shopper)
        {
            if (ModelState.IsValid)
            {
                if (Request != null)
                {
                    // upload image if any
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];

                        if (file.FileName != null && file.ContentLength > 0)
                        {
                            // save file path
                            string path = Server.MapPath("~/Content/Images/") + file.FileName;

                            // save actual file
                            file.SaveAs(path);

                        }
                    }
                }
                //  db.Entry(shopper).State = EntityState.Modified;
                //  db.SaveChanges();
                db.Save(shopper);
                return RedirectToAction("Index");
            }
            ViewBag.Stock = new SelectList(db.Shoppers, "Price", "Stock", shopper.Stock);
            return View("Edit",shopper);
        }

        //// GET: Shoppers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");

            }
            //Shopper shopper = db.Shoppers.Find(id);
            Shopper shopper = db.Shoppers.SingleOrDefault(a => a.Stock == id);

            if (shopper == null)
            {
                // return HttpNotFound();
                return View("Error");

            }
            return View("Delete",shopper);
        }

        //// POST: Shoppers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Shopper shopper = db.Shoppers.Find(id);
            Shopper shopper = db.Shoppers.SingleOrDefault(a => a.Stock == id);

            // db.Shoppers.Remove(shopper);
            db.Delete(shopper);
            if (id == null)
            {
                return View("Error");
            }

            if (shopper == null)
            {
                return View("Error");
            }
            else
            {

                return RedirectToAction("Index");
            }
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

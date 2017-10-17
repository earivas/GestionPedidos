using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionPedidos.Models;

namespace GestionPedidos.Controllers
{
    public class PriceListDetailsController : Controller
    {
        private GestionPedidosContext db = new GestionPedidosContext();

        // GET: PriceListDetails
        public ActionResult Index()
        {
            var priceListDetails = db.PriceListDetails.Include(p => p.PriceListMasters).Include(p => p.Products);
            return View(priceListDetails.ToList());
        }

        // GET: PriceListDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceListDetail priceListDetail = db.PriceListDetails.Find(id);
            if (priceListDetail == null)
            {
                return HttpNotFound();
            }
            return View(priceListDetail);
        }

        // GET: PriceListDetails/Create
        public ActionResult Create()
        {
            ViewBag.PriceListID = new SelectList(db.PriceListMasters, "PriceListID", "PriceListName");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductReference");
            return View();
        }

        // POST: PriceListDetails/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionID,PriceListID,ProductID,UnitPrice,Status")] PriceListDetail priceListDetail)
        {
            if (ModelState.IsValid)
            {
                db.PriceListDetails.Add(priceListDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PriceListID = new SelectList(db.PriceListMasters, "PriceListID", "PriceListName", priceListDetail.PriceListID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductReference", priceListDetail.ProductID);
            return View(priceListDetail);
        }

        // GET: PriceListDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceListDetail priceListDetail = db.PriceListDetails.Find(id);
            if (priceListDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.PriceListID = new SelectList(db.PriceListMasters, "PriceListID", "PriceListName", priceListDetail.PriceListID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductReference", priceListDetail.ProductID);
            return View(priceListDetail);
        }

        // POST: PriceListDetails/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionID,PriceListID,ProductID,UnitPrice,Status")] PriceListDetail priceListDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priceListDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PriceListID = new SelectList(db.PriceListMasters, "PriceListID", "PriceListName", priceListDetail.PriceListID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductReference", priceListDetail.ProductID);
            return View(priceListDetail);
        }

        // GET: PriceListDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceListDetail priceListDetail = db.PriceListDetails.Find(id);
            if (priceListDetail == null)
            {
                return HttpNotFound();
            }
            return View(priceListDetail);
        }

        // POST: PriceListDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PriceListDetail priceListDetail = db.PriceListDetails.Find(id);
            db.PriceListDetails.Remove(priceListDetail);
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

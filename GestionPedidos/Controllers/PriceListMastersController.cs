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
    public class PriceListMastersController : Controller
    {
        private GestionPedidosContext db = new GestionPedidosContext();

        // GET: PriceListMasters
        public ActionResult Index()
        {
            return View(db.PriceListMasters.ToList());
        }

        // GET: PriceListMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceListMaster priceListMaster = db.PriceListMasters.Find(id);
            if (priceListMaster == null)
            {
                return HttpNotFound();
            }
            return View(priceListMaster);
        }

        // GET: PriceListMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PriceListMasters/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PriceListID,PriceListName,PriceListDateActivation,PriceListFinishDate,CreationDate,CreateBy,ModifiedDate,ModifiedBy,Status")] PriceListMaster priceListMaster)
        {
            if (ModelState.IsValid)
            {
                db.PriceListMasters.Add(priceListMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(priceListMaster);
        }

        // GET: PriceListMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceListMaster priceListMaster = db.PriceListMasters.Find(id);
            if (priceListMaster == null)
            {
                return HttpNotFound();
            }
            return View(priceListMaster);
        }

        // POST: PriceListMasters/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PriceListID,PriceListName,PriceListDateActivation,PriceListFinishDate,CreationDate,CreateBy,ModifiedDate,ModifiedBy,Status")] PriceListMaster priceListMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priceListMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(priceListMaster);
        }

        // GET: PriceListMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceListMaster priceListMaster = db.PriceListMasters.Find(id);
            if (priceListMaster == null)
            {
                return HttpNotFound();
            }
            return View(priceListMaster);
        }

        // POST: PriceListMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PriceListMaster priceListMaster = db.PriceListMasters.Find(id);
            db.PriceListMasters.Remove(priceListMaster);
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

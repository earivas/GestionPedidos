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
    public class BonifiedsController : Controller
    {
        private GestionPedidosContext db = new GestionPedidosContext();

        // GET: Bonifieds
        public ActionResult Index()
        {
            var bonifieds = db.Bonifieds.Include(b => b.Customers).Include(b => b.Products);
            return View(bonifieds.ToList());
        }

        // GET: Bonifieds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonified bonified = db.Bonifieds.Find(id);
            if (bonified == null)
            {
                return HttpNotFound();
            }
            return View(bonified);
        }

        // GET: Bonifieds/Create
        public ActionResult Create()
        {
            var d = new Bonified();
            d.CreationDate = DateTime.Now;
            d.CreateBy = "UserCreator"; // Asignar usuario Activo
            d.ModifiedDate = DateTime.Now;
            d.ModifiedBy = "UserModified"; // Asignar usuario Activo

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerCode");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductReference");
            return View(d);
        }

        // POST: Bonifieds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BonifiedID,CustomerID,ProductID,MinimunOrderQty,BonifiedQty,status,BonifiedActivationDate,BonifiedFinishDate,CreationDate,CreateBy,ModifiedDate,ModifiedBy")] Bonified bonified)
        {
            if (ModelState.IsValid)
            {
                db.Bonifieds.Add(bonified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerCode", bonified.CustomerID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductReference", bonified.ProductID);
            return View(bonified);
        }

        // GET: Bonifieds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonified bonified = db.Bonifieds.Find(id);
            if (bonified == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerCode", bonified.CustomerID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductReference", bonified.ProductID);
            return View(bonified);
        }

        // POST: Bonifieds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BonifiedID,CustomerID,ProductID,MinimunOrderQty,BonifiedQty,status,BonifiedActivationDate,BonifiedFinishDate,CreationDate,CreateBy,ModifiedDate,ModifiedBy")] Bonified bonified)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bonified).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerCode", bonified.CustomerID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductReference", bonified.ProductID);
            return View(bonified);
        }

        // GET: Bonifieds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonified bonified = db.Bonifieds.Find(id);
            if (bonified == null)
            {
                return HttpNotFound();
            }
            return View(bonified);
        }

        // POST: Bonifieds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bonified bonified = db.Bonifieds.Find(id);
            db.Bonifieds.Remove(bonified);
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

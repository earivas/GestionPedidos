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
    public class SalesMenController : Controller
    {
        private GestionPedidosContext db = new GestionPedidosContext();

        // GET: SalesMen
        public ActionResult Index()
        {
            return View(db.SalesMen.ToList());
        }

        // GET: SalesMen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesMan salesMan = db.SalesMen.Find(id);
            if (salesMan == null)
            {
                return HttpNotFound();
            }
            return View(salesMan);
        }

        // GET: SalesMen/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: SalesMen/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesManID,SalesManCode,SalesManName")] SalesMan salesMan)
        {
            if (ModelState.IsValid)
            {
                db.SalesMen.Add(salesMan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesMan);
        }

        // GET: SalesMen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesMan salesMan = db.SalesMen.Find(id);
            if (salesMan == null)
            {
                return HttpNotFound();
            }
            return View(salesMan);
        }

        // POST: SalesMen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesManID,SalesManCode,SalesManName")] SalesMan salesMan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesMan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesMan);
        }

        // GET: SalesMen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesMan salesMan = db.SalesMen.Find(id);
            if (salesMan == null)
            {
                return HttpNotFound();
            }
            return View(salesMan);
        }

        // POST: SalesMen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesMan salesMan = db.SalesMen.Find(id);
            db.SalesMen.Remove(salesMan);
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

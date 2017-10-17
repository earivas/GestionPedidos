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
    public class BranchOfficesController : Controller
    {
        private GestionPedidosContext db = new GestionPedidosContext();

        // GET: BranchOffices
        public ActionResult Index()
        {
            return View(db.BranchOffices.ToList());
        }

        // GET: BranchOffices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchOffice branchOffice = db.BranchOffices.Find(id);
            if (branchOffice == null)
            {
                return HttpNotFound();
            }
            return View(branchOffice);
        }

        // GET: BranchOffices/Create
        public ActionResult Create()


        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: BranchOffices/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BranchOfficeID,CustomerID,BranchOfficeAddress")] BranchOffice branchOffice)
        {
            if (ModelState.IsValid)
            {
                db.BranchOffices.Add(branchOffice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(branchOffice);
        }

        // GET: BranchOffices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchOffice branchOffice = db.BranchOffices.Find(id);
            if (branchOffice == null)
            {
                return HttpNotFound();
            }
            return View(branchOffice);
        }

        // POST: BranchOffices/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BranchOfficeID,CustomerID,BranchOfficeAddress")] BranchOffice branchOffice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branchOffice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branchOffice);
        }

        // GET: BranchOffices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchOffice branchOffice = db.BranchOffices.Find(id);
            if (branchOffice == null)
            {
                return HttpNotFound();
            }
            return View(branchOffice);
        }

        // POST: BranchOffices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BranchOffice branchOffice = db.BranchOffices.Find(id);
            db.BranchOffices.Remove(branchOffice);
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

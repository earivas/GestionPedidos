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
    public class SalesChannelsController : Controller
    {
        private GestionPedidosContext db = new GestionPedidosContext();

        // GET: SalesChannels
        public ActionResult Index()
        {
            return View(db.SalesChannels.ToList());
        }

        // GET: SalesChannels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesChannel salesChannel = db.SalesChannels.Find(id);
            if (salesChannel == null)
            {
                return HttpNotFound();
            }
            return View(salesChannel);
        }

        // GET: SalesChannels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesChannels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesChennelID,SalesChannelName")] SalesChannel salesChannel)
        {
            if (ModelState.IsValid)
            {
                db.SalesChannels.Add(salesChannel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesChannel);
        }

        // GET: SalesChannels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesChannel salesChannel = db.SalesChannels.Find(id);
            if (salesChannel == null)
            {
                return HttpNotFound();
            }
            return View(salesChannel);
        }

        // POST: SalesChannels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesChennelID,SalesChannelName")] SalesChannel salesChannel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesChannel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesChannel);
        }

        // GET: SalesChannels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesChannel salesChannel = db.SalesChannels.Find(id);
            if (salesChannel == null)
            {
                return HttpNotFound();
            }
            return View(salesChannel);
        }

        // POST: SalesChannels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesChannel salesChannel = db.SalesChannels.Find(id);
            db.SalesChannels.Remove(salesChannel);
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

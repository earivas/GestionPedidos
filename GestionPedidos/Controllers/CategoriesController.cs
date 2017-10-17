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
    public class CategoriesController : Controller
    {
        private GestionPedidosContext db = new GestionPedidosContext();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            var d = new Category();
             
            d.CreationDate = DateTime.Now.Date;
            d.CreateBy = "UserCreator"; // Asignar usuario Activo
            d.ModifiedDate = DateTime.Now.Date;
            d.ModifiedBy = "UserModified"; // Asignar usuario Activo

            return View(d);
        }

        // POST: Categories/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,OrganitationID,CategoryCode,CategoryDescription,CreationDate,CreateBy,ModifiedDate,ModifiedBy")] Category category)

        {

            if (ModelState.IsValid)
            {
                category = Session["Category"] as Category;
                // Lo que se ingreso por pantalla
              //  int categoryID = int.Parse(Request["CategoryID"]);
             //   int organitationID = int.Parse(Request["OrganitationID"]);
                string categoryCode = Request["CategoryCode"];
                string categoryDescription = Request["CategoryDescription"];
                DateTime CreationDate = DateTime.Now;
                string createBy = "UserCreate";
                DateTime modifiedDate =   DateTime.Now;
                string modifiedBy =   "UserModified";

              //  int customerID = int.Parse(Request["CustomerID"]);
              //  DateTime dateOrder = Convert.ToDateTime(Request["Customer.OrderDate"]);  // Customer.OrderDate

                Category _category = new Category
                {
                   // CategoryID = categoryID,
                  //  OrganitationID= organitationID,
                    CategoryCode= categoryCode,
                    CategoryDescription= categoryDescription,
                    CreationDate = DateTime.Now,
                    CreateBy = createBy,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = modifiedBy
                };
                db.Categories.Add(_category);
                db.SaveChanges();
                return RedirectToAction("Index");


                //    db.Categories.Add(category);
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,OrganitationID,CategoryCode,CategoryDescription,CreationDate,CreateBy,ModifiedDate,ModifiedBy")] Category category)
        {
            if (ModelState.IsValid)
            {
               // category = Session["Category"] as Category;
                // Lo que se ingreso por pantalla
                //  int categoryID = int.Parse(Request["CategoryID"]);
                //   int organitationID = int.Parse(Request["OrganitationID"]);
               // string categoryCode = Request["CategoryCode"];
               // string categoryDescription = Request["CategoryDescription"];
            //    DateTime CreationDate = DateTime.Now;
           //     string createBy = "UserCreate";
              //  DateTime modifiedDate = DateTime.Now;
              //  string modifiedBy = "UserModifiedTest";

                //Category _category = new Category
                //{
                //    CategoryCode = categoryCode,
                //    CategoryDescription = categoryDescription,
                //    ModifiedDate = DateTime.Now,
                //    ModifiedBy = modifiedBy
                //};

                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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

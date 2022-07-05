using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eticaret.MVC.Admin.UI.Models;
using Eticaret.Datacore.Context;
using Eticaret.Domain.POCO;

namespace Eticaret.MVC.Admin.UI.Controllers
{
    public class MasterCategoryController : Controller
    {
        private EticaretDbContext db = new EticaretDbContext();

        // GET: MasterCategory
        public ActionResult Index()
        {
            return View(db.MasterCategories.ToList());
        }

        // GET: MasterCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterCategory masterCategory = db.MasterCategories.Find(id);
            if (masterCategory == null)
            {
                return HttpNotFound();
            }
            return View(masterCategory);
        }

        // GET: MasterCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,IsDeleted,Created,Updated")] MasterCategory masterCategory)
        {
            if (ModelState.IsValid)
            {
                db.MasterCategories.Add(masterCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masterCategory);
        }

        // GET: MasterCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterCategory masterCategory = db.MasterCategories.SingleOrDefault(x=>x.Id==id);
            if (masterCategory == null)
            {
                return HttpNotFound();
            }
            return View(masterCategory);
        }

        // POST: MasterCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,IsDeleted,Created",Exclude ="Updated")] MasterCategory masterCategory)
        {
            if (ModelState.IsValid)
            {
                masterCategory.Updated = DateTime.UtcNow;
                db.Entry(masterCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masterCategory);
        }

        // GET: MasterCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterCategory masterCategory = db.MasterCategories.Find(id);
            if (masterCategory == null)
            {
                return HttpNotFound();
            }
            return View(masterCategory);
        }

        // POST: MasterCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasterCategory masterCategory = db.MasterCategories.Find(id);
            db.MasterCategories.Remove(masterCategory);
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

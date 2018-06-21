using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlytaloMVC.Models;

namespace AlytaloMVC.Controllers
{
    public class SaunaTilaController : Controller
    {
        private älytalodbEntities db = new älytalodbEntities();

        // GET: SaunaTila
        public ActionResult Index()
        {
            return View(db.Sauna.ToList());
        }

        // GET: SaunaTila/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sauna sauna = db.Sauna.Find(id);
            if (sauna == null)
            {
                return HttpNotFound();
            }
            return View(sauna);
        }

        // GET: SaunaTila/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaunaTila/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaunaId,SaunanTila,SaunanNykyLampotila,SaunaStart,SaunaStop,SaunanNimi")] Sauna sauna)
        {
            if (ModelState.IsValid)
            {
                db.Sauna.Add(sauna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sauna);
        }

        // GET: SaunaTila/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sauna sauna = db.Sauna.Find(id);
            if (sauna == null)
            {
                return HttpNotFound();
            }
            return View(sauna);
        }

        // POST: SaunaTila/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaunaId,SaunanTila,SaunanNykyLampotila,SaunaStart,SaunaStop,SaunanNimi")] Sauna sauna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sauna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sauna);
        }

        // GET: SaunaTila/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sauna sauna = db.Sauna.Find(id);
            if (sauna == null)
            {
                return HttpNotFound();
            }
            return View(sauna);
        }

        // POST: SaunaTila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sauna sauna = db.Sauna.Find(id);
            db.Sauna.Remove(sauna);
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

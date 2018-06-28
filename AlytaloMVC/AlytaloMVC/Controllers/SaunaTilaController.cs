using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlytaloMVC.Models;
using AlytaloMVC.ViewModels;

namespace AlytaloMVC.Controllers
{
    public class SaunaTilaController : Controller
    {
        private älytalodbEntities db = new älytalodbEntities();

        // GET: SaunaTila
        public ActionResult Index()
        {
            List<SaunaVIewModel> model = new List<SaunaVIewModel>();
            älytalodbEntities entities = new älytalodbEntities();
            try
            {
                List<Sauna> sau = entities.Sauna.OrderByDescending(Sauna => Sauna.SaunaId).ToList();
                foreach (Sauna saun in sau)
                {
                    SaunaVIewModel view = new SaunaVIewModel();
                    view.SaunaId = saun.SaunaId;
                    view.SaunanTila = saun.SaunanTila;
                    view.SaunanNykyLampotila = saun.SaunanNykyLampotila;
                    view.SaunaStart = saun.SaunaStart;
                    view.SaunaStop = saun.SaunaStop;
                    view.SaunanNimi = saun.SaunanNimi;
                    model.Add(view);
                }
            }
            finally
            {
                entities.Dispose();
            }
            return View(model);

        }
        public ActionResult SaunaOff(int? id)
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
            SaunaVIewModel view = new SaunaVIewModel();
            view.SaunaId = sauna.SaunaId;
            view.SaunanNimi = sauna.SaunanNimi;


            view.SaunaStop = sauna.SaunaStop;
            view.SaunanTila = false;



            return View(view);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaunaOff(SaunaVIewModel model)
        {
            Sauna view = db.Sauna.Find(model.SaunaId);
            view.SaunaStop = DateTime.Now;
            view.SaunanNimi = model.SaunanNimi;
            view.SaunanTila = false;

            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //Sauna on //
        public ActionResult SaunaOn(int? id)
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
            SaunaVIewModel view = new SaunaVIewModel();
            view.SaunaId = sauna.SaunaId;
            view.SaunanNimi = sauna.SaunanNimi;
            view.SaunaStart = sauna.SaunaStart;
            view.SaunanTila = true;

            return View(view);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaunaOn(SaunaVIewModel model)
        {
            Sauna view = db.Sauna.Find(model.SaunaId);
            view.SaunaStart = DateTime.Now;
            view.SaunanNimi = model.SaunanNimi;
            view.SaunanTila = true;

            db.SaveChanges();
            return RedirectToAction("Index");

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
            älytalodbEntities db = new älytalodbEntities();
            SaunaVIewModel model = new SaunaVIewModel();

            return View(model);
        }

        // POST: SaunaTila/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaunaVIewModel model)
        {
            Sauna view = new Sauna();
            view.SaunaId = model.SaunaId;
            view.SaunanNimi = model.SaunanNimi;
            view.SaunanNykyLampotila = model.SaunanNykyLampotila;
            db.Sauna.Add(view);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {


            }
            return RedirectToAction("Index");
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

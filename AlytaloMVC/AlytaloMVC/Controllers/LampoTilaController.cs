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

    public class LampoTilaController : Controller
    {
        private älytalodbEntities db = new älytalodbEntities();
        public ActionResult Index()
        {
            List<LampotilaViewModel> model = new List<LampotilaViewModel>();
            älytalodbEntities entities = new älytalodbEntities();
            try
            {
                List<Lampo> lamp = entities.Lampo.OrderByDescending(Lampo => Lampo.LampoId).ToList();
                foreach (Lampo lam in lamp)
                {
                    LampotilaViewModel view = new LampotilaViewModel();
                    view.LampoId = lam.LampoId;
                    view.TalonTavoiteLampotila = lam.TalonTavoiteLampotila;
                    view.TalonNykyLampotila = lam.TalonNykyLampotila;
                    view.LampotilaAsetettu = lam.LampotilaAsetettu;
                    model.Add(view);
                }
            }
            finally
            {
                entities.Dispose();
            }
            return View(model);
        }

        public ActionResult Create()
        {
            älytalodbEntities db = new älytalodbEntities();
            LampotilaViewModel model = new LampotilaViewModel();

            return View(model);
        }

        // POST: SaunaTila/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LampotilaViewModel model)
        {
            Lampo view = new Lampo();
            view.LampoId = model.LampoId;
            view.TalonTavoiteLampotila = model.TalonTavoiteLampotila;
            view.TalonNykyLampotila = model.TalonNykyLampotila;
            view.LampotilaAsetettu = DateTime.Now;
            db.Lampo.Add(view);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {


            }
            return RedirectToAction("Index");
        }


        // GET: LampoTila/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lampo lampo = db.Lampo.Find(id);
            if (lampo == null)
            {
                return HttpNotFound();
            }
            return View(lampo);
        }

        // POST: LampoTila/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LampoId,TalonTavoiteLampotila,TalonNykyLampotila,LampotilaAsetettu")] Lampo lampo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lampo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lampo);
        }

        // GET: LampoTila/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lampo lampo = db.Lampo.Find(id);
            if (lampo == null)
            {
                return HttpNotFound();
            }
            return View(lampo);
        }

        // POST: LampoTila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lampo lampo = db.Lampo.Find(id);
            db.Lampo.Remove(lampo);
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

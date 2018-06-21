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
    public class ValoTilaController : Controller
    {
        private älytalodbEntities db = new älytalodbEntities();

        // GET: ValoTila
        public ActionResult Index()
        {
            List<ValoViewModel> model = new List<ValoViewModel>();
            älytalodbEntities entities = new älytalodbEntities();
            try
            {
                List<Valot> val = entities.Valot.OrderByDescending(Valot => Valot.ValoId).ToList();
                foreach(Valot valo in val)
                {
                    ValoViewModel view = new ValoViewModel();
                    view.ValoId = valo.ValoId;
                    view.Valo33 = valo.Valo33;
                    view.Valo66 = valo.Valo66;
                    view.Valo100 = valo.Valo100;
                    view.Valo33Aika = valo.Valo33Aika;
                    view.Valo66AIka = valo.Valo66AIka;
                    view.valo100Aika = valo.valo100Aika;
                    view.ValoOff = valo.ValoOff;
                    view.HuoneValo = valo.HuoneValo;
                    view.ValoOffAika = valo.ValoOffAika;
                    model.Add(view);
                }
            }
            finally
            {
                entities.Dispose();
            }
            return View(model);

        }

        // GET: ValoTila/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            return View(valot);
        }

        // GET: ValoTila/Create
        public ActionResult Create()
        {
            älytalodbEntities db = new älytalodbEntities();
            ValoViewModel model = new ValoViewModel();


            return View(model);
        }

        // POST: ValoTila/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ValoViewModel model)
        {
            Valot view = new Valot();
            view.ValoId = model.ValoId;
            view.HuoneValo = model.HuoneValo;
            db.Valot.Add(view);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                
               
            }
            return RedirectToAction("Index");
                

        }

        // GET: ValoTila/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            ValoViewModel view = new ValoViewModel();
            view.ValoId = valot.ValoId;
            view.HuoneValo = valot.HuoneValo;
            return View(view);
        }

        // POST: ValoTila/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ValoViewModel model)
        {
            Valot view = db.Valot.Find(model.ValoId);
            view.HuoneValo = model.HuoneValo;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ValoTila/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            return View(valot);
        }

        // POST: ValoTila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valot valot = db.Valot.Find(id);
            db.Valot.Remove(valot);
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

        // GET: ValoTila/VALOOFF/5
        public ActionResult ValoOff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            ValoViewModel view = new ValoViewModel();
            view.ValoId = valot.ValoId;
            view.HuoneValo = valot.HuoneValo;

            view.Valo33 = false;
            view.Valo66 = false;
            view.Valo100 = false;
            view.ValoOff = true;
            


            return View(view);
        }

        // POST: ValoTila/ValoOFF/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValoOff(ValoViewModel model)
        {
            Valot view = db.Valot.Find(model.ValoId);
        
            view.HuoneValo = model.HuoneValo;
            view.Valo33 = false;
            view.Valo66 = false;
            view.Valo100 = false;
            view.ValoOff = true;
            view.ValoOffAika = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        // GET: ValoTila/valo33/5
        public ActionResult Valo33(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            ValoViewModel view = new ValoViewModel();
            view.ValoId = valot.ValoId;
            view.HuoneValo = valot.HuoneValo;

            view.Valo33 = true;
            view.Valo66 = false;
            view.Valo100 = false;
            view.ValoOff = false;



            return View(view);
        }

        // POST: ValoTila/valo33/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Valo33(ValoViewModel model)
        {
            Valot view = db.Valot.Find(model.ValoId);

            view.HuoneValo = model.HuoneValo;
            view.Valo33 = true;
            view.Valo66 = false;
            view.Valo100 = false;
            view.ValoOff = false;
            view.Valo33Aika = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        // GET: ValoTila/valo33/5
        public ActionResult Valo66(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            ValoViewModel view = new ValoViewModel();
            view.ValoId = valot.ValoId;
            view.HuoneValo = valot.HuoneValo;

            view.Valo33 = false;
            view.Valo66 = true;
            view.Valo100 = false;
            view.ValoOff = false;



            return View(view);
        }

        // POST: ValoTila/valo33/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Valo66(ValoViewModel model)
        {
            Valot view = db.Valot.Find(model.ValoId);

            view.HuoneValo = model.HuoneValo;
            view.Valo33 = false;
            view.Valo66 = true;
            view.Valo100 = false;
            view.ValoOff = false;
            view.Valo66AIka = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        // GET: ValoTila/valo100/5
        public ActionResult Valo100(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            ValoViewModel view = new ValoViewModel();
            view.ValoId = valot.ValoId;
            view.HuoneValo = valot.HuoneValo;

            view.Valo33 = false;
            view.Valo66 = false;
            view.Valo100 = true;
            view.ValoOff = false;



            return View(view);
        }

        // POST: ValoTila/valo100

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Valo100(ValoViewModel model)
        {
            Valot view = db.Valot.Find(model.ValoId);

            view.HuoneValo = model.HuoneValo;
            view.Valo33 = false;
            view.Valo66 = false;
            view.Valo100 = true;
            view.ValoOff = false;
            view.valo100Aika = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}

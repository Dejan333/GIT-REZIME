using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class PrijavaIspitasController : Controller
    {
        private Model1 db = new Model1();

        // GET: PrijavaIspitas
        public ActionResult Index()
        {
            var prijavaIspita_set = db.PrijavaIspita_set.Include(p => p.Ispit).Include(p => p.Predmet).Include(p => p.Student);
            return View(prijavaIspita_set.ToList());
        }

        // GET: PrijavaIspitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijavaIspita prijavaIspita = db.PrijavaIspita_set.Find(id);
            if (prijavaIspita == null)
            {
                return HttpNotFound();
            }
            return View(prijavaIspita);
        }

        // GET: PrijavaIspitas/Create
        public ActionResult Create()
        {
            ViewBag.IspitID = new SelectList(db.Ispit_set, "IspitID", "SifraIspita");
            ViewBag.PredmetID = new SelectList(db.Predmet_set, "PredmetID", "Sifra");
            ViewBag.StudentID = new SelectList(db.Student_set, "StudentID", "Ime");
            return View();
        }

        // POST: PrijavaIspitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IspitID,StudentID,PredmetID,BrojPrethodnihPolaganja")] PrijavaIspita prijavaIspita)
        {
            if (ModelState.IsValid)
            {
                db.PrijavaIspita_set.Add(prijavaIspita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IspitID = new SelectList(db.Ispit_set, "IspitID", "SifraIspita", prijavaIspita.IspitID);
            ViewBag.PredmetID = new SelectList(db.Predmet_set, "PredmetID", "Sifra", prijavaIspita.PredmetID);
            ViewBag.StudentID = new SelectList(db.Student_set, "StudentID", "Ime", prijavaIspita.StudentID);
            return View(prijavaIspita);
        }

        // GET: PrijavaIspitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijavaIspita prijavaIspita = db.PrijavaIspita_set.Find(id);
            if (prijavaIspita == null)
            {
                return HttpNotFound();
            }
            ViewBag.IspitID = new SelectList(db.Ispit_set, "IspitID", "SifraIspita", prijavaIspita.IspitID);
            ViewBag.PredmetID = new SelectList(db.Predmet_set, "PredmetID", "Sifra", prijavaIspita.PredmetID);
            ViewBag.StudentID = new SelectList(db.Student_set, "StudentID", "Ime", prijavaIspita.StudentID);
            return View(prijavaIspita);
        }

        // POST: PrijavaIspitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IspitID,StudentID,PredmetID,BrojPrethodnihPolaganja")] PrijavaIspita prijavaIspita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prijavaIspita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IspitID = new SelectList(db.Ispit_set, "IspitID", "SifraIspita", prijavaIspita.IspitID);
            ViewBag.PredmetID = new SelectList(db.Predmet_set, "PredmetID", "Sifra", prijavaIspita.PredmetID);
            ViewBag.StudentID = new SelectList(db.Student_set, "StudentID", "Ime", prijavaIspita.StudentID);
            return View(prijavaIspita);
        }

        // GET: PrijavaIspitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijavaIspita prijavaIspita = db.PrijavaIspita_set.Find(id);
            if (prijavaIspita == null)
            {
                return HttpNotFound();
            }
            return View(prijavaIspita);
        }

        // POST: PrijavaIspitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrijavaIspita prijavaIspita = db.PrijavaIspita_set.Find(id);
            db.PrijavaIspita_set.Remove(prijavaIspita);
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

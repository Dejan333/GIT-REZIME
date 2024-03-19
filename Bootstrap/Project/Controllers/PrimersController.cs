using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using PagedList;


namespace Project.Controllers
{
    public class PrimersController : Controller
    {
        private Model1 db = new Model1();

        // GET: Primers
        public ActionResult Index(int page=1)
        {
            var model = db.Primer_set
                .ToList()
                .ToPagedList(page, 5);
            return View(model);
        }

        // GET: Primers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Primer primer = db.Primer_set.Find(id);
            if (primer == null)
            {
                return HttpNotFound();
            }
            return View(primer);
        }

        // GET: Primers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Primers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,Ime,Prezime,JMBG,BrojIndeksa,PostanskiBrojGrada")] Primer primer)
        {
            if (ModelState.IsValid)
            {
                db.Primer_set.Add(primer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(primer);
        }

        // GET: Primers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Primer primer = db.Primer_set.Find(id);
            if (primer == null)
            {
                return HttpNotFound();
            }
            return View(primer);
        }

        // POST: Primers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,Ime,Prezime,JMBG,BrojIndeksa,PostanskiBrojGrada")] Primer primer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(primer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(primer);
        }

        // GET: Primers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Primer primer = db.Primer_set.Find(id);
            if (primer == null)
            {
                return HttpNotFound();
            }
            return View(primer);
        }

        // POST: Primers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Primer primer = db.Primer_set.Find(id);
            db.Primer_set.Remove(primer);
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

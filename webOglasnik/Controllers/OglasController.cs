using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webOglasnik.Models;

namespace webOglasnik.Controllers
{
    public class OglasController : Controller
    {
        BazaDbContext db = new BazaDbContext();

        // GET: Oglas
        public ActionResult Index()
        {
            return View(db.PopisOglasa.ToList());
        }

        // GET: Oglas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oglas oglas = db.PopisOglasa.Find(id);
            if (oglas == null)
            {
                return HttpNotFound();
            }
            return View(oglas);
        }

        // GET: Oglas/Create
        public ActionResult Create()
        {
            var kategorije = db.PopisKategorija.OrderBy(x => x.Naziv).ToList();
            kategorije.Insert(0, new Kategorija { Sifra = "", Naziv = "Nedefinirano" });
            ViewBag.Kategorije = kategorije;

            return View();
        }

        // POST: Oglas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv,KategorijaSifra,Opis,DatumObjave,TrajeDo,Cijena")] Oglas oglas)
        {
            if (ModelState.IsValid)
            {
                db.PopisOglasa.Add(oglas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oglas);
        }

        // GET: Oglas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oglas oglas = db.PopisOglasa.Find(id);
            if (oglas == null)
            {
                return HttpNotFound();
            }

            var kategorije = db.PopisKategorija.OrderBy(x => x.Naziv).ToList();
            kategorije.Insert(0, new Kategorija { Sifra = "", Naziv = "Nedefinirano" });
            ViewBag.Kategorije = kategorije;

            return View(oglas);
        }

        // POST: Oglas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv,KategorijaSifra,Opis,DatumObjave,TrajeDo,Cijena")] Oglas oglas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oglas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var kategorije = db.PopisKategorija.OrderBy(x => x.Naziv).ToList();
            kategorije.Insert(0, new Kategorija { Sifra = "", Naziv = "Nedefinirano" });
            ViewBag.Kategorije = kategorije;

            return View(oglas);
        }

        // GET: Oglas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oglas oglas = db.PopisOglasa.Find(id);
            if (oglas == null)
            {
                return HttpNotFound();
            }
            return View(oglas);
        }

        // POST: Oglas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oglas oglas = db.PopisOglasa.Find(id);
            db.PopisOglasa.Remove(oglas);
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

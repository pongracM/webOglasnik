using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webOglasnik.Models;

namespace webOglasnik.Controllers
{
    public class OglasController : Controller
    {
        public BazaDbContext db = new BazaDbContext();

        // GET: Oglas
        public ActionResult Index(string naziv, string kategorija)
        {
            var oglasi = db.PopisOglasa.ToList();

            var kategorijeList = db.PopisKategorija.OrderBy(x=>x.Naziv).ToList();
            ViewBag.Kategorije = kategorijeList;

            if (!String.IsNullOrWhiteSpace(naziv))
                oglasi = oglasi.Where(x => x.Naziv.ToUpper().Contains(naziv.ToUpper())).ToList();
             
            if (!String.IsNullOrWhiteSpace(kategorija))
                oglasi = oglasi.Where(x=>x.KategorijaSifra == kategorija).ToList();
                

            return View(oglasi);
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

        [Authorize]
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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Oglas oglas)
        {
            if (oglas.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(oglas.ImageFile.FileName);
                string extension = Path.GetExtension(oglas.ImageFile.FileName);

                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                {
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    oglas.SlikaPutanja = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    oglas.ImageFile.SaveAs(fileName);
                }
                else
                {
                    ModelState.AddModelError("SlikaPutanja", "Nepodržana ekstenzija");
                }

            }

            if (ModelState.IsValid)
            {
                db.PopisOglasa.Add(oglas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oglas);
        }
        [Authorize]
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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Oglas oglas)
        {
            if (oglas.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(oglas.ImageFile.FileName);
                string extension = Path.GetExtension(oglas.ImageFile.FileName);

                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                {
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    oglas.SlikaPutanja = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    oglas.ImageFile.SaveAs(fileName);
                }
                else
                {
                    ModelState.AddModelError("SlikaPutanja", "Nepodržana ekstenzija");
                }

            }

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
        [Authorize]
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
        [Authorize]
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

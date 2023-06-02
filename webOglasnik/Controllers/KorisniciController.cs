using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webOglasnik.Models;

namespace webOglasnik.Controllers
{
    public class KorisniciController : Controller
    {
        private BazaDbContext db = new BazaDbContext();

        // GET: Korisnici
        public ActionResult Index()
        {
            var listaKorisnika = db.PopisKorisnika.OrderBy(x=>x.SifraOvlasti).ThenBy(x=>x.Prezime).ToList();

            return View(listaKorisnika);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Prijava(string returnUrl)
        {
            KorisnikPrijava model = new KorisnikPrijava();
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using webOglasnik.Models;

namespace webOglasnik.Misc
{
    public class LogiraniKorisnik : IPrincipal
    {
        public string KorisnickoIme { get; set; }
        public string PrezimeIme { get; set; }
        public string Ovlast { get; set; }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            if(Ovlast == role) return true;
            return false;
        }
        public LogiraniKorisnik(Korisnik kor)
        {
            this.Identity = new GenericIdentity(kor.KorisnickoIme);
            this.KorisnickoIme = kor.KorisnickoIme;
            this.PrezimeIme = kor.PrezimeIme;
            this.Ovlast = kor.SifraOvlasti;
        }
        public LogiraniKorisnik(string korisnickoIme)
        {
            this.Identity = new GenericIdentity(korisnickoIme);
            this.KorisnickoIme= korisnickoIme;
        }
    }
}
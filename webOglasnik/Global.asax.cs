using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using webOglasnik.Misc;

namespace webOglasnik
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                LogiraniKorisnikSerializeModel serializeModel = serializer.Deserialize<LogiraniKorisnikSerializeModel>(authTicket.UserData);

                LogiraniKorisnik korisnik = new LogiraniKorisnik(authTicket.Name);
                korisnik.PrezimeIme = serializeModel.PrezimeIme;
                korisnik.Ovlast = serializeModel.Ovlast;

                HttpContext.Current.User = korisnik;
            }
        }
    }
}

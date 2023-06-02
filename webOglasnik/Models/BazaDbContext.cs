using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using webOglasnik.Models;

namespace webOglasnik.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]

    public class BazaDbContext : DbContext
    {
        public DbSet<Oglas> PopisOglasa { get; set; }
        public DbSet<Kategorija> PopisKategorija { get; set; }
        public DbSet<Korisnik> PopisKorisnika { get; set; }
        public DbSet<Ovlast> PopisOvlasti { get; set; }
    }
}
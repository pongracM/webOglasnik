using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace webOglasnik.Models
{
    [Table("kategorije")]

    public class Kategorija
    {

        [Key]
        [Column("sifra")]
        [Display(Name = "Sifra")]
        [Required(ErrorMessage = "{0} je obavezna")]
        [StringLength(11, ErrorMessage = "{0} mora biti duljune maksimalno {1} znakova")]
        public string Sifra { get; set; }

        [Column("naziv")]
        [Display(Name = "Kategorija")]
        [Required(ErrorMessage = "{0} je obavezan")]
        [StringLength(75, ErrorMessage = "{0} mora biti duljune maksimalno {1} znakova")]
        public string Naziv { get; set; }

    }
}
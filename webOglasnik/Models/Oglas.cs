using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace webOglasnik.Models
{
    
    [Table("oglasi")]

    public class Oglas
    {
        [Key]
        [Column("id")]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "{0} je obavezan")]
        public int Id { get; set; }

        [Column("naziv")]
        [Display(Name = "Naziv")]
        [Required(ErrorMessage = "{0} je obavezan")]
        [StringLength(75, ErrorMessage = "{0} mora biti duljune maksimalno {1} znakova")]
        public string Naziv { get; set; }

        [Display(Name = "Kategorija")]
        [Column("kategorija_sifra")]
        [ForeignKey("OglasKategorija")]
        public string KategorijaSifra { get; set; }
        public virtual Kategorija OglasKategorija { get; set; }

        [Column("opis")]
        [Display(Name = "Opis")]
        [Required(ErrorMessage = "{0} je obavezan")]
        [StringLength(255, ErrorMessage = "{0} mora biti duljune maksimalno {1} znakova")]
        public string Opis { get; set; }

        [Column("datum_objave")]
        [Display(Name = "Datum objave")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} je obavezan")]
        [DataType(DataType.Date)]
        public DateTime DatumObjave { get; set; }

        [Column("traje_do")]
        [Display(Name = "Traje do")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Datum isteka je obavezan")]
        [DataType(DataType.Date)]
        public DateTime TrajeDo { get; set; }

        [Column("cijena")]
        [Display(Name = "Cijena (€)")]
        [Required(ErrorMessage = "{0} je obavezna")]
        public int Cijena { get; set; }

       

    }
}
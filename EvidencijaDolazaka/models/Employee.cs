
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EvidencijaDolazaka.models{

    [Table("radnici")]
    public class Employee{

        [Key]
        [Column("jmbg")]
        public string Jmbg {get; set;}

        [Column("pin")]
        public int Pin {get; set;}

        [Column("ime")]
        public string Ime {get; set;}

        [Column("prezime")]
        public string Prezime {get; set;}

        [Column("titula")]
        public string Titula {get; set;}

        [Column("funkcija")]
        public string Funkcija {get; set;}

        [Column("sluzba")]
        public string Sluzba {get; set;}

        [Column("vreme_od_1")]
        public string Vreme_od_1 {get; set;}

        [Column("vreme_do_1")]
        public string Vreme_do_1 {get; set;}

        [Column("vreme_od_2")]
        public string Vreme_od_2 {get; set;}

        [Column("vreme_do_2")]
        public string Vreme_do_2 {get; set;}


    }
}
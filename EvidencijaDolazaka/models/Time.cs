using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvidencijaDolazaka.models{

    [Table("vreme", Schema="kontrola_dolazaka")]
    public class Time{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID {get; set;}

        [Column("datum")]
        public DateTime Datum {get; set;}

        [Column("vreme_dolaska")]
        public TimeSpan VremeDolaska {get; set;}

        [Column("vreme_odlaska")]
        public TimeSpan VremeOdlaska {get; set;}

        [Column("slika_1")]
        public string Slika1 {get; set;}

        [Column("slika_2")]
        public string Slika2 {get; set;}

        [Column("radnik")]
        public string Radnik {get; set;}

    }
}

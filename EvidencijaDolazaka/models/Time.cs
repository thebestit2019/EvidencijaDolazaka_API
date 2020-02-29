using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvidencijaDolazaka.models{

    [Table("vreme", Schema="kontrola_dolazaka")]
    public class Time{

        [Key]
        [Column("id")]
        public int ID {get; set;}

        [Column("datum")]
        public DateTime Datum {get; set;}

        [Column("vreme dolaska")]
        public TimeSpan VremeDolaska {get; set;}

        [Column("vreme odlaska")]
        public TimeSpan VremeOdlaska {get; set;}

        [Column("slika_1")]
        public byte[] Slika1 {get; set;}

        [Column("slika_2")]
        public byte[] Slika2 {get; set;}


    }
}

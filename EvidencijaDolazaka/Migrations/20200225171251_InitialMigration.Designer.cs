﻿// <auto-generated />
using System;
using EvidencijaDolazaka.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EvidencijaDolazaka.Migrations
{
    [DbContext(typeof(ControllContext))]
    [Migration("20200225171251_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EvidencijaDolazaka.models.Employee", b =>
                {
                    b.Property<string>("Jmbg")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("jmbg");

                    b.Property<string>("Funkcija")
                        .HasColumnName("funkcija");

                    b.Property<string>("Ime")
                        .HasColumnName("ime");

                    b.Property<int>("Pin")
                        .HasColumnName("pin");

                    b.Property<string>("Prezime")
                        .HasColumnName("prezime");

                    b.Property<string>("Sluzba")
                        .HasColumnName("sluzba");

                    b.Property<string>("Titula")
                        .HasColumnName("titula");

                    b.Property<string>("Vreme_do_1")
                        .HasColumnName("vreme_do_1");

                    b.Property<string>("Vreme_do_2")
                        .HasColumnName("vreme_do_2");

                    b.Property<string>("Vreme_od_1")
                        .HasColumnName("vreme_od_1");

                    b.Property<string>("Vreme_od_2")
                        .HasColumnName("vreme_od_2");

                    b.HasKey("Jmbg");

                    b.ToTable("radnici");
                });

            modelBuilder.Entity("EvidencijaDolazaka.models.Time", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Datum")
                        .HasColumnName("datum");

                    b.Property<byte[]>("Slika1")
                        .HasColumnName("slika_1");

                    b.Property<byte[]>("Slika2")
                        .HasColumnName("slika_2");

                    b.Property<TimeSpan>("VremeDolaska")
                        .HasColumnName("vreme dolaska");

                    b.Property<TimeSpan>("VremeOdlaska")
                        .HasColumnName("vreme odlaska");

                    b.HasKey("ID");

                    b.ToTable("vreme");
                });
#pragma warning restore 612, 618
        }
    }
}
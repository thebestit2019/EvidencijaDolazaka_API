using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EvidencijaDolazaka.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "radnici",
                columns: table => new
                {
                    jmbg = table.Column<string>(nullable: false),
                    pin = table.Column<int>(nullable: false),
                    ime = table.Column<string>(nullable: true),
                    prezime = table.Column<string>(nullable: true),
                    titula = table.Column<string>(nullable: true),
                    funkcija = table.Column<string>(nullable: true),
                    sluzba = table.Column<string>(nullable: true),
                    vreme_od_1 = table.Column<string>(nullable: true),
                    vreme_do_1 = table.Column<string>(nullable: true),
                    vreme_od_2 = table.Column<string>(nullable: true),
                    vreme_do_2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radnici", x => x.jmbg);
                });

            migrationBuilder.CreateTable(
                name: "vreme",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    datum = table.Column<DateTime>(nullable: false),
                    vremedolaska = table.Column<TimeSpan>(name: "vreme dolaska", nullable: false),
                    vremeodlaska = table.Column<TimeSpan>(name: "vreme odlaska", nullable: false),
                    slika_1 = table.Column<byte[]>(nullable: true),
                    slika_2 = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vreme", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "radnici");

            migrationBuilder.DropTable(
                name: "vreme");
        }
    }
}

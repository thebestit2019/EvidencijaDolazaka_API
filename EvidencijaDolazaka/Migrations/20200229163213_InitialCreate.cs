using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvidencijaDolazaka.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "kontrola_dolazaka");

            migrationBuilder.RenameTable(
                name: "vreme",
                newName: "vreme",
                newSchema: "kontrola_dolazaka");

            migrationBuilder.RenameTable(
                name: "radnici",
                newName: "radnici",
                newSchema: "kontrola_dolazaka");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "vreme_od_2",
                schema: "kontrola_dolazaka",
                table: "radnici",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "vreme_od_1",
                schema: "kontrola_dolazaka",
                table: "radnici",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "vreme_do_2",
                schema: "kontrola_dolazaka",
                table: "radnici",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "vreme_do_1",
                schema: "kontrola_dolazaka",
                table: "radnici",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "vreme",
                schema: "kontrola_dolazaka",
                newName: "vreme");

            migrationBuilder.RenameTable(
                name: "radnici",
                schema: "kontrola_dolazaka",
                newName: "radnici");

            migrationBuilder.AlterColumn<string>(
                name: "vreme_od_2",
                table: "radnici",
                nullable: true,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<string>(
                name: "vreme_od_1",
                table: "radnici",
                nullable: true,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<string>(
                name: "vreme_do_2",
                table: "radnici",
                nullable: true,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<string>(
                name: "vreme_do_1",
                table: "radnici",
                nullable: true,
                oldClrType: typeof(TimeSpan));
        }
    }
}

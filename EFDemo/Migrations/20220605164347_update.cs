using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDemo.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "IsTrue",
                table: "Results",
                newName: "opis");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Results",
                newName: "kategoria");

            migrationBuilder.AddColumn<string>(
                name: "adres",
                table: "Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "data",
                table: "Results",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adres",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "data",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "opis",
                table: "Results",
                newName: "IsTrue");

            migrationBuilder.RenameColumn(
                name: "kategoria",
                table: "Results",
                newName: "FullName");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

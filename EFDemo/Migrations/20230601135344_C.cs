using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDemo.Migrations
{
    public partial class C : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adres",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "data",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "kategoria",
                table: "Results");

            migrationBuilder.AddColumn<int>(
                name: "ilość",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "wartość",
                table: "Results",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ilość",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "wartość",
                table: "Results");

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

            migrationBuilder.AddColumn<string>(
                name: "kategoria",
                table: "Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facesign.Services.Infra.Data.Migrations
{
    public partial class addCamposTbClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "validate",
                table: "clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "validate",
                table: "clients");
        }
    }
}

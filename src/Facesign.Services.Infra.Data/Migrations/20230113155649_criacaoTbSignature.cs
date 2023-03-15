using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facesign.Services.Infra.Data.Migrations
{
    public partial class criacaoTbSignature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false, defaultValueSql: "NEWID()"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    image = table.Column<byte[]>(type: "varbinary(13)", maxLength: 13, nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    validate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataSignature = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_insert = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Signatures");
        }
    }
}

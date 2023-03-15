using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facesign.Services.Infra.Data.Migrations
{
    public partial class CriarBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false, defaultValueSql: "NEWID()"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    telephone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    date_insert = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clients_confs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false, defaultValueSql: "NEWID()"),
                    id_client = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    date_insert = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients_confs", x => x.id);
                    table.ForeignKey(
                        name: "FK_clients_confs_clients_id_client",
                        column: x => x.id_client,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clients_confs_functionalities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false, defaultValueSql: "NEWID()"),
                    id_conf = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    match_3d = table.Column<bool>(type: "bit", nullable: false),
                    liveness_3d = table.Column<bool>(type: "bit", nullable: false),
                    authenticate_cnh = table.Column<bool>(type: "bit", nullable: false),
                    date_insert = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients_confs_functionalities", x => x.id);
                    table.ForeignKey(
                        name: "FK_clients_confs_functionalities_clients_confs_id_conf",
                        column: x => x.id_conf,
                        principalTable: "clients_confs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clients_confs_layouts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false, defaultValueSql: "NEWID()"),
                    id_conf = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    primary_color = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    secundary_color = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    home_image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    date_insert = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients_confs_layouts", x => x.id);
                    table.ForeignKey(
                        name: "FK_clients_confs_layouts_clients_confs_id_conf",
                        column: x => x.id_conf,
                        principalTable: "clients_confs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clients_confs_id_client",
                table: "clients_confs",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_clients_confs_functionalities_id_conf",
                table: "clients_confs_functionalities",
                column: "id_conf");

            migrationBuilder.CreateIndex(
                name: "IX_clients_confs_layouts_id_conf",
                table: "clients_confs_layouts",
                column: "id_conf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clients_confs_functionalities");

            migrationBuilder.DropTable(
                name: "clients_confs_layouts");

            migrationBuilder.DropTable(
                name: "clients_confs");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}

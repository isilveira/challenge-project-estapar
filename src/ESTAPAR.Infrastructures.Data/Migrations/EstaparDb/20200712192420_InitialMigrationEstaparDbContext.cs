using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESTAPAR.Presentations.WebAPP.RazorPages.Migrations
{
    public partial class InitialMigrationEstaparDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    CarroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Placa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.CarroID);
                });

            migrationBuilder.CreateTable(
                name: "Manobristas",
                columns: table => new
                {
                    ManobristaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manobristas", x => x.ManobristaID);
                });

            migrationBuilder.CreateTable(
                name: "Manobras",
                columns: table => new
                {
                    ManobraID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManobristaID = table.Column<int>(nullable: false),
                    CarroID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manobras", x => x.ManobraID);
                    table.ForeignKey(
                        name: "FK_Manobras_Carros_CarroID",
                        column: x => x.CarroID,
                        principalTable: "Carros",
                        principalColumn: "CarroID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manobras_Manobristas_ManobristaID",
                        column: x => x.ManobristaID,
                        principalTable: "Manobristas",
                        principalColumn: "ManobristaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manobras_CarroID",
                table: "Manobras",
                column: "CarroID");

            migrationBuilder.CreateIndex(
                name: "IX_Manobras_ManobristaID",
                table: "Manobras",
                column: "ManobristaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manobras");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Manobristas");
        }
    }
}

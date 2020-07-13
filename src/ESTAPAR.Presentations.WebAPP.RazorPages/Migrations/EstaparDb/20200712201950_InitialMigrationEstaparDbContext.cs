using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESTAPAR.Presentations.WebAPP.RazorPages.Migrations.EstaparDb
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


            string create_spCarrosGetAll = @"CREATE procedure spCarrosGetAll as BEGIN SELECT * FROM Carros END";
            migrationBuilder.Sql(create_spCarrosGetAll);

            string create_spCarrosGetByKey = @"CREATE procedure spCarrosGetByKey @key int as BEGIN SELECT * FROM Carros WHERE CarroID = @key END";
            migrationBuilder.Sql(create_spCarrosGetByKey);
                        
            string create_spManobristasGetAll = @"CREATE procedure spManobristasGetAll as BEGIN SELECT * FROM Manobristas END";
            migrationBuilder.Sql(create_spManobristasGetAll);

            string create_spManobristasGetByKey = @"CREATE procedure spManobristasGetByKey @key int as BEGIN SELECT * FROM Manobristas WHERE ManobristaID = @key END";
            migrationBuilder.Sql(create_spManobristasGetByKey);

            string create_spManobrasGetAll = @"CREATE procedure spManobrasGetAll as BEGIN SELECT * FROM Manobras END";
            migrationBuilder.Sql(create_spManobrasGetAll);

            string create_spManobrasGetByKey = @"CREATE procedure spManobrasGetByKey @key int as BEGIN SELECT * FROM Manobras WHERE ManobraID = @key END";
            migrationBuilder.Sql(create_spManobrasGetByKey);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string drop_spCarrosGetAll = @"DROP procedure spCarrosGetAll";
            migrationBuilder.Sql(drop_spCarrosGetAll);

            string drop_spCarrosGetByKey = @"DROP procedure spCarrosGetByKey";
            migrationBuilder.Sql(drop_spCarrosGetByKey);

            string drop_spManobristasGetAll = @"DROP procedure spManobristasGetAll";
            migrationBuilder.Sql(drop_spManobristasGetAll);

            string drop_spManobristasGetByKey = @"DROP procedure spManobristasGetByKey";
            migrationBuilder.Sql(drop_spManobristasGetByKey);

            string drop_spManobrasGetAll = @"DROP procedure spManobrasGetAll";
            migrationBuilder.Sql(drop_spManobrasGetAll);

            string drop_spManobrasGetByKey = @"DROP procedure spManobrasGetByKey";
            migrationBuilder.Sql(drop_spManobrasGetByKey);

            migrationBuilder.DropTable(
                name: "Manobras");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Manobristas");
        }
    }
}

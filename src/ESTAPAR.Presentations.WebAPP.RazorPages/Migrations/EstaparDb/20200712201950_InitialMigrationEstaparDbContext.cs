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

            string create_spCarrosRemoveByKey = @"CREATE procedure spCarrosRemoveByKey @key int as BEGIN DELETE FROM Carros WHERE CarroID = @key END";
            migrationBuilder.Sql(create_spCarrosRemoveByKey);

            string create_spCarrosInsert = @"CREATE procedure spCarrosInsert
                                                    @marca varchar(max), @modelo varchar(max), @placa varchar(max) as
                                                    BEGIN
                                                        INSERT INTO Carros VALUES (@marca, @modelo, @placa)
                                                    END";
            migrationBuilder.Sql(create_spCarrosInsert);

            string create_spCarrosUpdateByKey = @"CREATE procedure spCarrosUpdateByKey
                                                    @key int, @marca varchar(max), @modelo varchar(max), @placa varchar(max) as
                                                    BEGIN
                                                        UPDATE Carros SET Marca = @marca, Modelo = @modelo, Placa = @placa WHERE CarroID = @key
                                                    END";
            migrationBuilder.Sql(create_spCarrosUpdateByKey);

            string create_spManobristasGetAll = @"CREATE procedure spManobristasGetAll as BEGIN SELECT * FROM Manobristas END";
            migrationBuilder.Sql(create_spManobristasGetAll);

            string create_spManobristasGetByKey = @"CREATE procedure spManobristasGetByKey @key int as BEGIN SELECT * FROM Manobristas WHERE ManobristaID = @key END";
            migrationBuilder.Sql(create_spManobristasGetByKey);

            string create_spManobristasRemoveByKey = @"CREATE procedure spManobristasRemoveByKey @key int as BEGIN DELETE FROM Manobristas WHERE ManobristaID = @key END";
            migrationBuilder.Sql(create_spManobristasRemoveByKey);

            string create_spManobristasInsert = @"CREATE procedure spManobristasInsert
                                                        @nome varchar(max), @CPF varchar(max), @datanascimento DATETIME as
                                                        BEGIN
                                                            INSERT INTO Manobristas VALUES(@nome, @CPF, @datanascimento)
                                                        END";
            migrationBuilder.Sql(create_spManobristasInsert);

            string create_spManobristasUpdateByKey = @"CREATE procedure spManobristasUpdateByKey
                                                        @key int, @nome varchar(max), @CPF varchar(max), @datanascimento DATETIME as
                                                        BEGIN
                                                            UPDATE Manobristas SET Nome = @nome, CPF = @CPF, DataNascimento = @datanascimento WHERE ManobristaID = @key
                                                        END";
            migrationBuilder.Sql(create_spManobristasUpdateByKey);

            string create_spManobrasGetAll = @"CREATE procedure spManobrasGetAll as BEGIN SELECT * FROM Manobras END";
            migrationBuilder.Sql(create_spManobrasGetAll);

            string create_spManobrasGetByKey = @"CREATE procedure spManobrasGetByKey @key int as BEGIN SELECT * FROM Manobras WHERE ManobraID = @key END";
            migrationBuilder.Sql(create_spManobrasGetByKey);

            string create_spManobrasRemoveByKey = @"CREATE procedure spManobrasRemoveByKey @key int as BEGIN DELETE FROM Manobras WHERE ManobraID = @key END";
            migrationBuilder.Sql(create_spManobrasRemoveByKey);

            string create_spManobrasInsert = @"CREATE procedure spManobrasInsert
                                                        @manobristaID int, @carroID int as
                                                        BEGIN
                                                            INSERT INTO Manobras VALUES(@manobristaID, @carroID)
                                                        END";
            migrationBuilder.Sql(create_spManobrasInsert);

            string create_spManobrasUpdateByKey = @"CREATE procedure spManobrasUpdateByKey
                                                        @key int, @manobristaID int, @carroID int as
                                                        BEGIN
                                                            UPDATE Manobras SET ManobristaID = @manobristaID, CarroID = @carroID WHERE ManobraID = @key
                                                        END";
            migrationBuilder.Sql(create_spManobrasUpdateByKey);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string drop_spCarrosGetAll = @"DROP procedure spCarrosGetAll";
            migrationBuilder.Sql(drop_spCarrosGetAll);

            string drop_spCarrosGetByKey = @"DROP procedure spCarrosGetByKey";
            migrationBuilder.Sql(drop_spCarrosGetByKey);

            string drop_spCarrosRemoveByKey = @"DROP procedure spCarrosRemoveByKey";
            migrationBuilder.Sql(drop_spCarrosRemoveByKey);

            string drop_spCarrosInsert = @"DROP procedure spCarrosInsert";
            migrationBuilder.Sql(drop_spCarrosInsert);

            string drop_spCarrosUpdateByKey = @"DROP procedure spCarrosUpdateByKey";
            migrationBuilder.Sql(drop_spCarrosUpdateByKey);

            string drop_spManobristasGetAll = @"DROP procedure spManobristasGetAll";
            migrationBuilder.Sql(drop_spManobristasGetAll);

            string drop_spManobristasGetByKey = @"DROP procedure spManobristasGetByKey";
            migrationBuilder.Sql(drop_spManobristasGetByKey);

            string drop_spManobristasRemoveByKey = @"DROP procedure spManobristasRemoveByKey";
            migrationBuilder.Sql(drop_spManobristasRemoveByKey);

            string drop_spManobristasInsert = @"DROP procedure spManobristasInsert";
            migrationBuilder.Sql(drop_spManobristasInsert);

            string drop_spManobristasUpdateByKey = @"DROP procedure spManobristasUpdateByKey";
            migrationBuilder.Sql(drop_spManobristasUpdateByKey);

            string drop_spManobrasGetAll = @"DROP procedure spManobrasGetAll";
            migrationBuilder.Sql(drop_spManobrasGetAll);

            string drop_spManobrasGetByKey = @"DROP procedure spManobrasGetByKey";
            migrationBuilder.Sql(drop_spManobrasGetByKey);

            string drop_spManobrasRemoveByKey = @"DROP procedure spManobrasRemoveByKey";
            migrationBuilder.Sql(drop_spManobrasRemoveByKey);

            string drop_spManobrasInsert = @"DROP procedure spManobrasInsert";
            migrationBuilder.Sql(drop_spManobrasInsert);

            string drop_spManobrasUpdateByKey = @"DROP procedure spManobrasUpdateByKey";
            migrationBuilder.Sql(drop_spManobrasUpdateByKey);

            migrationBuilder.DropTable(
                name: "Manobras");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Manobristas");
        }
    }
}

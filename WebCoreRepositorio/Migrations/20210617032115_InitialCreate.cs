using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCoreRepositorio.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caminhao",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    Modelo = table.Column<short>(nullable: false),
                    AnoFabricacao = table.Column<short>(nullable: false),
                    AnoModelo = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caminhao", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caminhao");
        }
    }
}

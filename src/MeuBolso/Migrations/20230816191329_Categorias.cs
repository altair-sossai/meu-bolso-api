using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBolso.Migrations
{
    /// <inheritdoc />
    public partial class Categorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaMovimentacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Cor = table.Column<int>(type: "int", nullable: false),
                    PrevisaoGastoMes = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaMovimentacao", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaMovimentacao");
        }
    }
}

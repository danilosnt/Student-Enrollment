using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeEstudantes.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudantes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudantes_CPF",
                table: "Estudantes",
                column: "CPF",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudantes");
        }
    }
}

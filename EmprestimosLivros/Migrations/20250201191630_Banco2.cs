using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimosLivros.Migrations
{
    /// <inheritdoc />
    public partial class Banco2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataUltimaAtualização",
                table: "Emprestimos",
                newName: "DataEmprestimo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataEmprestimo",
                table: "Emprestimos",
                newName: "DataUltimaAtualização");
        }
    }
}

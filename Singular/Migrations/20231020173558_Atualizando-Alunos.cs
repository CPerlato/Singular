using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Singular.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoAlunos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Alunos",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Alunos",
                newName: "id");
        }
    }
}

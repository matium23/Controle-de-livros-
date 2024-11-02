using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroLivros.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaoMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroSet_AutorSet_AutorId",
                table: "LivroSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroSet",
                table: "LivroSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutorSet",
                table: "AutorSet");

            migrationBuilder.RenameTable(
                name: "LivroSet",
                newName: "Livro");

            migrationBuilder.RenameTable(
                name: "AutorSet",
                newName: "Autor");

            migrationBuilder.RenameIndex(
                name: "IX_LivroSet_AutorId",
                table: "Livro",
                newName: "IX_Livro_AutorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livro",
                table: "Livro",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autor",
                table: "Autor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Autor_AutorId",
                table: "Livro",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Autor_AutorId",
                table: "Livro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livro",
                table: "Livro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Autor",
                table: "Autor");

            migrationBuilder.RenameTable(
                name: "Livro",
                newName: "LivroSet");

            migrationBuilder.RenameTable(
                name: "Autor",
                newName: "AutorSet");

            migrationBuilder.RenameIndex(
                name: "IX_Livro_AutorId",
                table: "LivroSet",
                newName: "IX_LivroSet_AutorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroSet",
                table: "LivroSet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutorSet",
                table: "AutorSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LivroSet_AutorSet_AutorId",
                table: "LivroSet",
                column: "AutorId",
                principalTable: "AutorSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

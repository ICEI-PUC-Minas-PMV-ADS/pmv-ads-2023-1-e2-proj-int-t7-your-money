using Microsoft.EntityFrameworkCore.Migrations;

namespace Your_Money.Migrations
{
    public partial class AddTokenRecuperacaoSenhaColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Usuarios ADD TokenRecuperacaoSenha NVARCHAR(MAX)");
            migrationBuilder.AlterColumn<string>(
                name: "TokenRecuperacaoSenha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Usuarios DROP COLUMN TokenRecuperacaoSenha");
            migrationBuilder.AlterColumn<string>(
                name: "TokenRecuperacaoSenha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

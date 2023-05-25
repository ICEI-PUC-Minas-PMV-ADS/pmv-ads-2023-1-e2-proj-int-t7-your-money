using Microsoft.EntityFrameworkCore.Migrations;

namespace Your_Money.Migrations
{
    public partial class AddCodigoTemporarioColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Usuarios ADD CodigoTemporario NVARCHAR(MAX)");
            migrationBuilder.AlterColumn<string>(
                name: "CodigoTemporario",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Usuarios DROP COLUMN CodigoTemporario");
            migrationBuilder.AlterColumn<string>(
                name: "CodigoTemporario",
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

using Microsoft.EntityFrameworkCore.Migrations;

namespace Your_Money.Migrations
{
    public partial class M03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Saldo",
                table: "Contas",
                newName: "SaldoTotal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaldoTotal",
                table: "Contas",
                newName: "Saldo");
        }
    }
}

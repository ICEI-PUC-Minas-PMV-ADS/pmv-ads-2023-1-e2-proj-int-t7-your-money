using Microsoft.EntityFrameworkCore.Migrations;

namespace Your_Money.Migrations
{
    public partial class L04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroParcelas",
                table: "Lancamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParcelaAtual",
                table: "Lancamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroParcelas",
                table: "Lancamentos");

            migrationBuilder.DropColumn(
                name: "ParcelaAtual",
                table: "Lancamentos");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevStore.Data.Mapping.Migrations
{
    public partial class ChangeProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "preco",
                table: "produto",
                type: "decimal(7,2)",
                precision: 7,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "produto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "garantia",
                table: "produto",
                type: "int",
                precision: 4,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "imagens",
                table: "produto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "quantidade_estoque",
                table: "produto",
                type: "int",
                precision: 4,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tipo_garantia",
                table: "produto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descricao",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "garantia",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "imagens",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "quantidade_estoque",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "tipo_garantia",
                table: "produto");

            migrationBuilder.AlterColumn<decimal>(
                name: "preco",
                table: "produto",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)",
                oldPrecision: 7,
                oldScale: 2);
        }
    }
}

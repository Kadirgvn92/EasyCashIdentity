using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashIdentity.DataAccessLayer.Migrations
{
    public partial class mig_add_decimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CustomerAccountBalance",
                table: "CustomerAccounts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerAccountBalance",
                table: "CustomerAccounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}

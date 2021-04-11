using Microsoft.EntityFrameworkCore.Migrations;

namespace GMSBackend.Migrations
{
    public partial class defaultincomeacc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_accounts_mobile",
            //    table: "accounts");

            migrationBuilder.AddColumn<bool>(
                name: "default_income_acc",
                table: "accounts",
                type: "boolean",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "default_income_acc",
                table: "accounts");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_mobile",
                table: "accounts",
                column: "mobile",
                unique: true);
        }
    }
}

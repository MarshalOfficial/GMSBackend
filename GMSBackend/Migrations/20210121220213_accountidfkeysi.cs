using Microsoft.EntityFrameworkCore.Migrations;

namespace GMSBackend.Migrations
{
    public partial class accountidfkeysi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoiceHeaders_AccountID",
                table: "SaleInvoiceHeaders",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceHeaders_Accounts_AccountID",
                table: "SaleInvoiceHeaders",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceHeaders_Accounts_AccountID",
                table: "SaleInvoiceHeaders");

            migrationBuilder.DropIndex(
                name: "IX_SaleInvoiceHeaders_AccountID",
                table: "SaleInvoiceHeaders");
        }
    }
}

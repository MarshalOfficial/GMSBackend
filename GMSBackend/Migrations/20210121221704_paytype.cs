using Microsoft.EntityFrameworkCore.Migrations;

namespace GMSBackend.Migrations
{
    public partial class paytype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoicePayments_SaleInvoicePaymentTypeId",
                table: "SaleInvoicePayments",
                column: "SaleInvoicePaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoicePayments_SaleInvoicePaymentTypes_SaleInvoicePaym~",
                table: "SaleInvoicePayments",
                column: "SaleInvoicePaymentTypeId",
                principalTable: "SaleInvoicePaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoicePayments_SaleInvoicePaymentTypes_SaleInvoicePaym~",
                table: "SaleInvoicePayments");

            migrationBuilder.DropIndex(
                name: "IX_SaleInvoicePayments_SaleInvoicePaymentTypeId",
                table: "SaleInvoicePayments");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace GMSBackend.Migrations
{
    public partial class _313 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoiceDetails_ProductID",
                table: "SaleInvoiceDetails",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceDetails_product_ProductID",
                table: "SaleInvoiceDetails",
                column: "ProductID",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceDetails_product_ProductID",
                table: "SaleInvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_SaleInvoiceDetails_ProductID",
                table: "SaleInvoiceDetails");
        }
    }
}

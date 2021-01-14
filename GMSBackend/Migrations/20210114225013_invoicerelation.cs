using Microsoft.EntityFrameworkCore.Migrations;

namespace GMSBackend.Migrations
{
    public partial class invoicerelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeaderID",
                table: "SaleInvoiceDetails",
                newName: "InvoiceID");
         

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoiceDetails_InvoiceID",
                table: "SaleInvoiceDetails",
                column: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceDetails_SaleInvoiceHeaders_InvoiceID",
                table: "SaleInvoiceDetails",
                column: "InvoiceID",
                principalTable: "SaleInvoiceHeaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceDetails_SaleInvoiceHeaders_InvoiceID",
                table: "SaleInvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_SaleInvoiceDetails_InvoiceID",
                table: "SaleInvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "InvoiceID",
                table: "SaleInvoiceDetails",
                newName: "HeaderID");
         
        }
    }
}

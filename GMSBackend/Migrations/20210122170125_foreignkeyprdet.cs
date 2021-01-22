using Microsoft.EntityFrameworkCore.Migrations;

namespace GMSBackend.Migrations
{
    public partial class foreignkeyprdet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ProductID",
                table: "SaleInvoiceDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoiceDetails_ProductID",
                table: "SaleInvoiceDetails",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceDetails_ProductMains_ProductID",
                table: "SaleInvoiceDetails",
                column: "ProductID",
                principalTable: "ProductMains",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceDetails_ProductMains_ProductID",
                table: "SaleInvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_SaleInvoiceDetails_ProductID",
                table: "SaleInvoiceDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "SaleInvoiceDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}

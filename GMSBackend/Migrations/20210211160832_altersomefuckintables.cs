using Microsoft.EntityFrameworkCore.Migrations;

namespace GMSBackend.Migrations
{
    public partial class altersomefuckintables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceDetails_product_ProductID",
                table: "SaleInvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceDetails_SaleInvoiceHeaders_InvoiceID",
                table: "SaleInvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceHeaders_accounts_AccountID",
                table: "SaleInvoiceHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoicePayments_SaleInvoiceHeaders_InvoiceID",
                table: "SaleInvoicePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoicePayments_SaleInvoicePaymentTypes_SaleInvoicePaym~",
                table: "SaleInvoicePayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleInvoicePaymentTypes",
                table: "SaleInvoicePaymentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleInvoicePayments",
                table: "SaleInvoicePayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleInvoiceHeaders",
                table: "SaleInvoiceHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleInvoiceDetails",
                table: "SaleInvoiceDetails");

            migrationBuilder.RenameTable(
                name: "SaleInvoicePaymentTypes",
                newName: "sale_invoice_payment_types");

            migrationBuilder.RenameTable(
                name: "SaleInvoicePayments",
                newName: "sale_invoice_payments");

            migrationBuilder.RenameTable(
                name: "SaleInvoiceHeaders",
                newName: "sale_invoice_headers");

            migrationBuilder.RenameTable(
                name: "SaleInvoiceDetails",
                newName: "sale_invoice_details");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "sale_invoice_payment_types",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "sale_invoice_payment_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "sale_invoice_payments",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "sale_invoice_payments",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "sale_invoice_payments",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SaleInvoicePaymentTypeId",
                table: "sale_invoice_payments",
                newName: "sale_invoice_payment_type_id");

            migrationBuilder.RenameColumn(
                name: "InvoiceID",
                table: "sale_invoice_payments",
                newName: "invoice_id");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "sale_invoice_payments",
                newName: "create_date");

            migrationBuilder.RenameIndex(
                name: "IX_SaleInvoicePayments_SaleInvoicePaymentTypeId",
                table: "sale_invoice_payments",
                newName: "IX_sale_invoice_payments_sale_invoice_payment_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_SaleInvoicePayments_InvoiceID",
                table: "sale_invoice_payments",
                newName: "IX_sale_invoice_payments_invoice_id");

            migrationBuilder.RenameColumn(
                name: "Reduction",
                table: "sale_invoice_headers",
                newName: "reduction");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "sale_invoice_headers",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Memo",
                table: "sale_invoice_headers",
                newName: "memo");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "sale_invoice_headers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VisitorID",
                table: "sale_invoice_headers",
                newName: "visitor_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "sale_invoice_headers",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "InvType",
                table: "sale_invoice_headers",
                newName: "inv_type");

            migrationBuilder.RenameColumn(
                name: "InvDate",
                table: "sale_invoice_headers",
                newName: "inv_date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "sale_invoice_headers",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "sale_invoice_headers",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_SaleInvoiceHeaders_AccountID",
                table: "sale_invoice_headers",
                newName: "IX_sale_invoice_headers_account_id");

            migrationBuilder.RenameColumn(
                name: "Reduction_Price",
                table: "sale_invoice_details",
                newName: "reduction_price");

            migrationBuilder.RenameColumn(
                name: "Reduction_Percent",
                table: "sale_invoice_details",
                newName: "reduction_percent");

            migrationBuilder.RenameColumn(
                name: "Qty",
                table: "sale_invoice_details",
                newName: "qty");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "sale_invoice_details",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Memo",
                table: "sale_invoice_details",
                newName: "memo");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "sale_invoice_details",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SessionUsed",
                table: "sale_invoice_details",
                newName: "session_used");

            migrationBuilder.RenameColumn(
                name: "SessionReserved",
                table: "sale_invoice_details",
                newName: "session_reserved");

            migrationBuilder.RenameColumn(
                name: "SessionQty",
                table: "sale_invoice_details",
                newName: "session_qty");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "sale_invoice_details",
                newName: "product_name");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "sale_invoice_details",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "sale_invoice_details",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "InvoiceID",
                table: "sale_invoice_details",
                newName: "invoice_id");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "sale_invoice_details",
                newName: "create_date");

            migrationBuilder.RenameIndex(
                name: "IX_SaleInvoiceDetails_ProductID",
                table: "sale_invoice_details",
                newName: "IX_sale_invoice_details_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_SaleInvoiceDetails_InvoiceID",
                table: "sale_invoice_details",
                newName: "IX_sale_invoice_details_invoice_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sale_invoice_payment_types",
                table: "sale_invoice_payment_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sale_invoice_payments",
                table: "sale_invoice_payments",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sale_invoice_headers",
                table: "sale_invoice_headers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sale_invoice_details",
                table: "sale_invoice_details",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_sale_invoice_details_product_product_id",
                table: "sale_invoice_details",
                column: "product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sale_invoice_details_sale_invoice_headers_invoice_id",
                table: "sale_invoice_details",
                column: "invoice_id",
                principalTable: "sale_invoice_headers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sale_invoice_headers_accounts_account_id",
                table: "sale_invoice_headers",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sale_invoice_payments_sale_invoice_headers_invoice_id",
                table: "sale_invoice_payments",
                column: "invoice_id",
                principalTable: "sale_invoice_headers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sale_invoice_payments_sale_invoice_payment_types_sale_invoi~",
                table: "sale_invoice_payments",
                column: "sale_invoice_payment_type_id",
                principalTable: "sale_invoice_payment_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sale_invoice_details_product_product_id",
                table: "sale_invoice_details");

            migrationBuilder.DropForeignKey(
                name: "FK_sale_invoice_details_sale_invoice_headers_invoice_id",
                table: "sale_invoice_details");

            migrationBuilder.DropForeignKey(
                name: "FK_sale_invoice_headers_accounts_account_id",
                table: "sale_invoice_headers");

            migrationBuilder.DropForeignKey(
                name: "FK_sale_invoice_payments_sale_invoice_headers_invoice_id",
                table: "sale_invoice_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_sale_invoice_payments_sale_invoice_payment_types_sale_invoi~",
                table: "sale_invoice_payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sale_invoice_payments",
                table: "sale_invoice_payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sale_invoice_payment_types",
                table: "sale_invoice_payment_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sale_invoice_headers",
                table: "sale_invoice_headers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sale_invoice_details",
                table: "sale_invoice_details");

            migrationBuilder.RenameTable(
                name: "sale_invoice_payments",
                newName: "SaleInvoicePayments");

            migrationBuilder.RenameTable(
                name: "sale_invoice_payment_types",
                newName: "SaleInvoicePaymentTypes");

            migrationBuilder.RenameTable(
                name: "sale_invoice_headers",
                newName: "SaleInvoiceHeaders");

            migrationBuilder.RenameTable(
                name: "sale_invoice_details",
                newName: "SaleInvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "SaleInvoicePayments",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "SaleInvoicePayments",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SaleInvoicePayments",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "sale_invoice_payment_type_id",
                table: "SaleInvoicePayments",
                newName: "SaleInvoicePaymentTypeId");

            migrationBuilder.RenameColumn(
                name: "invoice_id",
                table: "SaleInvoicePayments",
                newName: "InvoiceID");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "SaleInvoicePayments",
                newName: "CreateDate");

            migrationBuilder.RenameIndex(
                name: "IX_sale_invoice_payments_sale_invoice_payment_type_id",
                table: "SaleInvoicePayments",
                newName: "IX_SaleInvoicePayments_SaleInvoicePaymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_sale_invoice_payments_invoice_id",
                table: "SaleInvoicePayments",
                newName: "IX_SaleInvoicePayments_InvoiceID");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "SaleInvoicePaymentTypes",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SaleInvoicePaymentTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "reduction",
                table: "SaleInvoiceHeaders",
                newName: "Reduction");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "SaleInvoiceHeaders",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "memo",
                table: "SaleInvoiceHeaders",
                newName: "Memo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SaleInvoiceHeaders",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "visitor_id",
                table: "SaleInvoiceHeaders",
                newName: "VisitorID");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "SaleInvoiceHeaders",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "inv_type",
                table: "SaleInvoiceHeaders",
                newName: "InvType");

            migrationBuilder.RenameColumn(
                name: "inv_date",
                table: "SaleInvoiceHeaders",
                newName: "InvDate");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "SaleInvoiceHeaders",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "SaleInvoiceHeaders",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_sale_invoice_headers_account_id",
                table: "SaleInvoiceHeaders",
                newName: "IX_SaleInvoiceHeaders_AccountID");

            migrationBuilder.RenameColumn(
                name: "reduction_price",
                table: "SaleInvoiceDetails",
                newName: "Reduction_Price");

            migrationBuilder.RenameColumn(
                name: "reduction_percent",
                table: "SaleInvoiceDetails",
                newName: "Reduction_Percent");

            migrationBuilder.RenameColumn(
                name: "qty",
                table: "SaleInvoiceDetails",
                newName: "Qty");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "SaleInvoiceDetails",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "memo",
                table: "SaleInvoiceDetails",
                newName: "Memo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SaleInvoiceDetails",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "session_used",
                table: "SaleInvoiceDetails",
                newName: "SessionUsed");

            migrationBuilder.RenameColumn(
                name: "session_reserved",
                table: "SaleInvoiceDetails",
                newName: "SessionReserved");

            migrationBuilder.RenameColumn(
                name: "session_qty",
                table: "SaleInvoiceDetails",
                newName: "SessionQty");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "SaleInvoiceDetails",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "SaleInvoiceDetails",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "SaleInvoiceDetails",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "invoice_id",
                table: "SaleInvoiceDetails",
                newName: "InvoiceID");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "SaleInvoiceDetails",
                newName: "CreateDate");

            migrationBuilder.RenameIndex(
                name: "IX_sale_invoice_details_product_id",
                table: "SaleInvoiceDetails",
                newName: "IX_SaleInvoiceDetails_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_sale_invoice_details_invoice_id",
                table: "SaleInvoiceDetails",
                newName: "IX_SaleInvoiceDetails_InvoiceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleInvoicePayments",
                table: "SaleInvoicePayments",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleInvoicePaymentTypes",
                table: "SaleInvoicePaymentTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleInvoiceHeaders",
                table: "SaleInvoiceHeaders",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleInvoiceDetails",
                table: "SaleInvoiceDetails",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceDetails_product_ProductID",
                table: "SaleInvoiceDetails",
                column: "ProductID",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceDetails_SaleInvoiceHeaders_InvoiceID",
                table: "SaleInvoiceDetails",
                column: "InvoiceID",
                principalTable: "SaleInvoiceHeaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceHeaders_accounts_AccountID",
                table: "SaleInvoiceHeaders",
                column: "AccountID",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoicePayments_SaleInvoiceHeaders_InvoiceID",
                table: "SaleInvoicePayments",
                column: "InvoiceID",
                principalTable: "SaleInvoiceHeaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoicePayments_SaleInvoicePaymentTypes_SaleInvoicePaym~",
                table: "SaleInvoicePayments",
                column: "SaleInvoicePaymentTypeId",
                principalTable: "SaleInvoicePaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

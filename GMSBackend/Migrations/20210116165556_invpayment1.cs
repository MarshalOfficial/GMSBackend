using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GMSBackend.Migrations
{
    public partial class invpayment1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoicePayment_SaleInvoiceHeaders_InvoiceID",
                table: "SaleInvoicePayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleInvoicePayment",
                table: "SaleInvoicePayment");

            migrationBuilder.RenameTable(
                name: "SaleInvoicePayment",
                newName: "SaleInvoicePayments");

            migrationBuilder.RenameIndex(
                name: "IX_SaleInvoicePayment_InvoiceID",
                table: "SaleInvoicePayments",
                newName: "IX_SaleInvoicePayments_InvoiceID");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "SaleInvoicePayments",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleInvoicePayments",
                table: "SaleInvoicePayments",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "SaleInvoicePaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleInvoicePaymentTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoicePayments_SaleInvoiceHeaders_InvoiceID",
                table: "SaleInvoicePayments",
                column: "InvoiceID",
                principalTable: "SaleInvoiceHeaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoicePayments_SaleInvoiceHeaders_InvoiceID",
                table: "SaleInvoicePayments");

            migrationBuilder.DropTable(
                name: "SaleInvoicePaymentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleInvoicePayments",
                table: "SaleInvoicePayments");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "SaleInvoicePayments");

            migrationBuilder.RenameTable(
                name: "SaleInvoicePayments",
                newName: "SaleInvoicePayment");

            migrationBuilder.RenameIndex(
                name: "IX_SaleInvoicePayments_InvoiceID",
                table: "SaleInvoicePayment",
                newName: "IX_SaleInvoicePayment_InvoiceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleInvoicePayment",
                table: "SaleInvoicePayment",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoicePayment_SaleInvoiceHeaders_InvoiceID",
                table: "SaleInvoicePayment",
                column: "InvoiceID",
                principalTable: "SaleInvoiceHeaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

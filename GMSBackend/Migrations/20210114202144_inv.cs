using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GMSBackend.Migrations
{
    public partial class inv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SaleInvoiceDetails",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeaderID = table.Column<long>(type: "bigint", nullable: false),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    Qty = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Reduction_Percent = table.Column<short>(type: "smallint", nullable: true),
                    Reduction_Price = table.Column<double>(type: "double precision", nullable: true),
                    Memo = table.Column<string>(type: "text", nullable: true),
                    SessionQty = table.Column<int>(type: "integer", nullable: false),
                    SessionReserved = table.Column<int>(type: "integer", nullable: false),
                    SessionUsed = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleInvoiceDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SaleInvoiceHeaders",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AccountID = table.Column<long>(type: "bigint", nullable: false),
                    VisitorID = table.Column<long>(type: "bigint", nullable: true),
                    InvType = table.Column<short>(type: "smallint", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: true),
                    Reduction = table.Column<double>(type: "double precision", nullable: true),
                    Memo = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleInvoiceHeaders", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleInvoiceDetails");

            migrationBuilder.DropTable(
                name: "SaleInvoiceHeaders");
        }
    }
}

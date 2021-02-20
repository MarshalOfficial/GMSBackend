using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GMSBackend.Migrations
{
    public partial class membersessionusagelog1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "member_session_usage_log");

            migrationBuilder.CreateTable(
                name: "client_session_usage_log",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    account_id = table.Column<long>(type: "bigint", nullable: false),
                    sale_invoice_details_id = table.Column<long>(type: "bigint", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    qty = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_session_usage_log", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_session_usage_log_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_client_session_usage_log_sale_invoice_details_sale_invoice_~",
                        column: x => x.sale_invoice_details_id,
                        principalTable: "sale_invoice_details",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_client_session_usage_log_account_id",
                table: "client_session_usage_log",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_client_session_usage_log_sale_invoice_details_id",
                table: "client_session_usage_log",
                column: "sale_invoice_details_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client_session_usage_log");

            migrationBuilder.CreateTable(
                name: "member_session_usage_log",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    account_id = table.Column<long>(type: "bigint", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    sale_invoice_details_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_member_session_usage_log", x => x.id);
                    table.ForeignKey(
                        name: "FK_member_session_usage_log_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_member_session_usage_log_sale_invoice_details_sale_invoice_~",
                        column: x => x.sale_invoice_details_id,
                        principalTable: "sale_invoice_details",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_member_session_usage_log_account_id",
                table: "member_session_usage_log",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_member_session_usage_log_sale_invoice_details_id",
                table: "member_session_usage_log",
                column: "sale_invoice_details_id");
        }
    }
}

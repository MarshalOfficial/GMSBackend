using Microsoft.EntityFrameworkCore.Migrations;

namespace GMSBackend.Migrations
{
    public partial class fixcol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_acc_transactions_account_types_AccountTypeID",
                table: "acc_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_acc_transactions_accounts_AccountID",
                table: "acc_transactions");

            migrationBuilder.DropIndex(
                name: "IX_acc_transactions_AccountID",
                table: "acc_transactions");

            migrationBuilder.DropIndex(
                name: "IX_acc_transactions_AccountTypeID",
                table: "acc_transactions");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "acc_transactions");

            migrationBuilder.DropColumn(
                name: "AccountTypeID",
                table: "acc_transactions");

            migrationBuilder.CreateIndex(
                name: "IX_acc_transactions_account_id",
                table: "acc_transactions",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_acc_transactions_account_type_id",
                table: "acc_transactions",
                column: "account_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_acc_transactions_account_types_account_type_id",
                table: "acc_transactions",
                column: "account_type_id",
                principalTable: "account_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_acc_transactions_accounts_account_id",
                table: "acc_transactions",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_acc_transactions_account_types_account_type_id",
                table: "acc_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_acc_transactions_accounts_account_id",
                table: "acc_transactions");

            migrationBuilder.DropIndex(
                name: "IX_acc_transactions_account_id",
                table: "acc_transactions");

            migrationBuilder.DropIndex(
                name: "IX_acc_transactions_account_type_id",
                table: "acc_transactions");

            migrationBuilder.AddColumn<long>(
                name: "AccountID",
                table: "acc_transactions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeID",
                table: "acc_transactions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_acc_transactions_AccountID",
                table: "acc_transactions",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_acc_transactions_AccountTypeID",
                table: "acc_transactions",
                column: "AccountTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_acc_transactions_account_types_AccountTypeID",
                table: "acc_transactions",
                column: "AccountTypeID",
                principalTable: "account_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_acc_transactions_accounts_AccountID",
                table: "acc_transactions",
                column: "AccountID",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

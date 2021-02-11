using Microsoft.EntityFrameworkCore.Migrations;

namespace GMSBackend.Migrations
{
    public partial class alteraccounttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccTransactions_Accounts_AccountID",
                table: "AccTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceHeaders_Accounts_AccountID",
                table: "SaleInvoiceHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "accounts");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "accounts",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Telegram",
                table: "accounts",
                newName: "telegram");

            migrationBuilder.RenameColumn(
                name: "Tel",
                table: "accounts",
                newName: "tel");

            migrationBuilder.RenameColumn(
                name: "Referral",
                table: "accounts",
                newName: "referral");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "accounts",
                newName: "mobile");

            migrationBuilder.RenameColumn(
                name: "Instagram",
                table: "accounts",
                newName: "instagram");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "accounts",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "accounts",
                newName: "balance");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "accounts",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "accounts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VisitorID",
                table: "accounts",
                newName: "visitor_id");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "accounts",
                newName: "postal_code");

            migrationBuilder.RenameColumn(
                name: "MembershipJoinTypeId",
                table: "accounts",
                newName: "membership_join_type_id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "accounts",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "JoinDate",
                table: "accounts",
                newName: "join_date");

            migrationBuilder.RenameColumn(
                name: "JobInfoId",
                table: "accounts",
                newName: "jobinfo_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "accounts",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "accounts",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "accounts",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "accounts",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "ContractFilePath",
                table: "accounts",
                newName: "contract_file_path");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "accounts",
                newName: "birth_date");

            migrationBuilder.RenameColumn(
                name: "AccountTypeId",
                table: "accounts",
                newName: "account_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accounts",
                table: "accounts",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccTransactions_accounts_AccountID",
                table: "AccTransactions",
                column: "AccountID",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceHeaders_accounts_AccountID",
                table: "SaleInvoiceHeaders",
                column: "AccountID",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccTransactions_accounts_AccountID",
                table: "AccTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceHeaders_accounts_AccountID",
                table: "SaleInvoiceHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accounts",
                table: "accounts");

            migrationBuilder.RenameTable(
                name: "accounts",
                newName: "Accounts");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Accounts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "telegram",
                table: "Accounts",
                newName: "Telegram");

            migrationBuilder.RenameColumn(
                name: "tel",
                table: "Accounts",
                newName: "Tel");

            migrationBuilder.RenameColumn(
                name: "referral",
                table: "Accounts",
                newName: "Referral");

            migrationBuilder.RenameColumn(
                name: "mobile",
                table: "Accounts",
                newName: "Mobile");

            migrationBuilder.RenameColumn(
                name: "instagram",
                table: "Accounts",
                newName: "Instagram");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Accounts",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "balance",
                table: "Accounts",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Accounts",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Accounts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "visitor_id",
                table: "Accounts",
                newName: "VisitorID");

            migrationBuilder.RenameColumn(
                name: "postal_code",
                table: "Accounts",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "membership_join_type_id",
                table: "Accounts",
                newName: "MembershipJoinTypeId");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Accounts",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "join_date",
                table: "Accounts",
                newName: "JoinDate");

            migrationBuilder.RenameColumn(
                name: "jobinfo_id",
                table: "Accounts",
                newName: "JobInfoId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "Accounts",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "Accounts",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Accounts",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Accounts",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "contract_file_path",
                table: "Accounts",
                newName: "ContractFilePath");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "Accounts",
                newName: "Birthdate");

            migrationBuilder.RenameColumn(
                name: "account_type_id",
                table: "Accounts",
                newName: "AccountTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccTransactions_Accounts_AccountID",
                table: "AccTransactions",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceHeaders_Accounts_AccountID",
                table: "SaleInvoiceHeaders",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

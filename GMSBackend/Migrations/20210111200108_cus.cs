using Microsoft.EntityFrameworkCore.Migrations;

namespace GMSBackend.Migrations
{
    public partial class cus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountTypes_AccountTypeId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_JobInfos_JobInfoId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_MembershipJoinTypes_MembershipJoinTypeId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_JobInfoId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_MembershipJoinTypeId",
                table: "Accounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_JobInfoId",
                table: "Accounts",
                column: "JobInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_MembershipJoinTypeId",
                table: "Accounts",
                column: "MembershipJoinTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountTypes_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_JobInfos_JobInfoId",
                table: "Accounts",
                column: "JobInfoId",
                principalTable: "JobInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_MembershipJoinTypes_MembershipJoinTypeId",
                table: "Accounts",
                column: "MembershipJoinTypeId",
                principalTable: "MembershipJoinTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

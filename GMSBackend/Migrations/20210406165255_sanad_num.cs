using Microsoft.EntityFrameworkCore.Migrations;

namespace GMSBackend.Migrations
{
    public partial class sanad_num : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_variz",
                table: "acc_transactions");

            migrationBuilder.AddColumn<long>(
                name: "sanad_num",
                table: "acc_transactions",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sanad_num",
                table: "acc_transactions");

            migrationBuilder.AddColumn<bool>(
                name: "is_variz",
                table: "acc_transactions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}

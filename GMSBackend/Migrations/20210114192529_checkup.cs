using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GMSBackend.Migrations
{
    public partial class checkup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientPeriodicCheckUps",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountID = table.Column<long>(type: "bigint", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: true),
                    Weight = table.Column<double>(type: "double precision", nullable: true),
                    ImgUrl = table.Column<string>(type: "text", nullable: true),
                    WaistSize = table.Column<double>(type: "double precision", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Chest = table.Column<double>(type: "double precision", nullable: true),
                    ABS = table.Column<double>(type: "double precision", nullable: true),
                    BUTT = table.Column<double>(type: "double precision", nullable: true),
                    RightArm = table.Column<double>(type: "double precision", nullable: true),
                    LeftArm = table.Column<double>(type: "double precision", nullable: true),
                    RightThigh = table.Column<double>(type: "double precision", nullable: true),
                    LeftThigh = table.Column<double>(type: "double precision", nullable: true),
                    RightCalves = table.Column<double>(type: "double precision", nullable: true),
                    LeftCalves = table.Column<double>(type: "double precision", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPeriodicCheckUps", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientPeriodicCheckUps");
        }
    }
}

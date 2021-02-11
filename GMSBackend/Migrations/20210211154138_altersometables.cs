using Microsoft.EntityFrameworkCore.Migrations;

namespace GMSBackend.Migrations
{
    public partial class altersometables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccTransactions_accounts_AccountID",
                table: "AccTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_AccTransactions_AccountTypes_AccountTypeID",
                table: "AccTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceDetails_ProductMains_ProductID",
                table: "SaleInvoiceDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMains",
                table: "ProductMains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCodingInfos",
                table: "ProductCodingInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembershipJoinTypes",
                table: "MembershipJoinTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobInfos",
                table: "JobInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientPeriodicCheckUps",
                table: "ClientPeriodicCheckUps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccTransactions",
                table: "AccTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountTypes",
                table: "AccountTypes");

            migrationBuilder.RenameTable(
                name: "ProductMains",
                newName: "product_mains");

            migrationBuilder.RenameTable(
                name: "ProductCodingInfos",
                newName: "product_coding_infos");

            migrationBuilder.RenameTable(
                name: "MembershipJoinTypes",
                newName: "membership_join_types");

            migrationBuilder.RenameTable(
                name: "JobInfos",
                newName: "job_infos");

            migrationBuilder.RenameTable(
                name: "ClientPeriodicCheckUps",
                newName: "client_periodic_checkups");

            migrationBuilder.RenameTable(
                name: "AccTransactions",
                newName: "acc_transactions");

            migrationBuilder.RenameTable(
                name: "AccountTypes",
                newName: "account_types");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "product_mains",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "product_mains",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "SessionCount",
                table: "product_mains",
                newName: "session_count");

            migrationBuilder.RenameColumn(
                name: "SalePrice2",
                table: "product_mains",
                newName: "sale_price2");

            migrationBuilder.RenameColumn(
                name: "SalePrice",
                table: "product_mains",
                newName: "sale_price");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "product_mains",
                newName: "product_name");

            migrationBuilder.RenameColumn(
                name: "ProductCode",
                table: "product_mains",
                newName: "product_code");

            migrationBuilder.RenameColumn(
                name: "ProductBarCode",
                table: "product_mains",
                newName: "product_barcode");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "product_mains",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "product_mains",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "product_mains",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "product_mains",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "CodingID",
                table: "product_mains",
                newName: "coding_id");

            migrationBuilder.RenameColumn(
                name: "BuyPrice",
                table: "product_mains",
                newName: "buy_price");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "product_coding_infos",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "product_coding_infos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "product_coding_infos",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "CodingParent_ID",
                table: "product_coding_infos",
                newName: "coding_parent_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "membership_join_types",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "membership_join_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "job_infos",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "job_infos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "client_periodic_checkups",
                newName: "weight");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "client_periodic_checkups",
                newName: "height");

            migrationBuilder.RenameColumn(
                name: "Chest",
                table: "client_periodic_checkups",
                newName: "chest");

            migrationBuilder.RenameColumn(
                name: "BUTT",
                table: "client_periodic_checkups",
                newName: "butt");

            migrationBuilder.RenameColumn(
                name: "ABS",
                table: "client_periodic_checkups",
                newName: "abs");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "client_periodic_checkups",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WaistSize",
                table: "client_periodic_checkups",
                newName: "waist_size");

            migrationBuilder.RenameColumn(
                name: "SessionNo",
                table: "client_periodic_checkups",
                newName: "session_no");

            migrationBuilder.RenameColumn(
                name: "RightThigh",
                table: "client_periodic_checkups",
                newName: "right_thigh");

            migrationBuilder.RenameColumn(
                name: "RightCalves",
                table: "client_periodic_checkups",
                newName: "right_calves");

            migrationBuilder.RenameColumn(
                name: "RightArm",
                table: "client_periodic_checkups",
                newName: "right_arm");

            migrationBuilder.RenameColumn(
                name: "LeftThigh",
                table: "client_periodic_checkups",
                newName: "left_thigh");

            migrationBuilder.RenameColumn(
                name: "LeftCalves",
                table: "client_periodic_checkups",
                newName: "left_calves");

            migrationBuilder.RenameColumn(
                name: "LeftArm",
                table: "client_periodic_checkups",
                newName: "left_arm");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "client_periodic_checkups",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "client_periodic_checkups",
                newName: "img_url");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "client_periodic_checkups",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "client_periodic_checkups",
                newName: "account_id");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "acc_transactions",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "acc_transactions",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "acc_transactions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "acc_transactions",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "IsVariz",
                table: "acc_transactions",
                newName: "is_variz");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "acc_transactions",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "InvoiceID",
                table: "acc_transactions",
                newName: "invoice_id");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "acc_transactions",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "acc_transactions",
                newName: "create_date");

            migrationBuilder.RenameIndex(
                name: "IX_AccTransactions_AccountTypeID",
                table: "acc_transactions",
                newName: "IX_acc_transactions_AccountTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_AccTransactions_AccountID",
                table: "acc_transactions",
                newName: "IX_acc_transactions_AccountID");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "account_types",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "account_types",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "AccountTypeID",
                table: "acc_transactions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "acc_transactions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "account_id",
                table: "acc_transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "account_type_id",
                table: "acc_transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_mains",
                table: "product_mains",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_coding_infos",
                table: "product_coding_infos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_membership_join_types",
                table: "membership_join_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_job_infos",
                table: "job_infos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_client_periodic_checkups",
                table: "client_periodic_checkups",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_acc_transactions",
                table: "acc_transactions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_account_types",
                table: "account_types",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceDetails_product_mains_ProductID",
                table: "SaleInvoiceDetails",
                column: "ProductID",
                principalTable: "product_mains",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_acc_transactions_account_types_AccountTypeID",
                table: "acc_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_acc_transactions_accounts_AccountID",
                table: "acc_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceDetails_product_mains_ProductID",
                table: "SaleInvoiceDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_mains",
                table: "product_mains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_coding_infos",
                table: "product_coding_infos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_membership_join_types",
                table: "membership_join_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_job_infos",
                table: "job_infos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_client_periodic_checkups",
                table: "client_periodic_checkups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_account_types",
                table: "account_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_acc_transactions",
                table: "acc_transactions");

            migrationBuilder.DropColumn(
                name: "account_id",
                table: "acc_transactions");

            migrationBuilder.DropColumn(
                name: "account_type_id",
                table: "acc_transactions");

            migrationBuilder.RenameTable(
                name: "product_mains",
                newName: "ProductMains");

            migrationBuilder.RenameTable(
                name: "product_coding_infos",
                newName: "ProductCodingInfos");

            migrationBuilder.RenameTable(
                name: "membership_join_types",
                newName: "MembershipJoinTypes");

            migrationBuilder.RenameTable(
                name: "job_infos",
                newName: "JobInfos");

            migrationBuilder.RenameTable(
                name: "client_periodic_checkups",
                newName: "ClientPeriodicCheckUps");

            migrationBuilder.RenameTable(
                name: "account_types",
                newName: "AccountTypes");

            migrationBuilder.RenameTable(
                name: "acc_transactions",
                newName: "AccTransactions");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductMains",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "ProductMains",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "session_count",
                table: "ProductMains",
                newName: "SessionCount");

            migrationBuilder.RenameColumn(
                name: "sale_price2",
                table: "ProductMains",
                newName: "SalePrice2");

            migrationBuilder.RenameColumn(
                name: "sale_price",
                table: "ProductMains",
                newName: "SalePrice");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "ProductMains",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "product_code",
                table: "ProductMains",
                newName: "ProductCode");

            migrationBuilder.RenameColumn(
                name: "product_barcode",
                table: "ProductMains",
                newName: "ProductBarCode");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ProductMains",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ProductMains",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "ProductMains",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "ProductMains",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "coding_id",
                table: "ProductMains",
                newName: "CodingID");

            migrationBuilder.RenameColumn(
                name: "buy_price",
                table: "ProductMains",
                newName: "BuyPrice");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "ProductCodingInfos",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductCodingInfos",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "ProductCodingInfos",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "coding_parent_id",
                table: "ProductCodingInfos",
                newName: "CodingParent_ID");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "MembershipJoinTypes",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MembershipJoinTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "JobInfos",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "JobInfos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "weight",
                table: "ClientPeriodicCheckUps",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "height",
                table: "ClientPeriodicCheckUps",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "chest",
                table: "ClientPeriodicCheckUps",
                newName: "Chest");

            migrationBuilder.RenameColumn(
                name: "butt",
                table: "ClientPeriodicCheckUps",
                newName: "BUTT");

            migrationBuilder.RenameColumn(
                name: "abs",
                table: "ClientPeriodicCheckUps",
                newName: "ABS");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ClientPeriodicCheckUps",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "waist_size",
                table: "ClientPeriodicCheckUps",
                newName: "WaistSize");

            migrationBuilder.RenameColumn(
                name: "session_no",
                table: "ClientPeriodicCheckUps",
                newName: "SessionNo");

            migrationBuilder.RenameColumn(
                name: "right_thigh",
                table: "ClientPeriodicCheckUps",
                newName: "RightThigh");

            migrationBuilder.RenameColumn(
                name: "right_calves",
                table: "ClientPeriodicCheckUps",
                newName: "RightCalves");

            migrationBuilder.RenameColumn(
                name: "right_arm",
                table: "ClientPeriodicCheckUps",
                newName: "RightArm");

            migrationBuilder.RenameColumn(
                name: "left_thigh",
                table: "ClientPeriodicCheckUps",
                newName: "LeftThigh");

            migrationBuilder.RenameColumn(
                name: "left_calves",
                table: "ClientPeriodicCheckUps",
                newName: "LeftCalves");

            migrationBuilder.RenameColumn(
                name: "left_arm",
                table: "ClientPeriodicCheckUps",
                newName: "LeftArm");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ClientPeriodicCheckUps",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "img_url",
                table: "ClientPeriodicCheckUps",
                newName: "ImgUrl");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "ClientPeriodicCheckUps",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "ClientPeriodicCheckUps",
                newName: "AccountID");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "AccountTypes",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AccountTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "AccTransactions",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "AccTransactions",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AccTransactions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AccTransactions",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "is_variz",
                table: "AccTransactions",
                newName: "IsVariz");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "AccTransactions",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "invoice_id",
                table: "AccTransactions",
                newName: "InvoiceID");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                table: "AccTransactions",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "AccTransactions",
                newName: "CreateDate");

            migrationBuilder.RenameIndex(
                name: "IX_acc_transactions_AccountTypeID",
                table: "AccTransactions",
                newName: "IX_AccTransactions_AccountTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_acc_transactions_AccountID",
                table: "AccTransactions",
                newName: "IX_AccTransactions_AccountID");

            migrationBuilder.AlterColumn<int>(
                name: "AccountTypeID",
                table: "AccTransactions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "AccTransactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMains",
                table: "ProductMains",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCodingInfos",
                table: "ProductCodingInfos",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembershipJoinTypes",
                table: "MembershipJoinTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobInfos",
                table: "JobInfos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientPeriodicCheckUps",
                table: "ClientPeriodicCheckUps",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountTypes",
                table: "AccountTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccTransactions",
                table: "AccTransactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccTransactions_accounts_AccountID",
                table: "AccTransactions",
                column: "AccountID",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccTransactions_AccountTypes_AccountTypeID",
                table: "AccTransactions",
                column: "AccountTypeID",
                principalTable: "AccountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceDetails_ProductMains_ProductID",
                table: "SaleInvoiceDetails",
                column: "ProductID",
                principalTable: "ProductMains",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

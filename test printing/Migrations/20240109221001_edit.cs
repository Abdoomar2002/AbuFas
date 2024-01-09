using Microsoft.EntityFrameworkCore.Migrations;

namespace AbuFas.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillData_Bills_BillId",
                table: "BillData");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_DaystaticMoney_MoneyId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowsData_Borrows_BorrowId",
                table: "BorrowsData");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersData_Customers_CustomerId",
                table: "CustomersData");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomersData",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BorrowId",
                table: "BorrowsData",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MoneyId",
                table: "Bills",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "BillData",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillData_Bills_BillId",
                table: "BillData",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_DaystaticMoney_MoneyId",
                table: "Bills",
                column: "MoneyId",
                principalTable: "DaystaticMoney",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowsData_Borrows_BorrowId",
                table: "BorrowsData",
                column: "BorrowId",
                principalTable: "Borrows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersData_Customers_CustomerId",
                table: "CustomersData",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillData_Bills_BillId",
                table: "BillData");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_DaystaticMoney_MoneyId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowsData_Borrows_BorrowId",
                table: "BorrowsData");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersData_Customers_CustomerId",
                table: "CustomersData");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomersData",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BorrowId",
                table: "BorrowsData",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MoneyId",
                table: "Bills",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "BillData",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BillData_Bills_BillId",
                table: "BillData",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_DaystaticMoney_MoneyId",
                table: "Bills",
                column: "MoneyId",
                principalTable: "DaystaticMoney",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowsData_Borrows_BorrowId",
                table: "BorrowsData",
                column: "BorrowId",
                principalTable: "Borrows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersData_Customers_CustomerId",
                table: "CustomersData",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

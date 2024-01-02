using Microsoft.EntityFrameworkCore.Migrations;

namespace AbuFas.Migrations
{
    public partial class edit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillData_Bills_BillsId",
                table: "BillData");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_DaystaticMoney_DaystaticMoneyId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeOutcome_DaystaticMoney_DaystaticMoneyId",
                table: "IncomeOutcome");

            migrationBuilder.DropIndex(
                name: "IX_IncomeOutcome_DaystaticMoneyId",
                table: "IncomeOutcome");

            migrationBuilder.DropIndex(
                name: "IX_Bills_DaystaticMoneyId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_BillData_BillsId",
                table: "BillData");

            migrationBuilder.DropColumn(
                name: "DaystaticMoneyId",
                table: "IncomeOutcome");

            migrationBuilder.DropColumn(
                name: "DaystaticMoneyId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "BillsId",
                table: "BillData");

            migrationBuilder.AddColumn<int>(
                name: "MoneyId",
                table: "IncomeOutcome",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoneyId",
                table: "Bills",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "BillData",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncomeOutcome_MoneyId",
                table: "IncomeOutcome",
                column: "MoneyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_MoneyId",
                table: "Bills",
                column: "MoneyId");

            migrationBuilder.CreateIndex(
                name: "IX_BillData_BillId",
                table: "BillData",
                column: "BillId");

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
                name: "FK_IncomeOutcome_DaystaticMoney_MoneyId",
                table: "IncomeOutcome",
                column: "MoneyId",
                principalTable: "DaystaticMoney",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                name: "FK_IncomeOutcome_DaystaticMoney_MoneyId",
                table: "IncomeOutcome");

            migrationBuilder.DropIndex(
                name: "IX_IncomeOutcome_MoneyId",
                table: "IncomeOutcome");

            migrationBuilder.DropIndex(
                name: "IX_Bills_MoneyId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_BillData_BillId",
                table: "BillData");

            migrationBuilder.DropColumn(
                name: "MoneyId",
                table: "IncomeOutcome");

            migrationBuilder.DropColumn(
                name: "MoneyId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "BillData");

            migrationBuilder.AddColumn<int>(
                name: "DaystaticMoneyId",
                table: "IncomeOutcome",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DaystaticMoneyId",
                table: "Bills",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillsId",
                table: "BillData",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncomeOutcome_DaystaticMoneyId",
                table: "IncomeOutcome",
                column: "DaystaticMoneyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_DaystaticMoneyId",
                table: "Bills",
                column: "DaystaticMoneyId");

            migrationBuilder.CreateIndex(
                name: "IX_BillData_BillsId",
                table: "BillData",
                column: "BillsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillData_Bills_BillsId",
                table: "BillData",
                column: "BillsId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_DaystaticMoney_DaystaticMoneyId",
                table: "Bills",
                column: "DaystaticMoneyId",
                principalTable: "DaystaticMoney",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeOutcome_DaystaticMoney_DaystaticMoneyId",
                table: "IncomeOutcome",
                column: "DaystaticMoneyId",
                principalTable: "DaystaticMoney",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

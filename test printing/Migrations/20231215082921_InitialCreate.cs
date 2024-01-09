using Microsoft.EntityFrameworkCore.Migrations;

namespace AbuFas.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DaystaticMoneyId",
                table: "IncomeOutcome",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DaystaticMoneyId",
                table: "Bills",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InOut_DaystaticMoneyId",
                table: "IncomeOutcome",
                column: "DaystaticMoneyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_DaystaticMoneyId",
                table: "Bills",
                column: "DaystaticMoneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_DayMoney_DaystaticMoneyId",
                table: "Bills",
                column: "DaystaticMoneyId",
                principalTable: "DayStaticMoney",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InOut_DayMoney_DaystaticMoneyId",
                table: "IncomeOutcome",
                column: "DaystaticMoneyId",
                principalTable: "DayStaticMoney",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_DayMoney_DaystaticMoneyId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_InOut_DayMoney_DaystaticMoneyId",
                table: "IncomeOutcome");

            migrationBuilder.DropIndex(
                name: "IX_InOut_DaystaticMoneyId",
                table: "IncomeOutcome");

            migrationBuilder.DropIndex(
                name: "IX_Bills_DaystaticMoneyId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "DaystaticMoneyId",
                table: "IncomeOutcome");

            migrationBuilder.DropColumn(
                name: "DaystaticMoneyId",
                table: "Bills");
        }
    }
}

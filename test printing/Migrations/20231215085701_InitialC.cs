using Microsoft.EntityFrameworkCore.Migrations;

namespace AbuFas.Migrations
{
    public partial class InitialC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_DayMoney_DaystaticMoneyId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_InOut_DayMoney_DaystaticMoneyId",
                table: "InOut");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InOut",
                table: "InOut");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayMoney",
                table: "DayMoney");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayGram",
                table: "DayGram");

            migrationBuilder.RenameTable(
                name: "InOut",
                newName: "IncomeOutcome");

            migrationBuilder.RenameTable(
                name: "DayMoney",
                newName: "DaystaticMoney");

            migrationBuilder.RenameTable(
                name: "DayGram",
                newName: "DayStaticGrams");

            migrationBuilder.RenameIndex(
                name: "IX_InOut_DaystaticMoneyId",
                table: "IncomeOutcome",
                newName: "IX_IncomeOutcome_DaystaticMoneyId");

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Bills",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncomeOutcome",
                table: "IncomeOutcome",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DaystaticMoney",
                table: "DaystaticMoney",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayStaticGrams",
                table: "DayStaticGrams",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_DaystaticMoney_DaystaticMoneyId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeOutcome_DaystaticMoney_DaystaticMoneyId",
                table: "IncomeOutcome");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncomeOutcome",
                table: "IncomeOutcome");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DaystaticMoney",
                table: "DaystaticMoney");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayStaticGrams",
                table: "DayStaticGrams");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Bills");

            migrationBuilder.RenameTable(
                name: "IncomeOutcome",
                newName: "InOut");

            migrationBuilder.RenameTable(
                name: "DaystaticMoney",
                newName: "DayMoney");

            migrationBuilder.RenameTable(
                name: "DayStaticGrams",
                newName: "DayGram");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeOutcome_DaystaticMoneyId",
                table: "InOut",
                newName: "IX_InOut_DaystaticMoneyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InOut",
                table: "InOut",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayMoney",
                table: "DayMoney",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayGram",
                table: "DayGram",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_DayMoney_DaystaticMoneyId",
                table: "Bills",
                column: "DaystaticMoneyId",
                principalTable: "DayMoney",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InOut_DayMoney_DaystaticMoneyId",
                table: "InOut",
                column: "DaystaticMoneyId",
                principalTable: "DayMoney",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

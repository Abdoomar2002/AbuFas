using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbuFas.Migrations
{
    public partial class newO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Bills",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "DayStaticGrams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Sell = table.Column<double>(nullable: false),
                    Buy = table.Column<double>(nullable: false),
                    Bouns = table.Column<double>(nullable: false),
                    Minus = table.Column<double>(nullable: false),
                    Damaged = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayGram", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DaystaticMoney",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Type = table.Column<bool>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayMoney", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeOutcome",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    IsIncome = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InOut", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayGram");

            migrationBuilder.DropTable(
                name: "DayMoney");

            migrationBuilder.DropTable(
                name: "IncomeOutcome");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Bills");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbuFas.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Borrows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    TotalGrams = table.Column<double>(nullable: false),
                    TotalMoney = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

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
                    table.PrimaryKey("PK_DayStaticGrams", x => x.Id);
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
                    table.PrimaryKey("PK_DaystaticMoney", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BorrowsData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Incoume = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Outcome = table.Column<double>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    BorrowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowsData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowsData_Borrows_BorrowId",
                        column: x => x.BorrowId,
                        principalTable: "Borrows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Grams = table.Column<double>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    IsIncome = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersData_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    IsBuy = table.Column<bool>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    MoneyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_DaystaticMoney_MoneyId",
                        column: x => x.MoneyId,
                        principalTable: "DaystaticMoney",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IsIncome = table.Column<bool>(nullable: false),
                    MoneyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeOutcome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeOutcome_DaystaticMoney_MoneyId",
                        column: x => x.MoneyId,
                        principalTable: "DaystaticMoney",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Type = table.Column<double>(nullable: false),
                    Kyrat = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillData_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillData_BillId",
                table: "BillData",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_MoneyId",
                table: "Bills",
                column: "MoneyId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowsData_BorrowId",
                table: "BorrowsData",
                column: "BorrowId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersData_CustomerId",
                table: "CustomersData",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeOutcome_MoneyId",
                table: "IncomeOutcome",
                column: "MoneyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillData");

            migrationBuilder.DropTable(
                name: "BorrowsData");

            migrationBuilder.DropTable(
                name: "CustomersData");

            migrationBuilder.DropTable(
                name: "DayStaticGrams");

            migrationBuilder.DropTable(
                name: "IncomeOutcome");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Borrows");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DaystaticMoney");
        }
    }
}

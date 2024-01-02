using Microsoft.EntityFrameworkCore.Migrations;

namespace AbuFas.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    IsBuy = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
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
                    BillsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillData_Bills_BillsId",
                        column: x => x.BillsId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillData_BillsId",
                table: "BillData",
                column: "BillsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillData");

            migrationBuilder.DropTable(
                name: "Bills");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bak.ThirdPlatforms.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    UserNo = table.Column<string>(maxLength: 20, nullable: false),
                    OrderNo = table.Column<long>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Money = table.Column<decimal>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppOrderLine",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(nullable: false),
                    ProductNo = table.Column<string>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOrderLine", x => new { x.OrderId, x.ProductNo });
                    table.ForeignKey(
                        name: "FK_AppOrderLine_AppOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "AppOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppOrderLine");

            migrationBuilder.DropTable(
                name: "AppOrders");
        }
    }
}

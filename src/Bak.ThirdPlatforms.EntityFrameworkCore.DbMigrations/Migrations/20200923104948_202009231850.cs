using Microsoft.EntityFrameworkCore.Migrations;

namespace Bak.ThirdPlatforms.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class _202009231850 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrderLine_AppOrders_OrderId",
                table: "AppOrderLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppOrderLine",
                table: "AppOrderLine");

            migrationBuilder.RenameTable(
                name: "AppOrderLine",
                newName: "AppOrderLines");

            migrationBuilder.AlterColumn<string>(
                name: "ProductNo",
                table: "AppOrderLines",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppOrderLines",
                table: "AppOrderLines",
                columns: new[] { "OrderId", "ProductNo" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrderLines_AppOrders_OrderId",
                table: "AppOrderLines",
                column: "OrderId",
                principalTable: "AppOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrderLines_AppOrders_OrderId",
                table: "AppOrderLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppOrderLines",
                table: "AppOrderLines");

            migrationBuilder.RenameTable(
                name: "AppOrderLines",
                newName: "AppOrderLine");

            migrationBuilder.AlterColumn<string>(
                name: "ProductNo",
                table: "AppOrderLine",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppOrderLine",
                table: "AppOrderLine",
                columns: new[] { "OrderId", "ProductNo" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrderLine_AppOrders_OrderId",
                table: "AppOrderLine",
                column: "OrderId",
                principalTable: "AppOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

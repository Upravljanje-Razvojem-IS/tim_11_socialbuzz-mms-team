using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsAndServices.Migrations
{
    public partial class MockForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ServiceTypes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MockUserId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProductTypes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MockUserId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_Description",
                table: "ServiceTypes",
                column: "Description",
                unique: true,
                filter: "[Description] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_Description",
                table: "ProductTypes",
                column: "Description",
                unique: true,
                filter: "[Description] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceTypes_Description",
                table: "ServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_Description",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "MockUserId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "MockUserId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ServiceTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}

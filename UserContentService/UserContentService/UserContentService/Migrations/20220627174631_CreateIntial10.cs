using Microsoft.EntityFrameworkCore.Migrations;

namespace UserContentService.Migrations
{
    public partial class CreateIntial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Ads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_UserId",
                table: "Contents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_UserId",
                table: "Ads",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Users_UserId",
                table: "Ads",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Users_UserId",
                table: "Contents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Users_UserId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Users_UserId",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_UserId",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Ads_UserId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ads");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

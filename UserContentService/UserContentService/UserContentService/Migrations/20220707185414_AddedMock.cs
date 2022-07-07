using Microsoft.EntityFrameworkCore.Migrations;

namespace UserContentService.Migrations
{
    public partial class AddedMock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PASId",
                table: "Ads",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PASId",
                table: "Ads");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace UserService.Migrations
{
    public partial class AddedPersonalAndCorporate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorporateUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CorporationName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PIB = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateUsers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalUsers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorporateUsers_CorporationName",
                table: "CorporateUsers",
                column: "CorporationName",
                unique: true,
                filter: "[CorporationName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateUsers_PIB",
                table: "CorporateUsers",
                column: "PIB",
                unique: true,
                filter: "[PIB] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorporateUsers");

            migrationBuilder.DropTable(
                name: "PersonalUsers");
        }
    }
}

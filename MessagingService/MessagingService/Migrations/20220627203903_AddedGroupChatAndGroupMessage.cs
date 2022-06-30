using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessagingService.Migrations
{
    public partial class AddedGroupChatAndGroupMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupChatId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupMessageId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "groupChats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupChats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "groupMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    GroupChatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_groupMessages_groupChats_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "groupChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupChatId",
                table: "Users",
                column: "GroupChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupMessageId",
                table: "Users",
                column: "GroupMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_groupMessages_GroupChatId",
                table: "groupMessages",
                column: "GroupChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_groupChats_GroupChatId",
                table: "Users",
                column: "GroupChatId",
                principalTable: "groupChats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_groupMessages_GroupMessageId",
                table: "Users",
                column: "GroupMessageId",
                principalTable: "groupMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_groupChats_GroupChatId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_groupMessages_GroupMessageId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "groupMessages");

            migrationBuilder.DropTable(
                name: "groupChats");

            migrationBuilder.DropIndex(
                name: "IX_Users_GroupChatId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GroupMessageId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GroupChatId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GroupMessageId",
                table: "Users");
        }
    }
}

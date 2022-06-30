using Microsoft.EntityFrameworkCore.Migrations;

namespace MessagingService.Migrations
{
    public partial class AddedUserGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_groupMessages_groupChats_GroupChatId",
                table: "groupMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_groupChats_GroupChatId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_groupMessages_GroupMessageId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_groupMessages",
                table: "groupMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_groupChats",
                table: "groupChats");

            migrationBuilder.RenameTable(
                name: "groupMessages",
                newName: "GroupMessages");

            migrationBuilder.RenameTable(
                name: "groupChats",
                newName: "GroupChats");

            migrationBuilder.RenameIndex(
                name: "IX_groupMessages_GroupChatId",
                table: "GroupMessages",
                newName: "IX_GroupMessages_GroupChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupMessages",
                table: "GroupMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupChats",
                table: "GroupChats",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GroupChatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroups_GroupChats_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "GroupChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_GroupChatId",
                table: "UserGroups",
                column: "GroupChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_UserId",
                table: "UserGroups",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMessages_GroupChats_GroupChatId",
                table: "GroupMessages",
                column: "GroupChatId",
                principalTable: "GroupChats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GroupChats_GroupChatId",
                table: "Users",
                column: "GroupChatId",
                principalTable: "GroupChats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GroupMessages_GroupMessageId",
                table: "Users",
                column: "GroupMessageId",
                principalTable: "GroupMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMessages_GroupChats_GroupChatId",
                table: "GroupMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_GroupChats_GroupChatId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_GroupMessages_GroupMessageId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupMessages",
                table: "GroupMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupChats",
                table: "GroupChats");

            migrationBuilder.RenameTable(
                name: "GroupMessages",
                newName: "groupMessages");

            migrationBuilder.RenameTable(
                name: "GroupChats",
                newName: "groupChats");

            migrationBuilder.RenameIndex(
                name: "IX_GroupMessages_GroupChatId",
                table: "groupMessages",
                newName: "IX_groupMessages_GroupChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_groupMessages",
                table: "groupMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_groupChats",
                table: "groupChats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_groupMessages_groupChats_GroupChatId",
                table: "groupMessages",
                column: "GroupChatId",
                principalTable: "groupChats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}

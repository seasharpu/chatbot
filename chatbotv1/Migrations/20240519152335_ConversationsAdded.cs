using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chatbotv1.Migrations
{
    /// <inheritdoc />
    public partial class ConversationsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "inputText",
                table: "UserQueries",
                newName: "InputText");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "UserQueries",
                newName: "Created");

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "UserQueries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "lastActivity",
                value: new DateTime(2024, 5, 19, 17, 23, 35, 512, DateTimeKind.Local).AddTicks(5224));

            migrationBuilder.CreateIndex(
                name: "IX_UserQueries_HistoryId",
                table: "UserQueries",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_UserId",
                table: "Conversations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQueries_Conversations_HistoryId",
                table: "UserQueries",
                column: "HistoryId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQueries_Conversations_HistoryId",
                table: "UserQueries");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropIndex(
                name: "IX_UserQueries_HistoryId",
                table: "UserQueries");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "UserQueries");

            migrationBuilder.RenameColumn(
                name: "InputText",
                table: "UserQueries",
                newName: "inputText");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "UserQueries",
                newName: "created");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "lastActivity",
                value: new DateTime(2024, 4, 25, 20, 59, 12, 134, DateTimeKind.Local).AddTicks(6204));
        }
    }
}

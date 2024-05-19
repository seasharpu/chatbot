using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chatbotv1.Migrations
{
    /// <inheritdoc />
    public partial class AddedOpenAIUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName", "lastActivity" },
                values: new object[] { 1, "SuperSecretPassword", "OpenAI", new DateTime(2024, 4, 25, 20, 59, 12, 134, DateTimeKind.Local).AddTicks(6204) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

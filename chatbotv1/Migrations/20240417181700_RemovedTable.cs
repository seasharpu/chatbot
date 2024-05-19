﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chatbotv1.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firebase");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firebase",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firebase", x => x.Id);
                });
        }
    }
}

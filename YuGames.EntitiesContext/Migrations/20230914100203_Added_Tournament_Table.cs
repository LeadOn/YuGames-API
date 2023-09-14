﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YuGames.EntitiesContext.Migrations
{
    /// <inheritdoc />
    public partial class Added_Tournament_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "Player",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 14, 10, 2, 3, 152, DateTimeKind.Utc).AddTicks(5410),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 12, 11, 9, 42, 497, DateTimeKind.Utc).AddTicks(9950));

            migrationBuilder.AlterColumn<DateTime>(
                name: "played_on",
                table: "FifaGamePlayed",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 14, 12, 2, 3, 152, DateTimeKind.Local).AddTicks(6040),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 12, 13, 9, 42, 498, DateTimeKind.Local).AddTicks(470));

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: true),
                    state = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    logo_url = table.Column<string>(type: "TEXT", maxLength: 3000, nullable: true),
                    planned_from = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2023, 9, 14, 10, 2, 3, 149, DateTimeKind.Utc).AddTicks(60)),
                    planned_to = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2023, 9, 15, 10, 2, 3, 149, DateTimeKind.Utc).AddTicks(140))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "Player",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 12, 11, 9, 42, 497, DateTimeKind.Utc).AddTicks(9950),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 14, 10, 2, 3, 152, DateTimeKind.Utc).AddTicks(5410));

            migrationBuilder.AlterColumn<DateTime>(
                name: "played_on",
                table: "FifaGamePlayed",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 12, 13, 9, 42, 498, DateTimeKind.Local).AddTicks(470),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 14, 12, 2, 3, 152, DateTimeKind.Local).AddTicks(6040));
        }
    }
}

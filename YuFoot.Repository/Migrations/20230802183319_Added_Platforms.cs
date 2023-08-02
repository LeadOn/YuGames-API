﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YuFoot.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Added_Platforms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "Player",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 2, 20, 33, 19, 57, DateTimeKind.Local).AddTicks(7568),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 8, 2, 11, 22, 29, 926, DateTimeKind.Local).AddTicks(2040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "played_on",
                table: "GamePlayed",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 2, 20, 33, 19, 57, DateTimeKind.Local).AddTicks(5418),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 8, 2, 11, 22, 29, 926, DateTimeKind.Local).AddTicks(1600));

            migrationBuilder.AddColumn<int>(
                name: "PlatformId",
                table: "GamePlayed",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayed_PlatformId",
                table: "GamePlayed",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayed_Platform",
                table: "GamePlayed",
                column: "PlatformId",
                principalTable: "Platform",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayed_Platform",
                table: "GamePlayed");

            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropIndex(
                name: "IX_GamePlayed_PlatformId",
                table: "GamePlayed");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "GamePlayed");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "Player",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 2, 11, 22, 29, 926, DateTimeKind.Local).AddTicks(2040),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 8, 2, 20, 33, 19, 57, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.AlterColumn<DateTime>(
                name: "played_on",
                table: "GamePlayed",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 2, 11, 22, 29, 926, DateTimeKind.Local).AddTicks(1600),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 8, 2, 20, 33, 19, 57, DateTimeKind.Local).AddTicks(5418));
        }
    }
}

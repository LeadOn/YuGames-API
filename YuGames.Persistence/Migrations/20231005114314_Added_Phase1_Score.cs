﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YuGames.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_Phase1_Score : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "joined_at",
                table: "TournamentPlayer",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 5, 11, 43, 14, 560, DateTimeKind.Utc).AddTicks(8400),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 18, 19, 9, 17, 179, DateTimeKind.Utc).AddTicks(3533));

            migrationBuilder.AddColumn<int>(
                name: "phase_1_score",
                table: "TournamentPlayer",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "planned_to",
                table: "Tournament",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 6, 11, 43, 14, 560, DateTimeKind.Utc).AddTicks(8080),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 19, 19, 9, 17, 179, DateTimeKind.Utc).AddTicks(2959));

            migrationBuilder.AlterColumn<DateTime>(
                name: "planned_from",
                table: "Tournament",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 5, 11, 43, 14, 560, DateTimeKind.Utc).AddTicks(8000),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 18, 19, 9, 17, 179, DateTimeKind.Utc).AddTicks(2841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "Player",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 5, 11, 43, 14, 561, DateTimeKind.Utc).AddTicks(580),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 18, 19, 9, 17, 179, DateTimeKind.Utc).AddTicks(7572));

            migrationBuilder.AlterColumn<DateTime>(
                name: "played_on",
                table: "FifaGamePlayed",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 5, 13, 43, 14, 561, DateTimeKind.Local).AddTicks(1220),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 18, 21, 9, 17, 179, DateTimeKind.Local).AddTicks(8492));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phase_1_score",
                table: "TournamentPlayer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "joined_at",
                table: "TournamentPlayer",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 18, 19, 9, 17, 179, DateTimeKind.Utc).AddTicks(3533),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 10, 5, 11, 43, 14, 560, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "planned_to",
                table: "Tournament",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 19, 19, 9, 17, 179, DateTimeKind.Utc).AddTicks(2959),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 43, 14, 560, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "planned_from",
                table: "Tournament",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 18, 19, 9, 17, 179, DateTimeKind.Utc).AddTicks(2841),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 10, 5, 11, 43, 14, 560, DateTimeKind.Utc).AddTicks(8000));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "Player",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 18, 19, 9, 17, 179, DateTimeKind.Utc).AddTicks(7572),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 10, 5, 11, 43, 14, 561, DateTimeKind.Utc).AddTicks(580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "played_on",
                table: "FifaGamePlayed",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 18, 21, 9, 17, 179, DateTimeKind.Local).AddTicks(8492),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 10, 5, 13, 43, 14, 561, DateTimeKind.Local).AddTicks(1220));
        }
    }
}

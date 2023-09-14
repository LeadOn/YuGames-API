﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YuGames.EntitiesContext;

#nullable disable

namespace YuGames.EntitiesContext.Migrations
{
    [DbContext(typeof(YuGamesContext))]
    partial class YuGamesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("YuGames.Entities.FifaGamePlayed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER")
                        .HasColumnName("created_by_id");

                    b.Property<int>("PlatformId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("platform_id");

                    b.Property<DateTime>("PlayedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2023, 9, 14, 12, 2, 3, 152, DateTimeKind.Local).AddTicks(6040))
                        .HasColumnName("played_on");

                    b.Property<int>("SeasonId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("season_id");

                    b.Property<int?>("Team1Id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("team_1_id");

                    b.Property<int?>("Team2Id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("team_2_id");

                    b.Property<string>("TeamCode1")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT")
                        .HasColumnName("team_code_1");

                    b.Property<string>("TeamCode2")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT")
                        .HasColumnName("team_code_2");

                    b.Property<int>("TeamScore1")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0)
                        .HasColumnName("team_score_1");

                    b.Property<int>("TeamScore2")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0)
                        .HasColumnName("team_score_2");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PlatformId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.ToTable("FifaGamePlayed", (string)null);
                });

            modelBuilder.Entity("YuGames.Entities.FifaTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("FifaTeam", (string)null);
                });

            modelBuilder.Entity("YuGames.Entities.FifaTeamPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("FifaGameId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("fifa_game_id");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("player_id");

                    b.Property<int>("Team")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0)
                        .HasColumnName("team");

                    b.HasKey("Id");

                    b.HasIndex("FifaGameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("FifaTeamPlayer", (string)null);
                });

            modelBuilder.Entity("YuGames.Entities.Highlight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER")
                        .HasColumnName("created_by_id");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("ExternalUrl")
                        .HasMaxLength(3000)
                        .HasColumnType("TEXT")
                        .HasColumnName("external_url");

                    b.Property<int>("FifaGameId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("fifa_game_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("FifaGameId");

                    b.ToTable("Highlight", (string)null);
                });

            modelBuilder.Entity("YuGames.Entities.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Platform", (string)null);
                });

            modelBuilder.Entity("YuGames.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2023, 9, 14, 10, 2, 3, 152, DateTimeKind.Utc).AddTicks(5410))
                        .HasColumnName("created_on");

                    b.Property<string>("FullName")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("full_name");

                    b.Property<string>("KeycloakId")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("keycloak_id");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("nickname");

                    b.Property<string>("ProfilePictureUrl")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT")
                        .HasColumnName("profile_picture_url");

                    b.HasKey("Id");

                    b.ToTable("Player", (string)null);
                });

            modelBuilder.Entity("YuGames.Entities.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Season", (string)null);
                });

            modelBuilder.Entity("YuGames.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("LogoUrl")
                        .HasMaxLength(3000)
                        .HasColumnType("TEXT")
                        .HasColumnName("logo_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<DateTime>("PlannedFrom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2023, 9, 14, 10, 2, 3, 149, DateTimeKind.Utc).AddTicks(60))
                        .HasColumnName("planned_from");

                    b.Property<DateTime>("PlannedTo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2023, 9, 15, 10, 2, 3, 149, DateTimeKind.Utc).AddTicks(140))
                        .HasColumnName("planned_to");

                    b.Property<int>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0)
                        .HasColumnName("state");

                    b.HasKey("Id");

                    b.ToTable("Tournament", (string)null);
                });

            modelBuilder.Entity("YuGames.Entities.FifaGamePlayed", b =>
                {
                    b.HasOne("YuGames.Entities.Player", "CreatedBy")
                        .WithMany("FifaGameCreated")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FifaGamePlayed_Player_Created_By");

                    b.HasOne("YuGames.Entities.Platform", "Platform")
                        .WithMany("GamesPlayed")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FifaGamePlayed_Platform");

                    b.HasOne("YuGames.Entities.Season", "Season")
                        .WithMany("FifaGamePlayed")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FifaGamePlayed_Season");

                    b.HasOne("YuGames.Entities.FifaTeam", "Team1")
                        .WithMany("GamesPlayedTeam1")
                        .HasForeignKey("Team1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_FifaGamePlayed_FifaTeam1");

                    b.HasOne("YuGames.Entities.FifaTeam", "Team2")
                        .WithMany("GamesPlayedTeam2")
                        .HasForeignKey("Team2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_FifaGamePlayed_FifaTeam2");

                    b.Navigation("CreatedBy");

                    b.Navigation("Platform");

                    b.Navigation("Season");

                    b.Navigation("Team1");

                    b.Navigation("Team2");
                });

            modelBuilder.Entity("YuGames.Entities.FifaTeamPlayer", b =>
                {
                    b.HasOne("YuGames.Entities.FifaGamePlayed", "FifaGamePlayed")
                        .WithMany("TeamPlayers")
                        .HasForeignKey("FifaGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FifaTeamPlayer_FifaGamePlayed");

                    b.HasOne("YuGames.Entities.Player", "Player")
                        .WithMany("FifaTeamPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FifaTeamPlayer_Player");

                    b.Navigation("FifaGamePlayed");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("YuGames.Entities.Highlight", b =>
                {
                    b.HasOne("YuGames.Entities.Player", "CreatedBy")
                        .WithMany("Highlights")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Highlight_Player_Created_By");

                    b.HasOne("YuGames.Entities.FifaGamePlayed", "FifaGame")
                        .WithMany("Highlights")
                        .HasForeignKey("FifaGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FifaGame_Highlight");

                    b.Navigation("CreatedBy");

                    b.Navigation("FifaGame");
                });

            modelBuilder.Entity("YuGames.Entities.FifaGamePlayed", b =>
                {
                    b.Navigation("Highlights");

                    b.Navigation("TeamPlayers");
                });

            modelBuilder.Entity("YuGames.Entities.FifaTeam", b =>
                {
                    b.Navigation("GamesPlayedTeam1");

                    b.Navigation("GamesPlayedTeam2");
                });

            modelBuilder.Entity("YuGames.Entities.Platform", b =>
                {
                    b.Navigation("GamesPlayed");
                });

            modelBuilder.Entity("YuGames.Entities.Player", b =>
                {
                    b.Navigation("FifaGameCreated");

                    b.Navigation("FifaTeamPlayers");

                    b.Navigation("Highlights");
                });

            modelBuilder.Entity("YuGames.Entities.Season", b =>
                {
                    b.Navigation("FifaGamePlayed");
                });
#pragma warning restore 612, 618
        }
    }
}

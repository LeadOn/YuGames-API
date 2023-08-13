﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YuFoot.EntitiesContext;

#nullable disable

namespace YuFoot.EntitiesContext.Migrations
{
    [DbContext(typeof(YuFootContext))]
    partial class YuFootContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("YuFoot.Entities.FifaTeam", b =>
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

            modelBuilder.Entity("YuFoot.Entities.GamePlayed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlatformId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PlayedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2023, 8, 13, 19, 18, 55, 466, DateTimeKind.Local).AddTicks(7690))
                        .HasColumnName("played_on");

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
                        .HasMaxLength(100)
                        .HasColumnType("INTEGER")
                        .HasColumnName("team_score_1");

                    b.Property<int>("TeamScore2")
                        .HasMaxLength(100)
                        .HasColumnType("INTEGER")
                        .HasColumnName("team_score_2");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PlatformId");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.ToTable("GamePlayed", (string)null);
                });

            modelBuilder.Entity("YuFoot.Entities.Highlight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExternalUrl")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("TEXT")
                        .HasColumnName("external_url");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("GameId");

                    b.ToTable("Highlight", (string)null);
                });

            modelBuilder.Entity("YuFoot.Entities.Platform", b =>
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

            modelBuilder.Entity("YuFoot.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2023, 8, 13, 19, 18, 55, 466, DateTimeKind.Local).AddTicks(8740))
                        .HasColumnName("created_on");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("full_name");

                    b.Property<string>("KeycloakId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("keycloak_id");

                    b.Property<string>("Nickname")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("nickname");

                    b.Property<string>("ProfilePictureUrl")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT")
                        .HasColumnName("profile_picture_url");

                    b.HasKey("Id");

                    b.ToTable("Player", (string)null);
                });

            modelBuilder.Entity("YuFoot.Entities.TeamPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("GamePlayedId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("player_id");

                    b.Property<int>("Team")
                        .HasColumnType("INTEGER")
                        .HasColumnName("team");

                    b.HasKey("Id");

                    b.HasIndex("GamePlayedId");

                    b.HasIndex("PlayerId");

                    b.ToTable("TeamPlayer", (string)null);
                });

            modelBuilder.Entity("YuFoot.Entities.GamePlayed", b =>
                {
                    b.HasOne("YuFoot.Entities.Player", "CreatedBy")
                        .WithMany("GamesCreated")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_GamePlayed_CreatedBy");

                    b.HasOne("YuFoot.Entities.Platform", "Platform")
                        .WithMany("GamesPlayed")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_GamePlayed_Platform");

                    b.HasOne("YuFoot.Entities.FifaTeam", "Team1")
                        .WithMany("GamesPlayedTeam1")
                        .HasForeignKey("Team1Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_FifaTeam_GamePlayed_Team1");

                    b.HasOne("YuFoot.Entities.FifaTeam", "Team2")
                        .WithMany("GamesPlayedTeam2")
                        .HasForeignKey("Team2Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_FifaTeam_GamePlayed_Team2");

                    b.Navigation("CreatedBy");

                    b.Navigation("Platform");

                    b.Navigation("Team1");

                    b.Navigation("Team2");
                });

            modelBuilder.Entity("YuFoot.Entities.Highlight", b =>
                {
                    b.HasOne("YuFoot.Entities.Player", "CreatedBy")
                        .WithMany("Highlights")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Highlight_Player");

                    b.HasOne("YuFoot.Entities.GamePlayed", "Game")
                        .WithMany("Highlights")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Highlight_GamePlayed");

                    b.Navigation("CreatedBy");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("YuFoot.Entities.TeamPlayer", b =>
                {
                    b.HasOne("YuFoot.Entities.GamePlayed", "GamePlayed")
                        .WithMany("TeamPlayers")
                        .HasForeignKey("GamePlayedId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_GamePlayed_TeamPlayer");

                    b.HasOne("YuFoot.Entities.Player", "Player")
                        .WithMany("TeamPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Player_TeamPlayer");

                    b.Navigation("GamePlayed");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("YuFoot.Entities.FifaTeam", b =>
                {
                    b.Navigation("GamesPlayedTeam1");

                    b.Navigation("GamesPlayedTeam2");
                });

            modelBuilder.Entity("YuFoot.Entities.GamePlayed", b =>
                {
                    b.Navigation("Highlights");

                    b.Navigation("TeamPlayers");
                });

            modelBuilder.Entity("YuFoot.Entities.Platform", b =>
                {
                    b.Navigation("GamesPlayed");
                });

            modelBuilder.Entity("YuFoot.Entities.Player", b =>
                {
                    b.Navigation("GamesCreated");

                    b.Navigation("Highlights");

                    b.Navigation("TeamPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}

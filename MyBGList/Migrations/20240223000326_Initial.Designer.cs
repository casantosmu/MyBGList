﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBGList.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyBGList.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240223000326_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyBGList.Models.BoardGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("board_game_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BggRank")
                        .HasColumnType("integer")
                        .HasColumnName("bgg_rank");

                    b.Property<decimal>("ComplexityAverage")
                        .HasPrecision(4, 2)
                        .HasColumnType("numeric(4,2)")
                        .HasColumnName("complexity_average");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_date");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("integer")
                        .HasColumnName("max_players");

                    b.Property<int>("MinAge")
                        .HasColumnType("integer")
                        .HasColumnName("min_age");

                    b.Property<int>("MinPlayers")
                        .HasColumnType("integer")
                        .HasColumnName("min_players");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("OwnedUsers")
                        .HasColumnType("integer")
                        .HasColumnName("owned_users");

                    b.Property<int>("PlayTime")
                        .HasColumnType("integer")
                        .HasColumnName("play_time");

                    b.Property<decimal>("RatingAverage")
                        .HasPrecision(4, 2)
                        .HasColumnType("numeric(4,2)")
                        .HasColumnName("rating_average");

                    b.Property<int>("UsersRated")
                        .HasColumnType("integer")
                        .HasColumnName("users_rated");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.ToTable("board_games");
                });

            modelBuilder.Entity("MyBGList.Models.BoardGamesDomains", b =>
                {
                    b.Property<int>("BoardGameId")
                        .HasColumnType("integer")
                        .HasColumnName("board_game_id");

                    b.Property<int>("DomainId")
                        .HasColumnType("integer")
                        .HasColumnName("domain_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.HasKey("BoardGameId", "DomainId");

                    b.HasIndex("DomainId");

                    b.ToTable("board_games_domains");
                });

            modelBuilder.Entity("MyBGList.Models.BoardGamesMechanics", b =>
                {
                    b.Property<int>("BoardGameId")
                        .HasColumnType("integer")
                        .HasColumnName("board_game_id");

                    b.Property<int>("MechanicId")
                        .HasColumnType("integer")
                        .HasColumnName("mechanic_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.HasKey("BoardGameId", "MechanicId");

                    b.HasIndex("MechanicId");

                    b.ToTable("board_games_mechanics");
                });

            modelBuilder.Entity("MyBGList.Models.Domain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("domain_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("domains");
                });

            modelBuilder.Entity("MyBGList.Models.Mechanic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("mechanic_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("mechanics");
                });

            modelBuilder.Entity("MyBGList.Models.BoardGamesDomains", b =>
                {
                    b.HasOne("MyBGList.Models.BoardGame", "BoardGame")
                        .WithMany("BoardGamesDomains")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBGList.Models.Domain", "Domain")
                        .WithMany("BoardGamesDomains")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("Domain");
                });

            modelBuilder.Entity("MyBGList.Models.BoardGamesMechanics", b =>
                {
                    b.HasOne("MyBGList.Models.BoardGame", "BoardGame")
                        .WithMany("BoardGamesMechanics")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBGList.Models.Mechanic", "Mechanic")
                        .WithMany("BoardGamesMechanics")
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("Mechanic");
                });

            modelBuilder.Entity("MyBGList.Models.BoardGame", b =>
                {
                    b.Navigation("BoardGamesDomains");

                    b.Navigation("BoardGamesMechanics");
                });

            modelBuilder.Entity("MyBGList.Models.Domain", b =>
                {
                    b.Navigation("BoardGamesDomains");
                });

            modelBuilder.Entity("MyBGList.Models.Mechanic", b =>
                {
                    b.Navigation("BoardGamesMechanics");
                });
#pragma warning restore 612, 618
        }
    }
}

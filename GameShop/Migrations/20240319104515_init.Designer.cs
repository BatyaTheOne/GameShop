﻿// <auto-generated />
using System;
using GameShop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240319104515_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameShop.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("GameTypeId")
                        .HasColumnType("int");

                    b.Property<int>("LibraryId")
                        .HasColumnType("int");

                    b.Property<int>("MinimumLimitAge")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("UserGameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameTypeId");

                    b.HasIndex("LibraryId");

                    b.HasIndex("UserGameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameShop.Models.GameType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GameTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Shooter"
                        },
                        new
                        {
                            Id = 3,
                            Name = "RPG"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Strategy"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Simulation"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Sports"
                        });
                });

            modelBuilder.Entity("GameShop.Models.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("GameShop.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Loggin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Score")
                        .HasColumnType("float");

                    b.Property<int?>("UserGameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserGameId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameShop.Models.UserGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserGames");
                });

            modelBuilder.Entity("GameShop.Models.Game", b =>
                {
                    b.HasOne("GameShop.Models.GameType", "GameType")
                        .WithMany("Games")
                        .HasForeignKey("GameTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameShop.Models.Library", "Library")
                        .WithMany("games")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameShop.Models.UserGame", null)
                        .WithMany("Games")
                        .HasForeignKey("UserGameId");

                    b.Navigation("GameType");

                    b.Navigation("Library");
                });

            modelBuilder.Entity("GameShop.Models.User", b =>
                {
                    b.HasOne("GameShop.Models.UserGame", null)
                        .WithMany("Users")
                        .HasForeignKey("UserGameId");
                });

            modelBuilder.Entity("GameShop.Models.GameType", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("GameShop.Models.Library", b =>
                {
                    b.Navigation("games");
                });

            modelBuilder.Entity("GameShop.Models.UserGame", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
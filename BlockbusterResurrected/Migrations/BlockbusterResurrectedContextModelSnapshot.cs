﻿// <auto-generated />
using BlockbusterResurrected.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlockbusterResurrected.Migrations
{
    [DbContext(typeof(BlockbusterResurrectedContext))]
    partial class BlockbusterResurrectedContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BlockbusterResurrected.Models.ConsoleGame", b =>
                {
                    b.Property<int>("ConsoleGameId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GConsoleId");

                    b.Property<int>("GameId");

                    b.HasKey("ConsoleGameId");

                    b.HasIndex("GConsoleId");

                    b.HasIndex("GameId");

                    b.ToTable("ConsoleGame");
                });

            modelBuilder.Entity("BlockbusterResurrected.Models.GConsole", b =>
                {
                    b.Property<int>("GConsoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("GConsoleName");

                    b.HasKey("GConsoleId");

                    b.ToTable("GConsoles");
                });

            modelBuilder.Entity("BlockbusterResurrected.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GameTitle");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BlockbusterResurrected.Models.ConsoleGame", b =>
                {
                    b.HasOne("BlockbusterResurrected.Models.GConsole", "GConsole")
                        .WithMany("Games")
                        .HasForeignKey("GConsoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlockbusterResurrected.Models.Game", "Game")
                        .WithMany("GConsoles")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

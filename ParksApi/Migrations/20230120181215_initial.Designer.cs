﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParksApi.Models;

#nullable disable

namespace ParksApi.Migrations
{
    [DbContext(typeof(ParksApiContext))]
    [Migration("20230120181215_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ParksApi.Models.Parkrec", b =>
                {
                    b.Property<int>("ParkrecId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("ParkrecId");

                    b.ToTable("Parkrecs");
                });

            modelBuilder.Entity("ParksApi.Models.Tipe", b =>
                {
                    b.Property<int>("TipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ParkrecId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("longtext");

                    b.HasKey("TipeId");

                    b.HasIndex("ParkrecId");

                    b.ToTable("Tipes");
                });

            modelBuilder.Entity("ParksApi.Models.Tipe", b =>
                {
                    b.HasOne("ParksApi.Models.Parkrec", null)
                        .WithMany("Tipes")
                        .HasForeignKey("ParkrecId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParksApi.Models.Parkrec", b =>
                {
                    b.Navigation("Tipes");
                });
#pragma warning restore 612, 618
        }
    }
}

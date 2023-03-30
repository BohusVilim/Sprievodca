﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sprievodca.Data;

#nullable disable

namespace Sprievodca.Migrations
{
    [DbContext(typeof(SprievodcaDbContext))]
    [Migration("20230209145414_9.2.2023.2")]
    partial class _9220232
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Sprievodca.Models.MainModels.Cesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("Lenght")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SektorId")
                        .HasColumnType("bigint");

                    b.Property<int>("SektorId1")
                        .HasColumnType("int");

                    b.Property<string>("Style")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SektorId1");

                    b.ToTable("Cesta");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.Kraj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nazov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kraj");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.Oblast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("KrajId")
                        .HasColumnType("bigint");

                    b.Property<int>("KrajId1")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KrajId1");

                    b.ToTable("Oblast");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.PodOblast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OblastId")
                        .HasColumnType("bigint");

                    b.Property<int>("OblastId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OblastId1");

                    b.ToTable("PodOblast");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.Sektor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PodOblastId")
                        .HasColumnType("bigint");

                    b.Property<int>("PodOblastId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PodOblastId1");

                    b.ToTable("Sektor");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.Cesta", b =>
                {
                    b.HasOne("Sprievodca.Models.MainModels.Sektor", "Sektor")
                        .WithMany("Cesta")
                        .HasForeignKey("SektorId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sektor");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.Oblast", b =>
                {
                    b.HasOne("Sprievodca.Models.MainModels.Kraj", "Kraj")
                        .WithMany("Oblast")
                        .HasForeignKey("KrajId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kraj");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.PodOblast", b =>
                {
                    b.HasOne("Sprievodca.Models.MainModels.Oblast", "Oblast")
                        .WithMany("PodOblast")
                        .HasForeignKey("OblastId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oblast");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.Sektor", b =>
                {
                    b.HasOne("Sprievodca.Models.MainModels.PodOblast", "PodOblast")
                        .WithMany("Sektor")
                        .HasForeignKey("PodOblastId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PodOblast");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.Kraj", b =>
                {
                    b.Navigation("Oblast");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.Oblast", b =>
                {
                    b.Navigation("PodOblast");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.PodOblast", b =>
                {
                    b.Navigation("Sektor");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.Sektor", b =>
                {
                    b.Navigation("Cesta");
                });
#pragma warning restore 612, 618
        }
    }
}
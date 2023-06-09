﻿// <auto-generated />
using System;
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
    [Migration("20230209122048_Creating_Kraj")]
    partial class Creating_Kraj
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

                    b.Property<string>("Style")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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

                    b.Property<int?>("OblastId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OblastId");

                    b.ToTable("Kraj");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.Oblast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PodOblastId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PodOblastId");

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

                    b.Property<int>("SektorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SektorId");

                    b.ToTable("PodOblast");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.Sektor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CestaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CestaId");

                    b.ToTable("Sektor");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.Kraj", b =>
                {
                    b.HasOne("Sprievodca.Models.MainModels.Oblast", "Oblast")
                        .WithMany()
                        .HasForeignKey("OblastId");

                    b.Navigation("Oblast");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.Oblast", b =>
                {
                    b.HasOne("Sprievodca.Models.MainModels.PodOblast", "PodOblast")
                        .WithMany()
                        .HasForeignKey("PodOblastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PodOblast");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.PodOblast", b =>
                {
                    b.HasOne("Sprievodca.Models.MainModels.Sektor", "Sektor")
                        .WithMany()
                        .HasForeignKey("SektorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sektor");
                });

            modelBuilder.Entity("Sprievodca.Models.MainModels.Sektor", b =>
                {
                    b.HasOne("Sprievodca.Models.MainModels.Cesta", "Cesta")
                        .WithMany()
                        .HasForeignKey("CestaId");

                    b.Navigation("Cesta");
                });
#pragma warning restore 612, 618
        }
    }
}

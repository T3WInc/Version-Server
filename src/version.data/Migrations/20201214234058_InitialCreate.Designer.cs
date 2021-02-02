﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using t3winc.version.data;

namespace t3winc.version.data.Migrations
{
    [DbContext(typeof(VersionContext))]
    [Migration("20201214234058_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("t3winc.version.domain.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Major")
                        .HasColumnType("int");

                    b.Property<int>("Minor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Patch")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Revision")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("t3winc.version.domain.MyVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Version");
                });

            modelBuilder.Entity("t3winc.version.domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Major")
                        .HasColumnType("int");

                    b.Property<string>("Master")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Minor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Patch")
                        .HasColumnType("int");

                    b.Property<int>("Revision")
                        .HasColumnType("int");

                    b.Property<int?>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VersionId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("t3winc.version.domain.Branch", b =>
                {
                    b.HasOne("t3winc.version.domain.Product", "Product")
                        .WithMany("Branches")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("t3winc.version.domain.Product", b =>
                {
                    b.HasOne("t3winc.version.domain.MyVersion", "Version")
                        .WithMany("Products")
                        .HasForeignKey("VersionId");

                    b.Navigation("Version");
                });

            modelBuilder.Entity("t3winc.version.domain.MyVersion", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("t3winc.version.domain.Product", b =>
                {
                    b.Navigation("Branches");
                });
#pragma warning restore 612, 618
        }
    }
}
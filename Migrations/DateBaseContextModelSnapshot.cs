﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkTogether.DAL;

#nullable disable

namespace ParkTogether.Migrations
{
    [DbContext(typeof(DateBaseContext))]
    partial class DateBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkTogether.DAL.Entities.Administrator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Mail")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("ParkTogether.DAL.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Mail")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}

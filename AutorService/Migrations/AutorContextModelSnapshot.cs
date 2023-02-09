﻿// <auto-generated />
using System;
using AutorService.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AutorService.Migrations
{
    [DbContext(typeof(AutorContext))]
    partial class AutorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AutorService.Model.AcademicDegree", b =>
                {
                    b.Property<int>("AcademicDegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AcademicCenter")
                        .HasColumnType("text");

                    b.Property<string>("AcademicDegreeGuid")
                        .HasColumnType("text");

                    b.Property<int>("AutorBookId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DegreeDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("AcademicDegreeId");

                    b.HasIndex("AutorBookId");

                    b.ToTable("AcademicDegree");
                });

            modelBuilder.Entity("AutorService.Model.AutorBook", b =>
                {
                    b.Property<int>("AutorBookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AutorBookGuid")
                        .HasColumnType("text");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Lastname")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("AutorBookId");

                    b.ToTable("AutorBook");
                });

            modelBuilder.Entity("AutorService.Model.AcademicDegree", b =>
                {
                    b.HasOne("AutorService.Model.AutorBook", "AutorBook")
                        .WithMany("ListAcademicDegree")
                        .HasForeignKey("AutorBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

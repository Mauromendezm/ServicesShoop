﻿// <auto-generated />
using System;
using BookService.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookService.Migrations
{
    [DbContext(typeof(LibreryContext))]
    [Migration("20230131204338_MigrationSqlServerInit2")]
    partial class MigrationSqlServerInit2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookService.Model.MaterialLibrary", b =>
                {
                    b.Property<Guid?>("MaterialLibreryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AutorBook")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaterialLibreryId");

                    b.ToTable("MaterialLibrary");
                });
#pragma warning restore 612, 618
        }
    }
}

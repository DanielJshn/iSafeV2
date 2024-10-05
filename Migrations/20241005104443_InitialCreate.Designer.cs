﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apief;

#nullable disable

namespace V2iSafe.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241005104443_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Dbo")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("apief.AdditionalField", b =>
                {
                    b.Property<Guid>("additionalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("passwordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("additionalId");

                    b.HasIndex("passwordId");

                    b.ToTable("AdditionalFields", "Dbo");
                });

            modelBuilder.Entity("apief.Note", b =>
                {
                    b.Property<Guid?>("noteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("lastEdit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("noteId");

                    b.ToTable("Note", "Dbo");
                });

            modelBuilder.Entity("apief.Password", b =>
                {
                    b.Property<Guid>("passwordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("lastEdit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("passwordId");

                    b.ToTable("Password", "Dbo");
                });

            modelBuilder.Entity("apief.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("User", "Dbo");
                });

            modelBuilder.Entity("apief.AdditionalField", b =>
                {
                    b.HasOne("apief.Password", null)
                        .WithMany("additionalFields")
                        .HasForeignKey("passwordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apief.Password", b =>
                {
                    b.Navigation("additionalFields");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VL_DataAccess;

#nullable disable

namespace VL_DataAccess.Migrations
{
    [DbContext(typeof(VLContext))]
    [Migration("20221128032038_removes_authorName_in_book")]
    partial class removes_authorName_in_book
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VL_DataAccess.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("VL_DataAccess.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DowloadUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EditorialName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishingDate")
                        .HasColumnType("date");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("VL_DataAccess.Models.BookReview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LibraryUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Opinion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("LibraryUserId");

                    b.ToTable("BookReviews");
                });

            modelBuilder.Entity("VL_DataAccess.Models.LibraryUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VL_DataAccess.Models.Subscription", b =>
                {
                    b.Property<Guid>("LibraryUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LibraryUserId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("VL_DataAccess.Models.Book", b =>
                {
                    b.HasOne("VL_DataAccess.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("VL_DataAccess.Models.BookReview", b =>
                {
                    b.HasOne("VL_DataAccess.Models.Book", "Book")
                        .WithMany("BookReviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VL_DataAccess.Models.LibraryUser", null)
                        .WithMany("BookReviews")
                        .HasForeignKey("LibraryUserId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("VL_DataAccess.Models.Subscription", b =>
                {
                    b.HasOne("VL_DataAccess.Models.Author", "Author")
                        .WithMany("Users")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VL_DataAccess.Models.LibraryUser", "LibraryUser")
                        .WithMany("SuscribedTo")
                        .HasForeignKey("LibraryUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("LibraryUser");
                });

            modelBuilder.Entity("VL_DataAccess.Models.Author", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("VL_DataAccess.Models.Book", b =>
                {
                    b.Navigation("BookReviews");
                });

            modelBuilder.Entity("VL_DataAccess.Models.LibraryUser", b =>
                {
                    b.Navigation("BookReviews");

                    b.Navigation("SuscribedTo");
                });
#pragma warning restore 612, 618
        }
    }
}

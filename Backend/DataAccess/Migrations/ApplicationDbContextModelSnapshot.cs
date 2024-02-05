﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurrentlyBorrowedById")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBookAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "J.D. Salinger",
                            Description = "Classic novel",
                            Genre = "Fiction",
                            IsBookAvailable = true,
                            Name = "The Catcher in the Rye",
                            OwnerId = 1,
                            Rating = 4.5
                        },
                        new
                        {
                            Id = 2,
                            Author = "Harper Lee",
                            Description = "Pulitzer Prize-winning novel",
                            Genre = "Fiction",
                            IsBookAvailable = true,
                            Name = "To Kill a Mockingbird",
                            OwnerId = 2,
                            Rating = 4.7999999999999998
                        },
                        new
                        {
                            Id = 3,
                            Author = "George Orwell",
                            Description = "Classic dystopian novel",
                            Genre = "Dystopian",
                            IsBookAvailable = true,
                            Name = "1984",
                            OwnerId = 3,
                            Rating = 4.7000000000000002
                        },
                        new
                        {
                            Id = 4,
                            Author = "F. Scott Fitzgerald",
                            Description = "American classic",
                            Genre = "Fiction",
                            IsBookAvailable = true,
                            Name = "The Great Gatsby",
                            OwnerId = 4,
                            Rating = 4.5999999999999996
                        },
                        new
                        {
                            Id = 5,
                            Author = "J.R.R. Tolkien",
                            Description = "Fantasy adventure novel",
                            Genre = "Fantasy",
                            IsBookAvailable = true,
                            Name = "The Hobbit",
                            OwnerId = 1,
                            Rating = 4.9000000000000004
                        },
                        new
                        {
                            Id = 6,
                            Author = "Jane Austen",
                            Description = "Romantic novel",
                            Genre = "Classic",
                            IsBookAvailable = true,
                            Name = "Pride and Prejudice",
                            OwnerId = 2,
                            Rating = 4.7000000000000002
                        },
                        new
                        {
                            Id = 7,
                            Author = "J.K. Rowling",
                            Description = "First book in the Harry Potter series",
                            Genre = "Fantasy",
                            IsBookAvailable = true,
                            Name = "Harry Potter and the Sorcerer's Stone",
                            OwnerId = 3,
                            Rating = 4.7999999999999998
                        },
                        new
                        {
                            Id = 8,
                            Author = "J.R.R. Tolkien",
                            Description = "Epic high fantasy novel",
                            Genre = "Fantasy",
                            IsBookAvailable = true,
                            Name = "The Lord of the Rings",
                            OwnerId = 4,
                            Rating = 4.9000000000000004
                        },
                        new
                        {
                            Id = 9,
                            Author = "Stephen King",
                            Description = "Classic horror novel",
                            Genre = "Horror",
                            IsBookAvailable = true,
                            Name = "The Shining",
                            OwnerId = 1,
                            Rating = 4.5
                        },
                        new
                        {
                            Id = 10,
                            Author = "Aldous Huxley",
                            Description = "Dystopian novel",
                            Genre = "Dystopian",
                            IsBookAvailable = true,
                            Name = "Brave New World",
                            OwnerId = 2,
                            Rating = 4.5999999999999996
                        });
                });

            modelBuilder.Entity("Models.Borrowing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("BorrowerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LentBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Borrowings");
                });

            modelBuilder.Entity("Models.Return", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("ReturnTo")
                        .HasColumnType("int");

                    b.Property<int>("ReturningBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturningTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Returns");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TokensAvailable")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "John Doe",
                            Password = "password1",
                            TokensAvailable = 5,
                            Username = "john.doe"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jane Doe",
                            Password = "password2",
                            TokensAvailable = 3,
                            Username = "jane.doe"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Alice Johnson",
                            Password = "password3",
                            TokensAvailable = 7,
                            Username = "alice.johnson"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bob Smith",
                            Password = "password4",
                            TokensAvailable = 2,
                            Username = "bob.smith"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

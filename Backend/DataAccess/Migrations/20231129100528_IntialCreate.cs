using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBookAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    CurrentlyBorrowedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Borrowings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    LentBy = table.Column<int>(type: "int", nullable: false),
                    BorrowerId = table.Column<int>(type: "int", nullable: false),
                    BorrowingTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Returns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ReturningBy = table.Column<int>(type: "int", nullable: false),
                    ReturnTo = table.Column<int>(type: "int", nullable: false),
                    ReturningTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Returns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokensAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CurrentlyBorrowedById", "Description", "Genre", "IsBookAvailable", "Name", "OwnerId", "Rating" },
                values: new object[,]
                {
                    { 1, "J.D. Salinger", null, "Classic novel", "Fiction", true, "The Catcher in the Rye", 1, 4.5 },
                    { 2, "Harper Lee", null, "Pulitzer Prize-winning novel", "Fiction", true, "To Kill a Mockingbird", 2, 4.7999999999999998 },
                    { 3, "George Orwell", null, "Classic dystopian novel", "Dystopian", true, "1984", 3, 4.7000000000000002 },
                    { 4, "F. Scott Fitzgerald", null, "American classic", "Fiction", true, "The Great Gatsby", 4, 4.5999999999999996 },
                    { 5, "J.R.R. Tolkien", null, "Fantasy adventure novel", "Fantasy", true, "The Hobbit", 1, 4.9000000000000004 },
                    { 6, "Jane Austen", null, "Romantic novel", "Classic", true, "Pride and Prejudice", 2, 4.7000000000000002 },
                    { 7, "J.K. Rowling", null, "First book in the Harry Potter series", "Fantasy", true, "Harry Potter and the Sorcerer's Stone", 3, 4.7999999999999998 },
                    { 8, "J.R.R. Tolkien", null, "Epic high fantasy novel", "Fantasy", true, "The Lord of the Rings", 4, 4.9000000000000004 },
                    { 9, "Stephen King", null, "Classic horror novel", "Horror", true, "The Shining", 1, 4.5 },
                    { 10, "Aldous Huxley", null, "Dystopian novel", "Dystopian", true, "Brave New World", 2, 4.5999999999999996 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "TokensAvailable", "Username" },
                values: new object[,]
                {
                    { 1, "John Doe", "password1", 5, "john.doe" },
                    { 2, "Jane Doe", "password2", 3, "jane.doe" },
                    { 3, "Alice Johnson", "password3", 7, "alice.johnson" },
                    { 4, "Bob Smith", "password4", 2, "bob.smith" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Borrowings");

            migrationBuilder.DropTable(
                name: "Returns");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

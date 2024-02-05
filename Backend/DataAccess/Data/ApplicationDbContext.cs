using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Return> Returns { get; set; }
        //public DbSet<UserBook> UserBooks { get; set; }

        // Add other DbSet properties for additional models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Ignore(u => u.BooksBorrowed);
            modelBuilder.Entity<User>().Ignore(u => u.BooksLent);

            // Seed Users
            modelBuilder.Entity<User>().HasData(
    new User { Id = 1, Name = "John Doe", Username = "john.doe", Password = "password1", TokensAvailable = 5 },
    new User { Id = 2, Name = "Jane Doe", Username = "jane.doe", Password = "password2", TokensAvailable = 3 },
    new User { Id = 3, Name = "Alice Johnson", Username = "alice.johnson", Password = "password3", TokensAvailable = 7 },
    new User { Id = 4, Name = "Bob Smith", Username = "bob.smith", Password = "password4", TokensAvailable = 2 }
);

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Name = "The Catcher in the Rye", Rating = 4.5, Author = "J.D. Salinger", Genre = "Fiction", IsBookAvailable = true, Description = "Classic novel", OwnerId = 1 },
                new Book { Id = 2, Name = "To Kill a Mockingbird", Rating = 4.8, Author = "Harper Lee", Genre = "Fiction", IsBookAvailable = true, Description = "Pulitzer Prize-winning novel", OwnerId = 2 },
                new Book { Id = 3, Name = "1984", Rating = 4.7, Author = "George Orwell", Genre = "Dystopian", IsBookAvailable = true, Description = "Classic dystopian novel", OwnerId = 3 },
                new Book { Id = 4, Name = "The Great Gatsby", Rating = 4.6, Author = "F. Scott Fitzgerald", Genre = "Fiction", IsBookAvailable = true, Description = "American classic", OwnerId = 4 },
                new Book { Id = 5, Name = "The Hobbit", Rating = 4.9, Author = "J.R.R. Tolkien", Genre = "Fantasy", IsBookAvailable = true, Description = "Fantasy adventure novel", OwnerId = 1 },
                new Book { Id = 6, Name = "Pride and Prejudice", Rating = 4.7, Author = "Jane Austen", Genre = "Classic", IsBookAvailable = true, Description = "Romantic novel", OwnerId = 2 },
                new Book { Id = 7, Name = "Harry Potter and the Sorcerer's Stone", Rating = 4.8, Author = "J.K. Rowling", Genre = "Fantasy", IsBookAvailable = true, Description = "First book in the Harry Potter series", OwnerId = 3 },
                new Book { Id = 8, Name = "The Lord of the Rings", Rating = 4.9, Author = "J.R.R. Tolkien", Genre = "Fantasy", IsBookAvailable = true, Description = "Epic high fantasy novel", OwnerId = 4 },
                new Book { Id = 9, Name = "The Shining", Rating = 4.5, Author = "Stephen King", Genre = "Horror", IsBookAvailable = true, Description = "Classic horror novel", OwnerId = 1 },
                new Book { Id = 10, Name = "Brave New World", Rating = 4.6, Author = "Aldous Huxley", Genre = "Dystopian", IsBookAvailable = true, Description = "Dystopian novel", OwnerId = 2 }
            );

        }
    }
}

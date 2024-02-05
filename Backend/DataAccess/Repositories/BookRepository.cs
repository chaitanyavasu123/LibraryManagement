using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }
        public List<Book> GetAllAvailableBooks()
        {
            return _context.Books.Where(b => b.IsBookAvailable).ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
        public void BorrowBook(int bookId,int lenderId, int borrowerId)
        {
            var book = _context.Books.Find(bookId);
            var borrower = _context.Users.Find(borrowerId);
            var owner = _context.Users.Find(book.OwnerId);
            var borrowing = new Borrowing
            {
            BookId = bookId,
            LentBy = lenderId,
            BorrowerId = borrowerId,
            BorrowingTime = DateTime.Now
             };

            _context.Borrowings.Add(borrowing);
            


            if (book != null && borrower != null && owner != null && borrower.TokensAvailable > 0 && book.IsBookAvailable)
            {
                // Update book information
              
                book.IsBookAvailable = false;
                book.CurrentlyBorrowedById = borrowerId;
               // book.LentByUserId = owner.Id;  // Update LentByUserId to reflect the owner

                // Update user information for borrower
                borrower.TokensAvailable--;
                borrower.BooksBorrowed.Add(bookId);

                // Update user information for owner
                owner.TokensAvailable++;  // Increment tokens for the owner
                owner.BooksLent.Add(bookId);

                _context.SaveChanges();
            }
            else
            {
                // Throw an exception with a custom message
                throw new Exception("Book borrowing conditions not satisfied.");
            }
        }

        public void ReturnBook(int bookId,int borrowerId, int ownerId)
        {
            var book = _context.Books.Find(bookId);
            var owner = _context.Users.Find(ownerId);
            var returning = new Return
            {
                BookId = bookId,
                ReturningBy = borrowerId,
                ReturnTo = ownerId,
                ReturningTime = DateTime.Now
            };

            _context.Returns.Add(returning);


            if (book != null && owner != null && book.CurrentlyBorrowedById != null && book.OwnerId==ownerId )
            {
                // Update book information
                book.IsBookAvailable = true;
                book.CurrentlyBorrowedById = null;
                //book.LentByUserId = null;  // Reset LentByUserId

                // Update user information for owner
                owner.BooksLent.Remove(bookId);

                //_context.SaveChanges();
            }
            _context.SaveChanges();
        }
        public List<Book> GetAvailableBooksUser(int userId)
        {
            // Assuming you have a DbSet<Book> in your ApplicationDbContext
            return _context.Books
                .Where(b => b.IsBookAvailable && b.OwnerId != userId)
                .ToList();
        }

    }

}

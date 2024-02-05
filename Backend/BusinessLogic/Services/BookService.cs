using DataAccess.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserService _userService;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }
        public List<Book> GetAllAvailableBooks()
        {
            return _bookRepository.GetAllAvailableBooks();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public void AddBook(Book book)
        {
            // Add business logic/validation if needed
            _bookRepository.AddBook(book);
        }

        public void UpdateBook(Book book)
        {
            // Add business logic/validation if needed
            _bookRepository.UpdateBook(book);
        }

        public void DeleteBook(int id)
        {
            // Add business logic/validation if needed
            _bookRepository.DeleteBook(id);
        }
        public void BorrowBook(int bookId,int lenderId, int borrowerId)
        {
            _bookRepository.BorrowBook(bookId,lenderId, borrowerId);
        }

        public void ReturnBook(int bookId,int borrowerId, int ownerId)
        {
            _bookRepository.ReturnBook(bookId,borrowerId, ownerId);
        }
        public List<Book> GetAvailableBooksUser(int userId)
        {
            //User user = _userService.GetUserById(userId);

            //if (user == null)
            //{
                // Handle the case where the user is not found
            //    return null;
            //}

            // Retrieve available books excluding the ones added by the user
            return _bookRepository.GetAvailableBooksUser(userId);
        }

    }

}

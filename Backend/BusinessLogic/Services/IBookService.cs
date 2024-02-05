using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        List<Book> GetAllAvailableBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        void BorrowBook(int bookId, int lenderId, int borrowerId);
        void ReturnBook(int bookId,int borrowerId, int ownerId);
        List<Book> GetAvailableBooksUser(int userId);
    }

}

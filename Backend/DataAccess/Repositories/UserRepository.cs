using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    // UserRepository.cs
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public int GetAvailableTokens(int userId)
        {
            return _context.Users.Where(u => u.Id == userId).Select(u => u.TokensAvailable).FirstOrDefault();
        }

        public List<int> GetBooksBorrowed(int userId)
        {
            return _context.Books
                .Where(b => b.CurrentlyBorrowedById == userId)
                .Select(b => b.Id)
                .ToList();
        }


        public List<int> GetBooksLent(int userId)
        {
            return _context.Books
                .Where(b => b.OwnerId == userId && !b.IsBookAvailable)
                .Select(b => b.Id)
                .ToList();
        }

        public List<int> GetBooksAdded(int userId)
        {
        return _context.Books.Where(b => b.OwnerId == userId).Select(b => b.Id).ToList();
        }

        // Implement other methods as needed
    }

}

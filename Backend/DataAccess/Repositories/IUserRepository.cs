using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User GetUserByUsernameAndPassword(string username, string password);
        int GetAvailableTokens(int userId);
        List<int> GetBooksBorrowed(int userId);
        List<int> GetBooksLent(int userId);
        List<int> GetBooksAdded(int userId);
        // Add other methods as needed
    }
}

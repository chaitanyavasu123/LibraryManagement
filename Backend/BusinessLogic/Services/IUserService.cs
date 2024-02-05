using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IUserService
    {
        User GetUserById(int id);
        int GetAvailableTokens(int userId);
        string GenerateJwtToken(User user);
        User AuthenticateUser(string username, string password);
        List<int> GetBooksBorrowed(int userId);
        List<int> GetBooksLent(int userId);
        List<int> GetBooksAdded(int userId);
        // Add other methods as needed
    }
}

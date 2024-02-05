using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    // UserService.cs
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("chaitanyavasuis@goodboy");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
               
                
                // Add other claims as needed
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User AuthenticateUser(string username, string password)
        {
            return _userRepository.GetUserByUsernameAndPassword(username, password);
        }
        public int GetAvailableTokens(int userId)
        {
            return _userRepository.GetAvailableTokens(userId);
        }

        public List<int> GetBooksBorrowed(int userId)
        {
            return _userRepository.GetBooksBorrowed(userId);
        }

        public List<int> GetBooksLent(int userId)
        {
            return _userRepository.GetBooksLent(userId);
        }

        public List<int> GetBooksAdded(int userId)
        {
            return _userRepository.GetBooksAdded(userId);
        }

        // Implement other methods as needed
    }

}

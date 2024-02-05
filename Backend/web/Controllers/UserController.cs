using BusinessLogic.Services;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
    // UserController.cs
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestModel model)
        {
            var user = _userService.AuthenticateUser(model.Username, model.Password);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            var token = _userService.GenerateJwtToken(user);

            return Ok(new { Token = token });
        }

        [HttpGet("{id}/available-tokens")]
        public IActionResult GetAvailableTokens(int id)
        {
            var availableTokens = _userService.GetAvailableTokens(id);
            return Ok(availableTokens);
        }

        [HttpGet("{id}/books-borrowed")]
        public IActionResult GetBooksBorrowed(int id)
        {
            var booksBorrowed = _userService.GetBooksBorrowed(id);
            return Ok(booksBorrowed);
        }

        [HttpGet("{id}/books-lent")]
        public IActionResult GetBooksLent(int id)
        {
            var booksLent = _userService.GetBooksLent(id);
            return Ok(booksLent);
        }

        [HttpGet("{id}/books-added")]
        public IActionResult GetBooksAdded(int id)
        {
            var booksAdded = _userService.GetBooksAdded(id);
            return Ok(booksAdded);
        }

        // Implement other actions as needed
    }

}

using Microsoft.AspNetCore.Mvc;
using Models;
using BusinessLogic.Services;

namespace web.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("available")]
        public IActionResult GetAllAvailableBooks()
        {
            var availableBooks = _bookService.GetAllAvailableBooks();
            return Ok(availableBooks);
        }
        [HttpGet("availablebooks")]
        public ActionResult<List<Book>> GetAvailableBooksUser(int userId)
        {
            var availableBooks = _bookService.GetAvailableBooksUser(userId);

            if (availableBooks == null)
            {
                return NotFound(); // Or handle the case accordingly
            }

            return Ok(availableBooks);
        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingBook = _bookService.GetBookById(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            _bookService.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var existingBook = _bookService.GetBookById(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            _bookService.DeleteBook(id);
            return NoContent();
        }
        [HttpPost("borrow/{bookId}/{lenderId}/{borrowerId}")]
        public IActionResult BorrowBook(int bookId,int lenderId, int borrowerId)
        {
            try
            {
                _bookService.BorrowBook(bookId,lenderId, borrowerId);
                return Ok("Book successfully borrowed.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost("return/{bookId}/{borrowerId}/{ownerId}")]
        public IActionResult ReturnBook(int bookId,int borrowerId, int ownerId)
        {
            try
            {
                _bookService.ReturnBook(bookId,borrowerId, ownerId);
                return Ok("Book successfully returned.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }

}

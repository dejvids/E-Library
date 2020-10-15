using System.Threading.Tasks;
using E_Library.Application.Services;
using Microsoft.AspNetCore.Mvc;
using E_Library.Application.Options;
using E_Library.Services;

namespace E_Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryService _bookService;
        private readonly IOperationResultHandler _operationHandler;
        private readonly IUserService _userService;

        public BooksController(ILibraryService bookService, IUserService userService, IOperationResultHandler operationHandler)
        {
            _bookService = bookService;
            _userService = userService;
            _operationHandler = operationHandler;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll(int page)
        {
            var user = await _userService.GetTestUserAsync();
            var options = new BookPagingOption { Items = 10, Page = page };
            var books = await _bookService.GetAllBooksAsync(user, options);

            return Ok(books);
        }

        [HttpGet("wishlist")]
        public async Task<IActionResult> GetUserWishlist()
        {
            var user = await _userService.GetTestUserAsync();
            var whishlist = await _bookService.GetWishListAsync(user);

            return Ok(whishlist);
        }

        [HttpGet("borrowed")]
        public async Task<IActionResult> GetBorrowedBooks()
        {
            var user = await _userService.GetTestUserAsync();
            var whishlist = await _bookService.GetBorrowedBooksAsync(user);

            return Ok(whishlist);
        }

        [HttpPost("borrow")]
        public async Task<IActionResult> BorrowBook([FromBody] int bookId)
        {
            var user = await _userService.GetTestUserAsync();
            return StatusCode(_operationHandler.HandleOperationResult(await _bookService.BorrowBookAsync(user, bookId), out object value), value);
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnBook([FromBody] int bookId)
        {
            var user = await _userService.GetTestUserAsync();

            return StatusCode(_operationHandler.HandleOperationResult(await _bookService.ReturnBookAsync(user, bookId), out object value), value);
        }

        [HttpPost("add-to-wihslist")]
        public async Task<IActionResult> AddToWihslist([FromBody] int bookId)
        {
            var user = await _userService.GetTestUserAsync();
            return StatusCode(_operationHandler.HandleOperationResult(await _bookService.AddBookToWishlistAsync(user, bookId), out object value), value);
        }

        [HttpDelete("remove-from-wihslist/{bookId}")]
        public async Task<IActionResult> RemoveFromWihslist([FromRoute]int bookId)
        {
            var user = await _userService.GetTestUserAsync();
            return StatusCode(_operationHandler.HandleOperationResult(await _bookService.RemoveFromWihslist(user, bookId), out object value), value);
        }
    }
}

using E_Library.Application.DTOs;
using E_Library.DAL.Enitities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Library.Application.Services
{
    public interface ILibraryService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync(User user, Options.BookPagingOption options);

        Task<IEnumerable<BorrowedBookDto>> GetBorrowedBooksAsync(User user);

        Task<OperationResult> BorrowBookAsync(User user, int bookId);

        Task<OperationResult> ReturnBookAsync(User user, int bookId);

        Task<IEnumerable<WhishlistItem>> GetWishListAsync(User User);

        Task<OperationResult> AddBookToWishlistAsync(User user, int bookid);

        Task<OperationResult> RemoveFromWihslist(User user, int bookid);
    }
}

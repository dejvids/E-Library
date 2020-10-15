using E_Library.Application.DTOs;
using E_Library.Application.Options;
using E_Library.DAL;
using E_Library.DAL.Enitities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Library.Resources;

namespace E_Library.Application.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryDB _dbContext;
        public LibraryService(LibraryDB dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult> AddBookToWishlistAsync(User user, int bookId)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
            {
                return new OperationResult($"A book with id {bookId} does not exist", ResultType.NotFound, Results.not_found_book);
            }

            if (await _dbContext.UserWhistLists.AnyAsync(x => x.User.Id == user.Id && x.Book.Id == book.Id))
            {
                return new OperationResult($"Book {bookId} is already on the wihslist of user {user.Id}", ResultType.BadRequest, Results.book_already_on_wihslist);
            }

            _dbContext.UserWhistLists
                .Add(new UsersWhishlist { User = user, Book = book });

            await _dbContext.SaveChangesAsync();

            return new OperationResult();
        }

        public async Task<OperationResult> BorrowBookAsync(User userId, int bookId)
        {
            if (await _dbContext.Books.AnyAsync(b => b.Id == bookId) == false)
            {
                return new OperationResult($"A book with id {bookId} does not exist", ResultType.NotFound, Results.not_found_book);
            }

            var bookCopy = await _dbContext.BookCopies
                .FirstOrDefaultAsync(b => b.Book.Id == bookId && b.IsActive && b.BorrowedBy == null);

            if (bookCopy == null)
            {
                return new OperationResult($"There is not a free book copy of book with id: {bookId} that could be borrow", ResultType.BadRequest, Results.not_found_free_book_copy);
            }

            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == userId.Id);

            var register = new Register
            {
                User = user,
                BookCopy = bookCopy,
                DateFrom = DateTime.Now
            };

            _dbContext.Register.Add(register);

            bookCopy.BorrowedBy = user;
            await _dbContext.SaveChangesAsync();

            return new OperationResult();
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync(User user, BookPagingOption options)
        {
            return await _dbContext.Books
                .Skip(options.Page * options.Items)
                .Take(options.Items)
                .Select(b =>
                 new BookDto
                 {
                     BookId = b.Id,
                     Title = b.Title,
                     Author = $"{b.Author.Surname}  {b.Author.Name}",
                     TotalCount = b.TotalCount,
                     FreeCount = _dbContext.BookCopies.Where(bc => bc.BorrowedBy == null && bc.Book.Id == b.Id).Count()
                 })
                .ToListAsync();
        }

        public async Task<IEnumerable<BorrowedBookDto>> GetBorrowedBooksAsync(User user)
        {
            return await _dbContext.Register
                .Where(r => r.User.Id == user.Id && !r.DateTo.HasValue)
                .Select(b =>
                new BorrowedBookDto
                {
                    BookCopyId = b.BookCopy.Id,
                    BookId = b.BookCopy.Book.Id,
                    BorrowDate = b.DateFrom,
                    Title = b.BookCopy.Book.Title,
                    Isbn = b.BookCopy.Isbn,
                    Author = $"{b.BookCopy.Book.Author.Surname}  {b.BookCopy.Book.Author.Name}"
                }
                )
                .ToListAsync();
        }

        public async Task<IEnumerable<WhishlistItem>> GetWishListAsync(User user)
        {
            return await _dbContext.UserWhistLists
                .Where(x => x.User.Id == user.Id)
                .Select(o =>
                new WhishlistItem
                {
                    BookId = o.Book.Id,
                    Title = o.Book.Title,
                    Author = $"{o.Book.Author.Surname} {o.Book.Author.Name}"
                })
                .ToListAsync();
        }

        public async Task<OperationResult> ReturnBookAsync(User user, int bookId)
        {
            var bookCopy = await _dbContext.BookCopies.FirstOrDefaultAsync(b => b.Id == bookId);

            if (bookCopy == null)
            {
                return new OperationResult($"There is not a book copy with id {bookId}", ResultType.NotFound, Results.not_found_book_copy);
            }

            var register = await _dbContext.Register.FirstOrDefaultAsync(r => r.User.Id == user.Id && r.BookCopy.Id == bookId && !r.DateTo.HasValue);

            if (register == null)
            {
                return new OperationResult($"Can not return book copy with id :{bookId}, the book is already returned", ResultType.BadRequest, Results.can_not_return_free_copy);
            }

            bookCopy.BorrowedBy = null;
            register.DateTo = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return new OperationResult();
        }

        public async Task<OperationResult> RemoveFromWihslist(User user, int bookid)
        {
            var books = await _dbContext.UserWhistLists
                .Where(w => w.UserId == user.Id && w.Book.Id == bookid)
                .ToListAsync();

            if(books.Count == 0)
            {
                return new OperationResult($"There is not book with id: {bookid} on the user {user.Id} wihslist", ResultType.BadRequest, Results.no_book_on_wihslist);
            }

            _dbContext.UserWhistLists
                .RemoveRange(books);

            _dbContext.SaveChanges();

            return new OperationResult();
        }
    }
}

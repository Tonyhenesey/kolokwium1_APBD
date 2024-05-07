using Kolokwium.Properties.DTOs;
using Kolokwium.Properties.Interface;
using Kolokwium.Properties.Models;

namespace Kolokwium.Properties.ServiceImplementation;

public class BookService : IBookService {
    private static List<Book> _books = new List<Book>();

    public async Task<BookWithAuthorsDto> GetBookWithAuthorsAsync(int bookId) {
        var book = _books.FirstOrDefault(b => b.BookId == bookId);
        if (book == null) return null;

        var bookDto = new BookWithAuthorsDto {
            BookId = book.BookId,
            Title = book.Title,
            Authors = book.Authors.Select(a => new AuthorDto {
                FirstName = a.FirstName,
                LastName = a.LastName
            }).ToList()
        };

        return await Task.FromResult(bookDto);
    }

    public async Task<int> CreateBookAsync(BookDto bookDto) {
        var bookId = _books.Any() ? _books.Max(b => b.BookId) + 1 : 1;
        var book = new Book {
            BookId = bookId,
            Title = bookDto.Title,
            Authors = bookDto.Authors.Select(a => new Author {
                FirstName = a.FirstName,
                LastName = a.LastName
            }).ToList()
        };
        _books.Add(book);

        return await Task.FromResult(bookId);
    }
}

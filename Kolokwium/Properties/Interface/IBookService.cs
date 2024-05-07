using Kolokwium.Properties.DTOs;

namespace Kolokwium.Properties.Interface;

public interface IBookService {
    Task<BookWithAuthorsDto> GetBookWithAuthorsAsync(int bookId);
    Task<int> CreateBookAsync(BookDto book);
}

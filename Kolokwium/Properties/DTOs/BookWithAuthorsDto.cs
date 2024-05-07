using Kolokwium.Properties.Models;

namespace Kolokwium.Properties.DTOs;

public class BookWithAuthorsDto {
    public int BookId { get; set; }
    public string Title { get; set; }
    public List<AuthorDto> Authors { get; set; }
}

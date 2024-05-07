namespace Kolokwium.Properties.Models;

public class BooksAuthors {
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}

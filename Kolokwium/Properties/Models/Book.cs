namespace Kolokwium.Properties.Models;


public class Book {
    public int BookId { get; set; }
    public string Title { get; set; }
    public ICollection<BooksAuthors> BooksAuthors { get; set; }
    public List<Author> Authors { get; set; } = new List<Author>();
}

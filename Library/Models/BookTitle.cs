namespace Library.Models;

public class BookTitle
{
    public int BookTitleId { get; set; }
    public string Title { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public int LanguageId { get; set; }
    public Language Language { get; set; }
}
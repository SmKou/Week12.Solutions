namespace Library.Models;

public class BookVersion
{
    public int BookVersionId { get; set; }
    public string Title { get; set; }
    public int Edition { get; set; }
    public string ISBN { get; set; }
    public DateTime Published { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }

    public int FormatId { get; set; }
    public Format Format { get; set; }

    public int LanguageId { get; set; }
    public Language Language { get; set; }

    public List<BookCopy> Copies { get; }
    public List<Recommendation> Recommendations { get; }
}
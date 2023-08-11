namespace Library.Models;

public class BookPublisher
{
    public int BookPublisherId { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }
}
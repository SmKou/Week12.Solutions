namespace Library.Models;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Edition { get; set; }
    public string Format { get; set; }
    public string Language { get; set; }
    public DateTime Published { get; set; }
    public string ISBN { get; set; }
    public string MaturityRating { get; set; }
    public int NumCopies { get; set; }
    
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }

    public List<BookContributor> Contributors { get; }
    public List<Checkout> OutCopies { get; }
    public List<HoldList> Holds { get; }

    // title-authors
    public string Searchable { get; set; }
}
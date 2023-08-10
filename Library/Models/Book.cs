namespace Library.Models;

public class Book
{
    public int BookId { get; set; }
    public string Searchable { get; set; }

    public int CountryId { get; set; }
    public Country Country { get; set; }

    public int MaturityRatingId { get; set; }
    public MaturityRating MaturityRating { get; set; }

    public int BookSerialId { get; set; }
    public BookSerial BookSerial { get; set; }
    public int NumInSeries { get; set; }

    public List<BookCategory> Categories { get; set; }
    public List<BookTitle> Titles { get; set; }
    public List<BookVersion> Versions { get; set; }
    public List<BookCopy> Copies { get; set; }
    public List<Recommendation> Recommendations { get; }
    public List<BookAuthor> Authors { get; set; }
    public List<WaitList> WaitLists { get; }
}
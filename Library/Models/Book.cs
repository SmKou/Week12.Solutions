namespace Library.Models;

public class Book
{
    public int BookId { get; set; }

    public int MaturityRatingId { get; set; }
    public MaturityRating MaturityRating { get; set; }

    public List<BookCategory> Categories { get; set; }
    public List<BookVersion> Versions { get; set; }
    public List<BookCopy> Copies { get; set; }
    public List<BookAuthor> Authors { get; set; }
    public List<WaitList> WaitLists { get; }
}
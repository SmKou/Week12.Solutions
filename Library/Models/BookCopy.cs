namespace Library.Models;

public class BookCopy
{
    public int BookCopyId { get; set; }
    
    public int BookId { get; set; }
    public Book Book { get; set; }

    public int BookVersionId { get; set; }
    public BookVersion BookVersion { get; set; }

    public List<OnHold> Holds { get; }
    public List<Checkout> Checkouts { get; }
}
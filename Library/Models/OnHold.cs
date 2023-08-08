namespace Library.Models;

public class OnHold
{
    public int OnHoldId { get; set; }
    public DateTime DatePlaced { get; set; }

    public int BookCopyId { get; set; }
    public BookCopy BookCopy { get; set; }

    public int PatronId { get; set; }
    public Patron Patron { get; set; }
}
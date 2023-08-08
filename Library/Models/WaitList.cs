namespace Library.Models;

public class WaitList
{
    public int WaitListId { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public int PatronId { get; set; }
    public Patron Patron { get; set; }
}
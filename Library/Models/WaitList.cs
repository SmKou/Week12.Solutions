namespace Library.Models;

public class WaitList
{
    public int WaitListId { get; set; }
    public DateTime DatePlaced { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public ApplicationUser User { get; set; }
}
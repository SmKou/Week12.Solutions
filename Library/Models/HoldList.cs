namespace Library.Models;

public class HoldList
{
    public int HoldListId { get; set; }
    public DateTime DatePlaced { get; set; }
    public DateTime DateReleased { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public ApplicationUser User { get; set; }
}
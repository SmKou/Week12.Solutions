namespace Library.Models;

public class Checkout
{
    public int CheckoutId { get; set; }
    public DateTime CheckedOut { get; set; }
    public DateTime DueDate { get; set; }
    public int NumRenewals { get; set; }

    public int BookCopyId { get; set; }
    public BookCopy BookCopy { get; set; }

    public int PatronId { get; set; }
    public Patron Patron { get; set; }

    public int StatusId { get; set; }
    public Status Status { get; set; }
}
namespace Library.Models;

public class Checkout
{
    public int CheckoutId { get; set; }
    public DateTime CheckedOut { get; set; }
    public DateTime DueDate { get; set; }
    public int NumRenewals { get; set; }
    public string Status { get; set; }
    public bool Returned { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public ApplicationUser User { get; set; }
}
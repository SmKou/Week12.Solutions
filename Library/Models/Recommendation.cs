namespace Library.Models;

public class Recommendation
{
    public int RecommendationId { get; set; }
    public bool Recommended { get; set; }
    public bool Anonymous { get; set; }
    public bool CheckoutConfirmed { get; set; }
    public int Rating { get; set; }
    public string Text { get; set; }
    
    public int BookId { get; set; }
    public Book Book { get; set; }

    public ApplicationUser User { get; set; }
}
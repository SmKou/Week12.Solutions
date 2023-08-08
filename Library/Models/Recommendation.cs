namespace Library.Models;

public class Recommendation
{
    public int RecommendationId { get; set; }
    public bool ShowAsAnonymous { get; set; }
    public bool ConfirmedCheckout { get; set; }
    public int Rating { get; set; }
    public string Review { get; set; }

    public int BookVersionId { get; set; }
    public BookVersion BookVersion { get; set; }

    public int PatronId { get; set; }
    public Patron Patron { get; set; }
}
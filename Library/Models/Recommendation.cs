namespace Library.Models;

public class Recommendation
{
    public int RecommendationId { get; set; }
    public bool ShowAsAnonymous { get; set; }
    public bool ConfirmedCheckout { get; set; }
    public int Rating { get; set; }
    public string Review { get; set; }
    public bool RecommendationForBook { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public int BookSerialId { get; set; }
    public BookSerial BookSerial { get; set; }

    public int PatronId { get; set; }
    public Patron Patron { get; set; }
}
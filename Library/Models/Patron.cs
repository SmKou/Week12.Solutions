namespace Library.Models;

public class Patron
{
    public int PatronId { get; set; }

    public int GuardianId { get; set; }
    public Patron Guardian { get; set; }

    public List<PatronCategory> Categories { get; }
    public List<PatronAuthor> Authors { get; }

    public List<OnHold> Holds { get; }
    public List<WaitList> Waitlists { get; }
    public List<Recommendation> Recommendations { get; }
    public List<Checkout> Checkouts { get; }

    public ApplicationUser User { get; set; }
}
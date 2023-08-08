namespace Library.Models;

public class PatronRelation
{
    public int PatronRelationId { get; set; }
    public string Relation { get; set; }

    public int PatronId { get; set; }
    public Patron Patron { get; set; }

    public int GuardianId { get; set; }
    public Patron Guardian { get; set; }
}
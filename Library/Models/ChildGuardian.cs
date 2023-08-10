namespace Library.Models;

public class ChildGuardian
{
    public int ChildGuardianId { get; set; }
    public string Relation { get; set; }
    public bool HasPermissionToCheckoutAlone { get; set; }
    public bool HasPermissionForComputer { get; set; }
    public bool HasPermissionToPrint { get; set; }
    public bool HasPermissionToPublish { get; set; }

    public int MaturityRatingId { get; set; }
    public MaturityRating MaturityRating { get; set; }

    public int ChildPatronId { get; set; }
    public Patron ChildPatron;

    public int GuardianPatronId { get; set; }
    public Patron GuardianPatron;
}
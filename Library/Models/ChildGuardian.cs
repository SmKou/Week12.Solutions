namespace Library.Models;

public class ChildGuardian
{
    public int ChildGuardianId { get; set; }
    public string Relation { get; set; }
    public bool HasPermissionToCheckoutAlone { get; set; }
    public bool HasPermissionForComputer { get; set; }
    public bool HasPermissionToPrint { get; set; }
    public bool HasPermissionToPublish { get; set; }
    public string MaturityRating { get; set; }

    public ApplicationUser ChildUser { get; set; }
    public ApplicationUser GuardianUser { get; set; }
}
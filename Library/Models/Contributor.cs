namespace Library.Models;

public class Contributor
{
    public int ContributorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfessionalName { get; set; }
    public DateTime DOB { get; set; }
    public string Bio { get; set; }

    public bool Deceased { get; set; }
    public DateTime DOD { get; set; }
    public ApplicationUser? User { get; set; }

    List<BookContributor> Books { get; }

    // firstname-lastname-professionalname-dob
    public string Searchable { get; set; }
}
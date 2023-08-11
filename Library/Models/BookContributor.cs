namespace Library.Models;

public class BookContributor
{
    public int BookContributorId { get; set; }
    public string Role { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public int ContributorId { get; set; }
    public Contributor Contributor { get; set; }
}
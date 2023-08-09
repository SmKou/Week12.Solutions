namespace Library.Models;

public class BookContributor
{
    public int BookContributorId { get; set; }
    public string Role { get; set; }

    public int BookVersionId { get; set; }
    public BookVersion BookVersion { get; set; }

    public int ContributorId { get; set; }
    public Contributor Contributor { get; set; }
}
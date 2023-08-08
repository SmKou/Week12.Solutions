namespace Library.Models;

public class AuthorCategory
{
    public int AuthorCategoryId { get; set; }
    public bool PrefersToWrite { get; set; }
    public int DegreeOfPreference { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
namespace Library.Models;

public class PatronCategory
{
    public int PatronCategoryId { get; set; }
    public bool PrefersToRead { get; set; }
    public int DegreeOfPreference { get; set; }

    public int PatronId { get; set; }
    public Patron Patron { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
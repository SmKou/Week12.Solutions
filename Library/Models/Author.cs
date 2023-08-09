namespace Library.Models;

public class Author
{
    public int AuthorId { get; set; }
    public string PenName { get; set; }
    public string Searchable { get; set; }
    public string Bio { get; set; }
    
    public bool Deceased { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }

    public List<AuthorCategory> Categories { get; }
    public List<BookAuthor> Authors { get; }
    public ApplicationUser User { get; set; }
}
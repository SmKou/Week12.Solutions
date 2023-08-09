namespace Library.Models;

public class PatronAuthor
{
    public int PatronAuthorId { get; set; }
    public bool WatchReleases { get; set; }
    
    public int PatronId { get; set; }
    public Patron Patron { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; }
}
namespace Library.Models;

public class Author
{
    public int AuthorId { get; set; }
    public string Bio { get; set; }

    public List<AuthorCategorie> Categories { get; }
    public List<BookAuthor> Authors { get; }

    public ApplicationUser User { get; set; }
}
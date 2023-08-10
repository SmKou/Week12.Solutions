using Library.Models;

namespace Library.ViewModels;

public class BookMatchViewModel
{
    public int BookId { get; set; }
    public Book Book { get; set; }

    public string Title { get; set; }

    public string MatchInTitles { get; set; }
    public string MatchInAuthors { get; set; }
}
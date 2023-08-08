namespace Library.Models;

public static class DataInitializer
{
    private readonly LibraryContext _db;

    public static void Init(LibraryContext db)
    {
        _db = db;

        if (_db.Books.Any())
        {
            return;
        }

        Book[] books = new Book[]
        {
            new Book { Title = "Book Title" }
        };

        _db.Books.AddRange(books);
        _db.SaveChanges();
    }
}
namespace Library.Models;

public class BookCategory
{
    public int BookCategoryId { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
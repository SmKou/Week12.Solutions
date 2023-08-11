namespace Library.Models;

public class Publisher
{
    public int PublisherId { get; set; }
    public string Name { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string StateOrProvince { get; set; }
    public string Country { get; set; }
    public string Url { get; set; } 

    List<BookPublisher> Books { get; }
}
namespace Library.Models;

public class BookSerial 
{
    public int BookSerialId { get; set; }
    public string Searchable { get; set; }
    public bool IsFinished { get; set; }

    public List<SerialTitle> Titles { get; }
    public List<Book> Books { get; }
    public List<Recommendation> Recommendations { get; }
}
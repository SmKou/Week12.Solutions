namespace Library.Models;

public class BookSerial 
{
    public int BookSerialId { get; set; }
    // serial title in english - author penname
    public string SerialName { get; set; }
    public bool IsFinished { get; set; }

    public List<SerialTitle> Titles { get; }
    public List<Book> Books { get; }
    public List<Recommendation> Recommendations { get; }
}
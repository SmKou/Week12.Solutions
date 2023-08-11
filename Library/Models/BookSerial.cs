namespace Library.Models;

public class BookSerial
{
    public int BookSerialId { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public int SerialId { get; set; }
    public Serial Serial { get; set; }
}
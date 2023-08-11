namespace Library.Models;

public class Serial
{
    public int SerialId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsFinished { get; set; }

    List<BookSerial> Books { get; }
}
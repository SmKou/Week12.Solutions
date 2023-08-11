namespace Library.Models;

public class SharedScript
{
    public int ScriptId { get; set; }
    
    public int BookAId { get; set; }
    public Book BookA { get; set; }

    public int BookBId { get; set; }
    public Book BookB { get; set; }
}
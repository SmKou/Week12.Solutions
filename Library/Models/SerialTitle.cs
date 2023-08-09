namespace Library.Models;

public class SerialTitle
{
    public int SerialTitleId { get; set; }
    public string Title { get; set; }

    public int BookSerialId { get; set; }
    public BookSerial BookSerial { get; set; }

    public int LanguageId { get; set; }
    public Language Language { get; set; }
}
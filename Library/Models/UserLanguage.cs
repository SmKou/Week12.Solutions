namespace Library.Models;

public class UserLanguage
{
    public int UserLanguageId { get; set; }
    
    public ApplicationUser User { get; set; }

    public int LanguageId { get; set; }
    public Language Language { get; set; }
}
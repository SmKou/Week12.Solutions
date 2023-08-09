using Microsoft.AspNetCore.Identity;

namespace Library.Models;

public class ApplicationUser : IdentityUser
{
    /* Inherited */
    // Id
    // Role
    // UserName
    // NormalizedUserName
    // Email
    // NormalizedEmail
    // PasswordHash
    // PhoneNumber
    
    public string CardNumber { get; set; }
    
    public int PersonId { get; set; }
    public Person Person;

    public List<UserLanguage> Languages { get; }
    public List<UserNotification> Notifications { get; }
}
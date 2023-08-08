using Microsoft.AspNetCore.Identity;

namespace Library.Models;

public class ApplicationUser : IdentityUser
{
    /* Inherited */
    // Id
    // Role
    // FirstName
    // LastName
    // UserName
    // NormalizedUserName
    // Email
    // NormalizedEmail
    // PasswordHash
    // PhoneNumber
    
    public DateTime DateOfBirth { get; set; }
    public string CardNumber { get; set; }
    public string Country { get; set; }

    public List<UserLanguage> Languages { get; }
    public List<UserNotification> Notifications { get; }
}
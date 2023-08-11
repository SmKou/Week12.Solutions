using Microsoft.AspNetCore.Identity;

namespace Library.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DOB { get; set; }
    public string Country { get; set; }
    public string PreferredLanguage { get; set; }
    public string CardNumber { get; set; }

    public List<Notification> Notifications { get; }
    public List<UserList> Lists { get; }
    public List<Checkout> Checkouts { get; }
    public List<HoldList> Holds { get; }

    // firstname-lastname-dob-cardnumber
    public string Searchable { get; set; }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Library.Models;

public class LibraryContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contributor> Contributors { get; set; }
    public DbSet<ListEntry> ListEntries { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }
    public DbSet<Serial> Serials { get; set; }

    public DbSet<BookCategory> BookCategories { get; set; }
    public DbSet<BookContributor> BookContributors { get; set; }
    public DbSet<BookPublisher> BookPublishers { get; set; }
    public DbSet<BookSerial> BookSerials { get; set; }
    public DbSet<Checkout> Checkouts { get; set; }
    public DbSet<ChildGuardian> ChildGuardians { get; set; }
    public DbSet<HoldList> HoldList { get; set; }
    public DbSet<SharedScript> SharedScripts { get; set; }
    public DbSet<UserList> UserLists { get; set; }
    public DbSet<WaitList> WaitList { get; set; }

    public LibraryContext(DbContextOptions options) : base(options) { }
}
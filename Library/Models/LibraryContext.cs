using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Library.Models;

public class LibraryContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Checkout> Checkouts { get; set; }
    public DbSet<Format> Formats { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<MaturityRating> MaturityRatings { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Patron> Patrons { get; set; }
    public DbSet<Publisher> Publisher { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }
    public DbSet<Status> Statuses { get; set; }

    public DbSet<OnHold> OnHolds { get; set; }
    public DbSet<WaitList> WaitLists { get; set; }

    public DbSet<AuthorCategory> AuthorCategories { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }
    public DbSet<BookCopy> BookCopies { get; set; }
    public DbSet<BookVersion> BookVersions { get; set; }
    public DbSet<PatronCategory> PatronCategories { get; set; }
    public DbSet<UserLanguage> UserLanguages { get; set; }
    public DbSet<UserNotification> UserNotifications { get; set; }

    public LibraryContext(DbContextOptions options) : base(options) {}
}
namespace Library.Models;

public class LibraryContext : IdentityDbContext<AppUser>
{
    public LibraryContext(DbContextOptions options) : base(options) {}
}
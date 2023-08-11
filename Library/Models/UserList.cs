namespace Library.Models;

public class UserList
{
    public int UserListId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ApplicationUser User { get; set; }

    public int EntryId { get; set; }
    public Entry Entry { get; set; }
}
namespace Library.Models;

public class Notification
{
    public int NotificationId { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Message { get; set; }
    public bool Seen { get; set; }
    public bool Resolved { get; set; }

    public ApplicationUser User { get; set; }
}
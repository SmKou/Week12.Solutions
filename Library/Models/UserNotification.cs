namespace Library.Models;

public class UserNotification
{
    public int UserNotificationId { get; set; }
    public DateTime SentAt { get; set; }
    public bool SeenByUser { get; set; }
    
    public int NotificationId { get; set; }
    public Notification Notification { get; set; }

    public ApplicationUser User { get; set; }
}
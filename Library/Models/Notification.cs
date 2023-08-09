namespace Library.Models;

public class Notification
{
    public int NotificationId { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string Message { get; set; }
    public string Item { get; set; }

    public string GetMessage()
    {
        if (Item != null)
            return Message + Item;

        return "Invalid message";
    }

    public void ConvertItemsToList(string[] items)
    {
        string list = items[0];
        for (int i = 0; i < items.Length; i++)
        {
            if (i != 0 && items.Length != 2)
                list += ", ";
            if (i == items.Length - 1)
                list += "and ";
            list += items[i];
            if (i == 0 && items.Length == 2)
                list += " ";
        }
        Item = list;
    }
}
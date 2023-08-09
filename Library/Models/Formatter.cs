namespace Library.Models;

public static class SearchFormatter
{
    public static string FormatSearchableTitle(string title)
    {
        return String.Join(
            "", 
            title.ToLower()
                .Split(new char[] { '\'', ':', '-', ' ' })
        );
    }

    public static string FormatSearchableName(string name)
    {
        return String.Join(
            "", 
            name.ToLower()
                .Split(" ")
        );
    }

    public static string FormatSearchableName(string first, string last)
    {
        return FormatSearchableName(first + last);
    }

    public static string FormatSearchable(string title, string name)
    {
        return FormatSearchableTitle(title) + "-" + FormatSearchableName(name);
    }

    public static string FormatSearchable(string title, string first, string last)
    {
        return FormatSearchable(title, first + last);
    }
}
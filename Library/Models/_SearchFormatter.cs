namespace Library.Models;

public static class SearchFormatter
{
    public static string Format(string s)
    {
        return String.Join(
            "",
            s.ToLower().Split(new char[] { '\'', ':', '-', ' ', '.' })
        );
    }

    public static string Format(string s_a, string s_b)
    {
        return Format(s_a + s_b);
    }

    public static string Format(string s_a, string s_b, string s_c)
    {
        return Format(s_a + s_b + s_c);
    }

    public static string FormatDate(DateTime yms)
    {
        return yms.ToString("yyyyMMdd");
    }

    public static string FormatPresentable(string s)
    {
        string[] words = s.Split(" ");
        for (int i = 0; i < words.Length; i++)
        {
            if (i != 0 && words[i] != "a" && words[i] != "an"
            && words[i] != "of" && words[i] != "the" && words[i] != "on")
                words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1);
        }
        return String.Join(" ", words);
    }

    public static string FormatList(string[] list)
    {
        string line = "";
        for (int i = 0; i < list.Length; i++)
        {
            if (i != 0 && list.Length != 2)
                line += ",";
            line += " ";
            if (i == list.Length - 1)
                line += "and ";
            line += list[i];
        }
        return line;
    }

    public static string FormatList(List<string> list)
    {
        return FormatList(list.ToArray());
    }

    public static string FormatList(string s)
    {
        return FormatList(s.Split(" "));
    }
}
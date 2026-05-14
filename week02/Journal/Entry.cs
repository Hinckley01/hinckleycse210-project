// Entry.cs - Represents a single journal entry

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    // Default constructor needed for loading from file
    public Entry() { }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine(new string('-', 50));
    }

    // Serialize entry to a single line using ~|~ as separator
    public string ToFileLine()
    {
        return $"{Date}~|~{Prompt}~|~{Response}";
    }

    // Deserialize entry from a file line
    public static Entry FromFileLine(string line)
    {
        string[] parts = line.Split("~|~");
        if (parts.Length != 3)
            throw new FormatException($"Invalid entry format: {line}");

        return new Entry(parts[0], parts[1], parts[2]);
    }
}

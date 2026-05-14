// Journal.cs - Manages a collection of journal entries

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found in the journal.");
            return;
        }

        Console.WriteLine($"\n===== Journal ({_entries.Count} entries) =====\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileLine());
            }
        }
        Console.WriteLine($"Journal saved to '{filename}' ({_entries.Count} entries).");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"Error: File '{filename}' not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                try
                {
                    _entries.Add(Entry.FromFileLine(line));
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Warning: Skipping malformed line. {ex.Message}");
                }
            }
        }

        Console.WriteLine($"Journal loaded from '{filename}' ({_entries.Count} entries).");
    }

    public int Count => _entries.Count;
}

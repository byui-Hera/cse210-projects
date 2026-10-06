public class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal has no entries yet.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }


    public void DisplayMatchingEntries(string searchTerm)
    {
        List<Entry> matches = _entries
            .Where(entry =>
                entry.Date.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                entry.Prompt.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                entry.Response.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (matches.Count == 0)
        {
            Console.WriteLine("No matching journal entries were found.");
            return;
        }

        foreach (Entry entry in matches)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using StreamWriter writer = new StreamWriter(filename);

        foreach (Entry entry in _entries)
        {
            writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
        }
        Console.WriteLine("Journal saved.");
    }

    public void LoadFromFile(string filename)
    {
        List<Entry> loadedEntries = new List<Entry>();

        foreach (string line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split('|');

            if (parts.Length == 3)
            {
                loadedEntries.Add(new Entry(
                    parts[0].Trim(),
                    parts[1].Trim(),
                    parts[2].Trim()));
            }
        }

        _entries.Clear();
        _entries.AddRange(loadedEntries);
        Console.WriteLine("Journal loaded.");
    }
}
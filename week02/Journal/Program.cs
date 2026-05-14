// Program.cs - Entry point and menu for the Journal program
//
// === Exceeding Requirements ===
// 1. Added a PromptGenerator class with 10 prompts (requirement was 5).
// 2. Entries are saved with the current date AND time, giving a more precise record.
// 3. The program displays the total entry count on the main menu so users can
//    see at a glance how many entries exist without selecting "Display Journal".
// 4. Added input validation so the program won't crash on empty responses.
// 5. The separator "~|~" was chosen deliberately to be highly unlikely to appear
//    in normal journal text, reducing the chance of data corruption.

class Program
{
    static Journal journal = new Journal();
    static PromptGenerator promptGenerator = new PromptGenerator();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your Personal Journal!");

        bool running = true;
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine()?.Trim() ?? "";

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye! Keep writing!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please enter 1-5.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine($"===== Journal Menu (Entries: {journal.Count}) =====");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
    }

    static void WriteNewEntry()
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"\nToday's prompt: {prompt}");
        Console.Write("> ");

        string response = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(response))
        {
            Console.WriteLine("No response entered. Entry not saved.");
            return;
        }

        // Store date AND time for a more precise journal record (exceeds requirements)
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        Entry entry = new Entry(date, prompt, response);
        journal.AddEntry(entry);
        Console.WriteLine("Entry saved!");
    }

    static void SaveJournal()
    {
        Console.Write("Enter filename to save to: ");
        string filename = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("No filename entered. Save cancelled.");
            return;
        }

        journal.SaveToFile(filename);
    }

    static void LoadJournal()
    {
        Console.Write("Enter filename to load from: ");
        string filename = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("No filename entered. Load cancelled.");
            return;
        }

        journal.LoadFromFile(filename);
    }
}

// Exceeds requirements:
// 1. Added a Gratitude Activity as a fourth activity type.
// 2. Tracks and displays a log of how many times each activity was completed this session.
// 3. Random questions/prompts are shuffled so all are used before repeating.

class Program
{
    static Dictionary<string, int> _log = new Dictionary<string, int>
    {
        { "Breathing Activity", 0 },
        { "Reflection Activity", 0 },
        { "Listing Activity", 0 },
        { "Gratitude Activity", 0 }
    };

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Program ===\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Breathing Activity");
            Console.WriteLine("  2. Reflection Activity");
            Console.WriteLine("  3. Listing Activity");
            Console.WriteLine("  4. Gratitude Activity");
            Console.WriteLine("  5. View Activity Log");
            Console.WriteLine("  6. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    _log["Breathing Activity"]++;
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    _log["Reflection Activity"]++;
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    _log["Listing Activity"]++;
                    break;
                case "4":
                    GratitudeActivity gratitude = new GratitudeActivity();
                    gratitude.Run();
                    _log["Gratitude Activity"]++;
                    break;
                case "5":
                    ShowLog();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("\nThank you for taking time for mindfulness today. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }

    static void ShowLog()
    {
        Console.Clear();
        Console.WriteLine("=== Activity Log (This Session) ===\n");
        foreach (var entry in _log)
        {
            Console.WriteLine($"  {entry.Key}: {entry.Value} time(s)");
        }
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }
}

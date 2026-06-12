public class GratitudeActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "What are three things that went well today?",
        "Who is someone that has positively impacted your life recently?",
        "What is something about your health you are grateful for?",
        "What is a simple pleasure in your life you are thankful for?",
        "What is something about where you live that you appreciate?"
    };

    public GratitudeActivity() : base(
        "Gratitude Activity",
        "This activity will help you focus on the positive by guiding you to think deeply about things you are grateful for in your life. Gratitude has been shown to improve mood and overall well-being.")
    {
    }

    public void Run()
    {
        DisplayStartMessage();

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine($"\nConsider this:\n{prompt}");
        Console.WriteLine("\nTake a moment to think...");
        ShowSpinner(5);

        Console.WriteLine("\n\nNow write your thoughts below. Press Enter after each one:");

        List<string> entries = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry))
            {
                entries.Add(entry);
            }
        }

        Console.WriteLine($"\nBeautiful! You recorded {entries.Count} things to be grateful for.");
        DisplayEndMessage();
    }
}

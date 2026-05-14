// PromptGenerator.cs - Manages the list of journal prompts and selects one randomly

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something I learned today, big or small?",
        "What am I most grateful for today?",
        "What challenged me today, and how did I respond?",
        "Describe a moment today when you felt fully present.",
        "What is one thing I want to remember about today?",
        "What did I do today that I am proud of?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    public List<string> GetAllPrompts()
    {
        return new List<string>(_prompts);
    }
}

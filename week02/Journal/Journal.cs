public class Journal
{
    public List<Entry> _entries { get; set; } = new List<Entry>();
    public List<string> _prompts = new List<string> {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was my primary focus today and how well did I do?",
        "What scriptures did I study today and what promptings did I receive?",
        "How did I make another person's burdens lighter today?",
        "What did I do today to make progress towards my physical, spiritual, or financial goals?",
        "What was something negative that happened today and how can I turn it around to something positive?",
    };
    public Journal()
    {

    }
    public void PromptForEntry()
    {
        string answer = "";
        int promptIndex;
        Random random = new Random();
        string prompt;
        do
        {
            if (answer.ToLower() == "custom")
            {
                // Get Custom Prompt
                Console.WriteLine();
                Console.WriteLine("Write your custom prompt below.");
                Console.Write("JOURNAL PROMPT: ");
                prompt = Console.ReadLine();
            }
            else
            {
                // Get Random Prompt
                promptIndex = random.Next(_prompts.Count);
                prompt = _prompts[promptIndex];
                Console.WriteLine($"JOURNAL PROMPT: {prompt}");
            }
            Console.WriteLine();

            // Get Answer
            Console.WriteLine("You can type NEW to get another prompt.");
            Console.WriteLine("You can type CUSTOM to write your own prompt.");
            Console.WriteLine("You can type CANCEL to exit without creating an entry.");
            Console.Write("JOURNAL ENTRY: ");
            answer = Console.ReadLine();
            Console.WriteLine();
        } while (answer.ToLower() == "new" || answer.ToLower() == "custom");

        // Check For Cancel
        if (answer.ToLower() != "cancel")
        {
            // Add New Entry
            _entries.Add(new Entry(prompt, answer));
        }
    }
    public void Display()
    {
        Console.WriteLine($"Displaying {_entries.Count} Journal " + ((_entries.Count == 1) ? "Entry" : "Entries:"));
        foreach (Entry entry in _entries)
        {
            Console.WriteLine();
            entry.Display();
        }
    }
}
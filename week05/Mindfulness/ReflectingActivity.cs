public class ReflectingActivity : Activity
{
    private List<string> _promptList = new List<string>([
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
    ]);
    private List<string> _questionList = new List<string>([
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
    ]);
    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {

    }
    public void Run()
    {
        StartActivity();
        ShowCountdown(5, "Get ready... ");
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadKey();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        ShowCountdown(5, "You may begin in... ");
        DateTime currentTime = DateTime.Now;
        DateTime endTime = GetDurationDateTime();
        Console.Clear();
        while (currentTime < endTime)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(10);
            currentTime = DateTime.Now;
        }
        EndActivity();

    }
    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _promptList[rand.Next(_promptList.Count)];
    }
    public string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questionList[rand.Next(_questionList.Count)];
    }
}
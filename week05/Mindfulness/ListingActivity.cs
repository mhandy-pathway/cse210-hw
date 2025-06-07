public class ListingActivity : Activity
{
    private List<string> _promptList = new List<string>([
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
    ]);
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {

    }
    public void Run()
    {
        StartActivity();
        ShowCountdown(5, "Get ready...");
        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        ShowCountdown(5, "You may being in... ");
        DateTime currentTime = DateTime.Now;
        DateTime endTime = GetDurationDateTime();
        List<string> answers = new List<string>();
        while (currentTime < endTime)
        {
            Console.Write(" --> ");
            answers.Add(Console.ReadLine());
            currentTime = DateTime.Now;
        }
        Console.WriteLine($"You listed {answers.Count} items!");
        EndActivity();
    }
    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _promptList[rand.Next(_promptList.Count)];
    }
}
using System.Globalization;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    public void StartActivity()
    {
        Console.WriteLine(GetStartMessage());
        PromptForDuration();
    }
    public void EndActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Well Done!");
        ShowSpinner(5);
        Console.WriteLine(GetEndMessage());
        ShowSpinner(5);
    }
    public string GetStartMessage()
    {
        return $"Welcome to the {_name}\n\n{_description}\n";
    }
    public string GetEndMessage()
    {
        return $"You have completed {_duration} seconds of the {_name}.";
    }
    public void PromptForDuration()
    {
        Console.WriteLine("How long, in seconds, would you like the activity to last?");
        Console.Write(" --> ");
        _duration = int.Parse(Console.ReadLine());
    }
    public int GetDuration()
    {
        return _duration;
    }
    public DateTime GetDurationDateTime()
    {
        return DateTime.Now.AddSeconds(_duration);
    }
    public void ShowSpinner(int seconds)
    {
        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddSeconds(seconds);
        int i = 0;
        Console.Write("    ");
        while (currentTime < futureTime)
        {
            i += 1;
            currentTime = DateTime.Now;
            switch (i)
            {
                case 1:
                    Console.Write("\b\b\b\b|   ");
                    break;
                case 2:
                    Console.Write("\b\b\b\b/.  ");
                    break;
                case 3:
                    Console.Write("\b\b\b\b-.. ");
                    break;
                default:
                    Console.Write("\b\b\b\b\\...");
                    i = 0;
                    break;
            }
            Thread.Sleep(200);
        }
        Console.Write("\b\b\b\b    \n");
    }
    public void ShowCountdown(int seconds, string message = "Please wait... ")
    {
        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddSeconds(seconds);
        TimeSpan span;
        int minutesLeft;
        int secondsLeft;
        string timeLeft;
        int i = 0;
        string countdownMessage;
        while (currentTime < futureTime)
        {
            currentTime = DateTime.Now;
            span = futureTime - currentTime;
            minutesLeft = 0;
            secondsLeft = (int)span.TotalSeconds;
            if (secondsLeft < 0)
            {
                secondsLeft = 0;
            }
            while (secondsLeft >= 60)
            {
                minutesLeft += 1;
                secondsLeft -= 60;
            }
            if (secondsLeft < 10)
            {
                timeLeft = $"{minutesLeft}:0{secondsLeft}";
            }
            else
            {
                timeLeft = $"{minutesLeft}:{secondsLeft}";
            }

            countdownMessage = $"\r{message}[";
            switch (i)
            {
                case 0:
                    countdownMessage += "  |  ";
                    i += 1;
                    break;
                case 1:
                    countdownMessage += "   / ";
                    i += 1;
                    break;
                case 2:
                    countdownMessage += "    _";
                    i += 1;
                    break;
                case 3:
                    countdownMessage += "   / ";
                    i += 1;
                    break;
                case 4:
                    countdownMessage += "  |  ";
                    i += 1;
                    break;
                case 5:
                    countdownMessage += " \\   ";
                    i += 1;
                    break;
                case 6:
                    countdownMessage += "_    ";
                    i += 1;
                    break;
                case 7:
                    countdownMessage += " \\   ";
                    i = 0;
                    break;
                default:
                    i = 0;
                    break;
            }
            countdownMessage += $"] - {timeLeft}{new string('.', i)}{new string(' ', 7 - i)}";
            Console.Write(countdownMessage);
            Thread.Sleep(200);
        }
        Console.WriteLine();
    }
}
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {

    }
    public void Run()
    {
        StartActivity();
        ShowCountdown(5, "Prepare to start breathing... ");
        DateTime currentTime = DateTime.Now;
        DateTime endTime = GetDurationDateTime();
        bool breatheIn = true;
        while (currentTime < endTime)
        {
            if (breatheIn)
            {
                ShowCountdown(5, "Breathe In...");
                breatheIn = false;
            }
            else
            {
                ShowCountdown(5, "Breathe Out...");
                Console.WriteLine();
                breatheIn = true;
            }
            currentTime = DateTime.Now;
        }
        EndActivity();
    }
    public void ShowBreathingAnimation(int seconds)
    {
        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddSeconds(seconds);
        TimeSpan span_difference;
        double ms_difference;
        int milliseconds = seconds * 1000;
        float percent;
        int barWidth = 40;
        int leftChar;
        int rightChar;
        while (currentTime < futureTime)
        {
            currentTime = DateTime.Now;
            span_difference = futureTime - currentTime;
            ms_difference = span_difference.TotalMilliseconds;
            percent = (float)(1 - ms_difference / milliseconds);
            if (percent > 1)
            {
                percent = 1;
            }
            leftChar = (int)Math.Round(percent * barWidth);
            rightChar = barWidth - leftChar;
            Console.Write("\r[");
            Console.Write(new string('>', leftChar));
            Console.Write(new string('|', rightChar));
            Console.Write("]");
            Thread.Sleep(150);
        }
    }
}
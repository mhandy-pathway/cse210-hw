public class SwimmingActivity : Activity
{
    private double _numberOfLaps;

    // Constructor
    public SwimmingActivity(DateTime date, int lengthInMinutes, double numberOfLaps) : base(date, lengthInMinutes)
    {
        _numberOfLaps = numberOfLaps;
    }

    // Overridden Methods
    public override string GetActivityType()
    {
        return "Swimming";
    }
    public override double GetDistance()
    {
        return Math.Round(_numberOfLaps * 50 / 1000 * 0.62, 1);
    }
    public override double GetSpeed()
    {
        return Math.Round(GetDistance() / GetLengthInMinutes() * 60, 1);
    }
    public override double GetPace()
    {
        return Math.Round(GetLengthInMinutes() / GetDistance(), 1);
    }
}
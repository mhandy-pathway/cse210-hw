public class RunningActivity : Activity
{
    private double _distance;

    // Constructor
    public RunningActivity(DateTime date, int lengthInMinutes, double distance) : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    // Overridden Methods
    public override string GetActivityType()
    {
        return "Running";
    }
    public override double GetDistance()
    {
        return Math.Round(_distance, 1);
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
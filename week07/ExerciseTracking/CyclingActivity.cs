public class CyclingActivity : Activity
{
    private double _speed;

    // Constructor
    public CyclingActivity(DateTime date, int lengthInMinutes, double speed) : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    // Overridden Methods
    public override string GetActivityType()
    {
        return "Cycling";
    }
    public override double GetDistance()
    {
        return Math.Round(GetLengthInMinutes() * GetSpeed() / 60, 1);
    }
    public override double GetSpeed()
    {
        return Math.Round(_speed, 1);
    }
    public override double GetPace()
    {
        return Math.Round(60 / GetSpeed(), 1);
    }
}
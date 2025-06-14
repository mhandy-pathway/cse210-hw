public abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    // Constructor
    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    // Getters and Setters
    public int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }

    // Abstract Methods
    public abstract string GetActivityType();
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {GetActivityType()} ({_lengthInMinutes} min): Distance {GetDistance()} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}
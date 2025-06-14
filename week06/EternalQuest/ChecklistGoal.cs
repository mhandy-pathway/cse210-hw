public class ChecklistGoal : Goal
{
    private int _timesNeeded;
    private int _timesCompleted = 0;
    private int _bonusPoints;
    public ChecklistGoal() : base()
    {
        // Ask for additional fields
        Console.WriteLine("How many times should the goal be completed?");
        Console.Write(" --> ");
        try
        {
            _timesNeeded = int.Parse(Console.ReadLine());
        }
        catch
        {
            _timesNeeded = 1;
        }
        Console.WriteLine("How many bonus points should be earned for completing all goals?");
        Console.Write(" --> ");
        try
        {
            _bonusPoints = int.Parse(Console.ReadLine());
        }
        catch
        {
            _bonusPoints = 0;
        }
    }
    public ChecklistGoal(string serializedObject) : base(serializedObject)
    {
        // No Additional Construct Actions Necessary
    }
    // Records an event and returns the number of points earned.
    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _timesCompleted += 1;
            int points = GetPoints();
            // Check if the user should get bonus points
            if (IsComplete())
            {
                points += _bonusPoints;
            }
            return points;
        }
        else
        {
            return 0;
        }

    }
    public override bool IsComplete()
    {
        return _timesCompleted >= _timesNeeded;
    }
    public override string GetDisplayString()
    {
        return $"{base.GetDisplayString()} -- Currently Completed: {_timesCompleted}/{_timesNeeded}";
    }
    public override Dictionary<string, string> GetDictionaryForSerialization()
    {
        Dictionary<string, string> dictionary = base.GetDictionaryForSerialization();
        dictionary.Add("timesNeeded", _timesNeeded.ToString());
        dictionary.Add("timesCompleted", _timesCompleted.ToString());
        dictionary.Add("bonusPoints", _bonusPoints.ToString());
        return dictionary;
    }
    public override void PopulateWithDictionary(Dictionary<string, string> dictionary)
    {
        base.PopulateWithDictionary(dictionary);
        _timesNeeded = int.Parse(dictionary["timesNeeded"]);
        _timesCompleted = int.Parse(dictionary["timesCompleted"]);
        _bonusPoints = int.Parse(dictionary["bonusPoints"]);
    }
}
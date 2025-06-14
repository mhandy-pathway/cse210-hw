public class EternalGoal : Goal
{
    private int _timesCompleted = 0;
    public EternalGoal() : base()
    {
        // No Additional Construct Actions Necessary
    }
    public EternalGoal(string serializedObject) : base(serializedObject)
    {
        // No Additional Construct Actions Necessary
    }
    // Records an event and returns the number of points earned.
    public override int RecordEvent()
    {
        _timesCompleted += 1;
        return GetPoints();
    }
    public override bool IsComplete()
    {
        return false;
    }
    public override string GetDisplayString()
    {
        return $"{base.GetDisplayString()} -- Times Completed: {_timesCompleted}";
    }
    public override Dictionary<string, string> GetDictionaryForSerialization()
    {
        Dictionary<string, string> dictionary = base.GetDictionaryForSerialization();
        dictionary.Add("timesCompleted", _timesCompleted.ToString());
        return dictionary;
    }
    public override void PopulateWithDictionary(Dictionary<string, string> dictionary)
    {
        base.PopulateWithDictionary(dictionary);
        _timesCompleted = int.Parse(dictionary["timesCompleted"]);
    }
}
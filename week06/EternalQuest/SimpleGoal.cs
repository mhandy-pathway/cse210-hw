public class SimpleGoal : Goal
{
    private bool _completed = false;
    public SimpleGoal() : base()
    {
        // No Additional Construct Actions Necessary
    }
    public SimpleGoal(string serializedObject) : base(serializedObject)
    {
        // No Additional Construct Actions Necessary
    }
    // Records an event and returns the number of points earned.
    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _completed = true;
            return GetPoints();
        }
        else
        {
            return 0;
        }
    }
    public override bool IsComplete()
    {
        return _completed;
    }
    public override Dictionary<string, string> GetDictionaryForSerialization()
    {
        Dictionary<string, string> dictionary = base.GetDictionaryForSerialization();
        dictionary.Add("completed", _completed.ToString());
        return dictionary;
    }
    public override void PopulateWithDictionary(Dictionary<string, string> dictionary)
    {
        base.PopulateWithDictionary(dictionary);
        _completed = bool.Parse(dictionary["completed"]);
    }
}
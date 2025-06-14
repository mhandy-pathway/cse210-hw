using System.Text.Json;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal()
    {
        Console.WriteLine("What is the name of your goal?");
        Console.Write(" --> ");
        _name = Console.ReadLine();
        Console.WriteLine("What is the short description of your goal?");
        Console.Write(" --> ");
        _description = Console.ReadLine();
        Console.WriteLine("How many points should be earned when the goal is performed?");
        Console.Write(" --> ");
        try
        {
            _points = int.Parse(Console.ReadLine());
        }
        catch
        {
            _points = 0;
        }
    }
    public Goal(string serializedObject)
    {
        Deserialize(serializedObject);
    }
    // Records an event and returns the number of points earned.
    public abstract int RecordEvent();

    public int GetPoints()
    {
        return _points;
    }
    public abstract bool IsComplete();
    public virtual string GetDisplayString()
    {
        string checkmark;
        if (IsComplete())
        {
            checkmark = "[X]";
        }
        else
        {
            checkmark = "[ ]";
        }
        return $"{checkmark} {_name} ({_description})";
    }
    public virtual Dictionary<string, string> GetDictionaryForSerialization()
    {
        Dictionary<string, string> returnDictionary = new Dictionary<string, string>();
        returnDictionary.Add("name", _name);
        returnDictionary.Add("description", _description);
        returnDictionary.Add("points", _points.ToString());
        return returnDictionary;
    }
    public string Serialize()
    {
        Dictionary<string, string> dictionary = GetDictionaryForSerialization();
        return JsonSerializer.Serialize(dictionary);
    }
    public void Deserialize(string serializedObject)
    {
        Dictionary<string, string> dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(serializedObject);
        PopulateWithDictionary(dictionary);
    }
    public virtual void PopulateWithDictionary(Dictionary<string, string> dictionary)
    {
        _name = dictionary["name"];
        _description = dictionary["description"];
        _points = int.Parse(dictionary["points"]);
    }
}
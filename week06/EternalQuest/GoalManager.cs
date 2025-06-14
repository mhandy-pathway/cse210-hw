using System.Text.Json;
public class GoalManager
{
    private int _score = 0;
    private List<Goal> _goalList = new List<Goal>();
    private Level _currentLevel;
    private List<Level> _levelList = new List<Level>();

    public void CreateNewGoal()
    {
        Console.WriteLine("What type of goal would you like to add?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write(" --> ");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                _goalList.Add(new SimpleGoal());
                break;
            case "2":
                _goalList.Add(new EternalGoal());
                break;
            case "3":
                _goalList.Add(new ChecklistGoal());
                break;
            default:
                Console.WriteLine("Invalid Choice...");
                Console.WriteLine("Aborting...");
                Console.WriteLine();
                break;
        }
    }
    public void ListGoals(bool showCurrentScore = true)
    {
        Console.WriteLine("Your Current Goals Are:");
        int i = 0;
        foreach (Goal goal in _goalList)
        {
            i += 1;
            Console.WriteLine($"{i}. {goal.GetDisplayString()}");
        }
        Console.WriteLine();
        if (showCurrentScore)
        {
            Console.WriteLine($"Your Current Score: {_score}");
            Console.WriteLine($"Your Current Level: {_currentLevel.GetName()}");
            Console.WriteLine();
        }

    }
    public void LoadFromFile()
    {
        // Get Filename From User
        Console.WriteLine("Please specify a filename to load the goals from.");
        Console.WriteLine("You do not need to specify an extension, because \".json\" will always be used.");
        Console.Write("Filename: ");
        string filename = Console.ReadLine() + ".json";

        // Check if File Exists and Display Error If Not
        if (!File.Exists(filename))
        {
            Console.WriteLine("ERROR: The specified file does not exist.");
            Console.WriteLine("Aborting Load...");
            return;
        }

        // Load From File
        Console.WriteLine("Loading From File...");
        using (StreamReader inputFile = new StreamReader(filename))
        {
            // Deserialize Data
            Dictionary<string, string> dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(inputFile.BaseStream);
            _score = int.Parse(dictionary["score"]);
            CalculateCurrentLevel();
            List<Dictionary<string, string>> goalStrings = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(dictionary["goalStrings"]);
            _goalList = new List<Goal>();
            foreach (Dictionary<string, string> goalString in goalStrings)
            {
                switch (goalString["goalType"])
                {
                    case "SimpleGoal":
                        _goalList.Add(new SimpleGoal(goalString["goalData"]));
                        break;
                    case "EternalGoal":
                        _goalList.Add(new EternalGoal(goalString["goalData"]));
                        break;
                    case "ChecklistGoal":
                        _goalList.Add(new ChecklistGoal(goalString["goalData"]));
                        break;
                }
            }
        }
    }
    public void SaveToFile()
    {
        // Get Filename From User
        Console.WriteLine("Please specify a filename to save the goals to.");
        Console.WriteLine("You do not need to specify an extension, because \".json\" will always be used.");
        Console.Write("Filename: ");
        string filename = Console.ReadLine() + ".json";

        // Check if File Exists and Confirm Overwrite
        if (File.Exists(filename))
        {
            Console.WriteLine($"The file \"{filename}\" currently exists.");
            Console.WriteLine("Writing goals to this file will DELETE all goals in the file.");
            Console.WriteLine("Are you sure you want to do this?");
            Console.Write("Enter Y or N: ");
            string overwrite = Console.ReadLine();
            if (overwrite.ToLower() != "y" && overwrite.ToLower() != "n")
            {
                Console.WriteLine("Invalid Answer.");
            }
            if (overwrite.ToLower() != "y")
            {
                Console.WriteLine("Aborting Write to File...");
                return;
            }
        }

        // Serialize Data
        List<Dictionary<string, string>> goalStrings = new List<Dictionary<string, string>>();
        foreach (Goal goal in _goalList)
        {
            Dictionary<string, string> goalDictionary = new Dictionary<string, string>();
            goalDictionary.Add("goalType", goal.GetType().ToString());
            goalDictionary.Add("goalData", goal.Serialize());
            goalStrings.Add(goalDictionary);
        }
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("score", _score.ToString());
        dictionary.Add("goalStrings", JsonSerializer.Serialize(goalStrings));

        // Write to File
        Console.WriteLine("Writing To File...");
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // Write Serialized Object to JSON File
            outputFile.WriteLine(JsonSerializer.Serialize(dictionary));
        }
    }
    public void RecordEvent()
    {
        ListGoals(false);
        Console.WriteLine("Which goal do you want to record an event for?");
        Console.Write(" --> ");
        int choice = -1;
        try
        {
            choice = int.Parse(Console.ReadLine()) - 1;
        }
        catch
        {
            // Do Nothing
        }
        if (choice >= 0 && choice < _goalList.Count)
        {
            Level preEventLevel = _currentLevel;
            _score += _goalList[choice].RecordEvent();
            CalculateCurrentLevel();
            if (preEventLevel != _currentLevel)
            {
                Console.WriteLine();
                Console.WriteLine(_currentLevel.GetCongratulationsString());
                Console.WriteLine();
                Console.WriteLine("Press enter to continue...");
                Console.ReadKey();
            }
            ListGoals();
        }
        else
        {
            Console.WriteLine("Invalid Choice...");
            Console.WriteLine("Aborting...");
            Console.WriteLine();
        }
    }
    public void PopulateLevels(List<Level> levelList)
    {
        _levelList = levelList;
        CalculateCurrentLevel();
    }
    public void CalculateCurrentLevel()
    {
        foreach (Level level in _levelList)
        {
            if (level.DoesScoreQualify(_score))
            {
                _currentLevel = level;
            }
        }
    }
}
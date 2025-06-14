using System;
// HOW I SHOWED CREATIVITY AND EXCEEDED CORE REQUIREMENTS
// 1. I added levels to the GoalManager and when the user records an event that causes them to gain another level I display
//      a congratulations message.
// 2. I wanted to use JSON Serialization and Deserialization to save and load the goals. I found that I couldn't serialize
//      the data in the private attributes, so I came up with another way where I would create Dictionaries containing the
//      private attribute data and then JSON Serialize the Dictionary. Upon Deserialization I had to populate the values
//      back into the private attributes, and also parse the values for int and bool attributes.
// 3. I modified the EternalGoal class to also display the times the goal has been completed when displaying the list of
//      goals. I found this helpful for me, since the Eternal Goals are never fully completed, it seems very helpful to me
//      to keep track of how many times I have performed that goal.
class Program
{
    private static Menu _menu;
    private static GoalManager _goalManager;
    static void Main(string[] args)
    {
        SetupGoalManager();
        SetupMenu();
        ShowMainMenu();
    }
    static void SetupGoalManager()
    {
        _goalManager = new GoalManager();
        _goalManager.PopulateLevels(new List<Level>([
            new Level("Investigator", 0),
            new Level("Convert", 500),
            new Level("True Believer", 1000),
            new Level("Disciple", 1500),
            new Level("Stripling Warrior", 2000),
        ]));
    }
    static void ShowMainMenu()
    {
        string selectedOptionKey = "";
        while (selectedOptionKey != "Q")
        {
            MenuOption selectedOption = _menu.PromptUser();
            selectedOptionKey = selectedOption.GetOptionKey();
            switch (selectedOptionKey)
            {
                case "1":
                    // Create New Goal
                    _goalManager.CreateNewGoal();
                    break;
                case "2":
                    // List Goals
                    _goalManager.ListGoals();
                    break;
                case "3":
                    // Save Goals
                    _goalManager.SaveToFile();
                    break;
                case "4":
                    // Load Goals
                    _goalManager.LoadFromFile();
                    break;
                case "5":
                    // Record Event
                    _goalManager.RecordEvent();
                    break;
            }
        }

    }
    static void SetupMenu()
    {
        _menu = new Menu(
            [
                "CSE 210 - W06 Project - Matt Handy",
                "Eternal Quest Program",
            ],
            [
                new MenuOption(1, "Create New Goal"),
                new MenuOption(2, "List Goals"),
                new MenuOption(3, "Save Goals"),
                new MenuOption(4, "Load Goals"),
                new MenuOption(5, "Record Event"),
                new MenuOption(),
                new MenuOption('Q', "Quit")
            ]
        );
    }
}
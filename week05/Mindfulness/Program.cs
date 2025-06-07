using System;
// HOW I SHOWED CREATIVITY AND EXCEEDED THE CORE REQUIREMENTS:
// 1. I created a new Activity - the Meditation Activity
// 2. I added Hymn and Note classes to be able to play a small segment of a hymn during the Meditation Activity
// 3. Since the functionality of playing a specific note is only supported on Windows, I do an Operating System check to ensure that windows is in use. If not, a simple beep is played.
class Program
{
    private static Menu _menu;
    private static BreathingActivity _breathingActivity = new BreathingActivity();
    private static ReflectingActivity _reflectingActivity = new ReflectingActivity();
    private static ListingActivity _listingActivity = new ListingActivity();
    private static MeditationActivity _meditationActivity = new MeditationActivity();
    static void Main(string[] args)
    {
        SetupMenu();
        ShowMainMenu();
    }
    static void ShowMainMenu()
    {
        string selectedOptionKey = "";
        while (selectedOptionKey != "Q")
        {
            MenuOption selectedOption = _menu.PromptUser();
            selectedOptionKey = selectedOption.GetOptionKey();
            if (selectedOptionKey == "1")
            {
                // Breathing Activity
                _breathingActivity.Run();
            }
            else if (selectedOptionKey == "2")
            {
                // Reflecting Activity
                _reflectingActivity.Run();
            }
            else if (selectedOptionKey == "3")
            {
                // Listing Activity
                _listingActivity.Run();
            }
            else if (selectedOptionKey == "4")
            {
                // Meditation Activity
                _meditationActivity.Run();
            }
        }

    }
    static void SetupMenu()
    {
        _menu = new Menu(
            [
                "CSE 210 - W05 Project - Matt Handy",
                "Mindfulness Program",
            ],
            [
                new MenuOption(1, "Breathing Activity"),
                new MenuOption(2, "Reflecting Activity"),
                new MenuOption(3, "Listing Activity"),
                new MenuOption(4, "Meditation Activity"),
                new MenuOption(),
                new MenuOption('Q', "Quit")
            ]
        );
    }
}
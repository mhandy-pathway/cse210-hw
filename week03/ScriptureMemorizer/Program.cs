// CSE 210
// Matt Handy
// W03 Project
// Submitted on 5/19/2025
// NOTE ABOUT CORE REQUIREMENTS:
// To see the functionality of the core requirements, please select menu option "2. Disappearing Scripture Game"
// HOW I EXCEEDED THE CORE REQUIREMENTS AND SHOWED CREATIVITY:
// 1. Created a class to load scriptures and pre loaded it with Book of Mormon Mastery scriptures.
// 2. Allowed the user to pick a scripture from the list or change to another randomly selected scripture.
// 3. Created a Word Guess Game starting the user with a hidden scripture and allowing them to enter word guesses.
// 4. Created a Letter Guess Game staring the user with a hidden scripture and allowing them to enter letter guesses.
// 5. Created a Menu class and a MenuOption class that I will use on future projects to facilitate menu creation.
class Program
{
    private static Menu _mainMenu;
    private static Menu _scriptureMenu;
    private static Scripture _scripture;
    private static ScriptureLoader _scriptureLoader;
    private static Games _games;
    static void Main(string[] args)
    {
        SetupMenus();
        LoadScriptures();
        SetupGames();
        ShowMainMenu();
    }
    static void ShowMainMenu()
    {
        string selectedOptionKey = "";
        while (selectedOptionKey != "Q")
        {
            MenuOption selectedOption = _mainMenu.PromptUser();
            selectedOptionKey = selectedOption.GetOptionKey();
            if (selectedOptionKey == "1")
            {
                // Scripture Menu
                ShowScriptureMenu();
            }
            else if (selectedOptionKey == "2")
            {
                _games.PlayDisappearingScriptureGame(_scripture);
            }
            else if (selectedOptionKey == "3")
            {
                _games.PlayWordGame(_scripture);
            }
            else if (selectedOptionKey == "4")
            {
                _games.PlayLetterGame(_scripture);
            }
        }

    }
    static void ShowScriptureMenu()
    {
        MenuOption selectedOption = _scriptureMenu.PromptUser();
        string selectedOptionKey = selectedOption.GetOptionKey();
        if (selectedOptionKey == "1")
        {
            // Select A Scripture
            List<Reference> references = _scriptureLoader.GetReferenceList();
            for (int i = 0; i < references.Count(); i++)
            {
                Console.WriteLine($"{i + 1}: {references[i].GetFullName()}");
            }
            Console.Write("Pick a Scripture > ");
            try
            {
                int selectedIndex = int.Parse(Console.ReadLine());
                Reference selectedReference = references[selectedIndex - 1];
                SetScripture(_scriptureLoader.GetScriptureByReference(selectedReference));
            }
            catch
            {
                Console.WriteLine("Unable to find scripture based on your selection.");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }
        }
        else if (selectedOptionKey == "2")
        {
            // Randomly Pick a Scripture
            SetScripture(_scriptureLoader.GetRandomScripture());
        }
    }
    static void SetupMenus()
    {
        _mainMenu = new Menu(
            [
                "CSE 210 - W03 Project - Matt Handy",
                "Scripture Memorizer Program",
                "",
                "MAIN MENU",
                "",
                ""
            ],
            [
                new MenuOption(1, "Change Scripture"),
                new MenuOption(2, "Disappearing Scripture Game (Core Requirement)"),
                new MenuOption(3, "Word Guess Game (Exceeding Expectations)"),
                new MenuOption(4, "Letter Guess Game (Exceeding Expectations)"),
                new MenuOption(),
                new MenuOption('Q', "Quit")
            ]
        );
        _scriptureMenu = new Menu(
            [
                "SCRIPTURE SELECTION"
            ],
            [
                new MenuOption(1, "Select From a List"),
                new MenuOption(2, "Randomly Pick a Scripture"),
                new MenuOption(),
                new MenuOption('C', "Cancel")
            ]
        );
    }
    static void SetupGames()
    {
        _games = new Games();
    }
    static void LoadScriptures()
    {
        _scriptureLoader = new ScriptureLoader();

        // Automatically Pick a Random Scripture
        SetScripture(_scriptureLoader.GetRandomScripture());
    }
    static void SetScripture(Scripture scripture)
    {
        _scripture = scripture;
        _mainMenu.ChangeTitleByIndex(5, "Scripture: " + _scripture.GetReference().GetFullName());
    }
}
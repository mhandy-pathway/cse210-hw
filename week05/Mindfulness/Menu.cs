using System.Runtime.InteropServices;

public class Menu
{
    private List<string> _titles;
    private List<MenuOption> _options;

    // Constructor
    public Menu(List<string> titles, List<MenuOption> options)
    {
        _titles = titles;
        _options = options;
    }

    // Public Interface
    public void ChangeTitleByIndex(int index, string newTitle)
    {
        _titles[index] = newTitle;
    }
    public MenuOption PromptUser()
    {
        string userPrompt = "";
        while (true)
        {
            Console.Clear();
            Display();
            if (userPrompt != "")
            {
                Console.WriteLine();
                Console.WriteLine($"ERROR: The specified option \"{userPrompt}\" is not valid.");
                Console.WriteLine();
            }
            Console.Write("Enter your selection > ");
            userPrompt = Console.ReadLine();
            foreach (MenuOption option in _options)
            {
                if (option.CheckUserPrompt(userPrompt))
                {
                    return option;
                }
            }
        }
    }

    // Private Helper Methods
    private void Display()
    {
        int internalWidth = CalculateMaxWidth();
        int sidePadding = 4; // ("| " + " |")

        // Print Header and Titles
        Console.WriteLine(new string('-', internalWidth + sidePadding));
        foreach (string title in _titles)
        {
            int leftPadding = (internalWidth - title.Length) / 2;
            Console.Write("| ");
            Console.Write(new string(' ', leftPadding));
            Console.Write(title);
            Console.Write(new string(' ', internalWidth - title.Length - leftPadding));
            Console.WriteLine(" |");
        }
        Console.WriteLine(new string('-', internalWidth + sidePadding));

        // Print Options

        foreach (MenuOption option in _options)
        {
            Console.Write("| ");
            Console.Write(option.GetOptionText());
            Console.Write(new string(' ', internalWidth - option.GetOptionText().Length));
            Console.WriteLine(" |");
        }
        Console.WriteLine(new string('-', internalWidth + sidePadding));
    }
    private int CalculateMaxWidth()
    {
        // Get Longest Text between Title and Option Text
        int maxWidth = 0;
        foreach (string title in _titles)
        {
            if (title.Length > maxWidth)
            {
                maxWidth = title.Length;
            }
        }
        foreach (MenuOption option in _options)
        {
            if (option.GetOptionText().Length > maxWidth)
            {
                maxWidth = option.GetOptionText().Length;
            }
        }
        return maxWidth;
    }
}
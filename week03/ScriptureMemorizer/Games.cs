public class Games
{
    public void PlayDisappearingScriptureGame(Scripture scripture)
    {
        Console.Clear();
        scripture.Display();
        while (!scripture.IsCompletelyHidden())
        {
            Console.Write("Press ENTER to continue (or \"quit\" to exit)...");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            {
                return;
            }
            scripture.HideRandom(5);
            Console.Clear();
            scripture.Display();
        }
        scripture.Show();
        Console.WriteLine();
        Console.WriteLine("Congratulations. You finished the game.");
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
    }
    public void PlayWordGame(Scripture scripture)
    {
        scripture.Hide();
        Console.Clear();
        scripture.Display();
        int totalGuesses = 0;
        int correctGuesses = 0;
        while (!scripture.IsCompletelyVisible())
        {
            Console.Write("Enter a Guess (or \"quit\" to exit) > ");
            string wordGuess = Console.ReadLine();
            if (wordGuess.ToLower() == "quit")
            {
                return;
            }
            totalGuesses += 1;
            int previousVisibleWordCount = scripture.GetVisibleWordCount();
            scripture.Show(wordGuess);
            if (previousVisibleWordCount != scripture.GetVisibleWordCount())
            {
                correctGuesses += 1;
            }
            Console.Clear();
            scripture.Display();
        }
        scripture.Show();
        Console.WriteLine();
        Console.WriteLine("Congratulations. You finished the game.");
        Console.WriteLine($"Correct Guesses: {correctGuesses}");
        Console.WriteLine($"Total Guesses: {totalGuesses}");
        Console.WriteLine($"Guess Rate: {(int)((float)correctGuesses / (float)totalGuesses * 100)}%");
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
    }
    public void PlayLetterGame(Scripture scripture)
    {
        scripture.Hide();
        Console.Clear();
        scripture.Display();
        int totalGuesses = 0;
        int correctGuesses = 0;
        while (!scripture.IsCompletelyVisible())
        {
            Console.Write("Enter a Guess (or \"quit\" to exit) > ");
            string wordGuess = Console.ReadLine();
            if (wordGuess.ToLower() == "quit")
            {
                return;
            }
            totalGuesses += 1;
            int previousVisibleLetterCount = scripture.GetVisibleLetterCount();
            char[] charList = wordGuess.ToCharArray();
            if (charList.Count() > 0)
            {
                scripture.Show(charList[0]);
            }
            if (previousVisibleLetterCount != scripture.GetVisibleLetterCount())
            {
                correctGuesses += 1;
            }
            Console.Clear();
            scripture.Display();
        }
        scripture.Show();
        Console.WriteLine();
        Console.WriteLine("Congratulations. You finished the game.");
        Console.WriteLine($"Correct Guesses: {correctGuesses}");
        Console.WriteLine($"Total Guesses: {totalGuesses}");
        Console.WriteLine($"Guess Rate: {(int)((float)correctGuesses / (float)totalGuesses * 100)}%");
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
    }
}
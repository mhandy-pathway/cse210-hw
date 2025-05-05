using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;
        do
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);
            int guess;
            int guessCount = 0;
            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;
                if (guess == magicNumber)
                {
                    Console.WriteLine("You guessed correctly!");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
            } while (magicNumber != guess);
            Console.WriteLine($"You guessed the magic number {magicNumber} in {guessCount} guesses.");
            Console.WriteLine();
            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine();
        } while (playAgain.ToLower() == "yes" || playAgain.ToLower() == "y");
    }
}
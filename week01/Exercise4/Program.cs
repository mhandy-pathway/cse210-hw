using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = 0;
        do
        {
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        int sum = 0;
        int highest = 0;
        int smallestPositive = 0;
        foreach (int this_number in numbers)
        {
            sum += this_number;
            if (this_number > highest)
            {
                highest = this_number;
            }
            if (this_number > 0 && (this_number < smallestPositive || smallestPositive == 0))
            {
                smallestPositive = this_number;
            }
        }
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"Count: {numbers.Count}");
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Highest: {highest}");
        Console.WriteLine($"Smallest Positive: {smallestPositive}");
        Console.WriteLine();
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
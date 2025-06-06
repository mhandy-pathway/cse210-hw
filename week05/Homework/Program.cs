using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Matt Handy", "Regular Assignment");
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment assignment2 = new MathAssignment("Matt Handy", "Fractions", "7.3", "8-19");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());

        WritingAssignment assignment3 = new WritingAssignment("Matt Handy", "European History", "The Causes of World War II");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}
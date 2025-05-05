using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string strGradePct = Console.ReadLine();
        int intGradePct = int.Parse(strGradePct);
        string strGradeLetter;
        if (intGradePct >= 90)
        {
            strGradeLetter = "A";
        }
        else if (intGradePct >= 80)
        {
            strGradeLetter = "B";
        }
        else if (intGradePct >= 70)
        {
            strGradeLetter = "C";
        }
        else if (intGradePct >= 60)
        {
            strGradeLetter = "D";
        }
        else
        {
            strGradeLetter = "F";
        }
        string strGradeSign = "";
        int intRemainder = intGradePct % 10;
        if (intRemainder >= 7 && strGradeLetter != "A" && strGradeLetter != "F")
        {
            strGradeSign = "+";
        }
        else if (intRemainder < 3 && strGradeLetter != "F")
        {
            strGradeSign = "-";
        }
        Console.WriteLine($"Your letter grade is: {strGradeLetter}{strGradeSign}");
        if (intGradePct >= 70)
        {
            Console.WriteLine("Congratulations! You have passed the class!");
        }
        else
        {
            Console.WriteLine("I'm sorry. You did not pass the class. Please don't give up. You can take the course again. YOU CAN DO THIS!!!");
        }
    }
}
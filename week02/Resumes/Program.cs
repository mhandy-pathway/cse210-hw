using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Apple";
        job1._startYear = 2021;
        job1._endYear = 2023;
        // job1.Display();

        Job job2 = new Job();
        job2._jobTitle = "Application Developer";
        job2._company = "Microsoft";
        job2._startYear = 2023;
        job2._endYear = 2025;
        // job2.Display();

        Resume resume = new Resume();
        resume._name = "Matt Handy";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}
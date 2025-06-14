using System;

class Program
{
    static List<Activity> _activityList = new List<Activity>();
    static void Main(string[] args)
    {
        PopulateActivityList();
        foreach (Activity activity in _activityList)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
    static void PopulateActivityList()
    {
        _activityList.Add(new CyclingActivity(new DateTime(2025, 6, 1), 45, 22.5));
        _activityList.Add(new SwimmingActivity(new DateTime(2025, 6, 2), 30, 39));
        _activityList.Add(new RunningActivity(new DateTime(2025, 6, 3), 30, 4.5));
        _activityList.Add(new CyclingActivity(new DateTime(2025, 6, 4), 60, 20));
        _activityList.Add(new SwimmingActivity(new DateTime(2025, 6, 5), 45, 62));
        _activityList.Add(new RunningActivity(new DateTime(2025, 6, 6), 37, 5.1));
        _activityList.Add(new CyclingActivity(new DateTime(2025, 6, 7), 30, 24.2));
        _activityList.Add(new SwimmingActivity(new DateTime(2025, 6, 8), 60, 75));
        _activityList.Add(new RunningActivity(new DateTime(2025, 6, 9), 63, 7.2));
        _activityList.Add(new CyclingActivity(new DateTime(2025, 6, 10), 40, 23.75));
        _activityList.Add(new SwimmingActivity(new DateTime(2025, 6, 11), 35, 48));
        _activityList.Add(new RunningActivity(new DateTime(2025, 6, 12), 51, 6.8));
    }
}
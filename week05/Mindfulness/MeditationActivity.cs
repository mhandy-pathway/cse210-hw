public class MeditationActivity : Activity
{
    private int _selectedHymnIndex;
    private List<Hymn> _hymnList;

    public MeditationActivity() : base("Meditation Activity", "In this activity you will find balance by closing your eyes and meditating for a period of time. At the end of the time a sound, or hymn if you are on a Windows device, will be played.")
    {
        PopulateHymnList();
    }

    public void Run()
    {
        StartActivity();
        if (OperatingSystem.IsWindows())
        {
            PromptForHymn();
        }
        ShowCountdown(5, "Prepare to start meditating... ");
        if (OperatingSystem.IsWindows())
        {
            ShowCountdown(GetDuration(), "Close your eyes and meditate. Try to clear your mind. You will hear a hymn when the timer runs out... ");
            _hymnList[_selectedHymnIndex].Play();
        }
        else
        {
            ShowCountdown(GetDuration(), "Close your eyes and meditate. You will hear a beep when the timer runs out... ");
            Console.Beep();
        }
        EndActivity();
    }
    private void PromptForHymn()
    {
        bool selectedHymn = false;
        while (!selectedHymn)
        {
            Console.WriteLine("What Hymn would you like to play when the activity is done?");
            int i = 1;
            foreach (Hymn hymn in _hymnList)
            {
                Console.WriteLine($"{i}. {hymn.GetName()}");
                i++;
            }
            Console.Write(" --> ");
            try
            {
                _selectedHymnIndex = int.Parse(Console.ReadLine()) - 1;
                if (_selectedHymnIndex >= 0 && _selectedHymnIndex < _hymnList.Count)
                {
                    selectedHymn = true;
                }
                else
                {
                    Console.WriteLine("ERROR: Please specify one of the numbers in the list.\n");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR: Please specify a number.\n");
            }

        }
    }
    private void PopulateHymnList()
    {
        Dictionary<string, int> noteLengths = Hymn.GetNoteLengthDictionary();
        Dictionary<string, int> notes = Hymn.GetNoteDictionary();
        _hymnList = new List<Hymn>([
            new Hymn("I am a Child of God (#301)", 1.0f, [
                new Note(notes["F#4"], noteLengths["quarterNote"]),
                new Note(notes["F#4"], noteLengths["eighthNote"]),
                new Note(notes["F#4"], noteLengths["eighthNote"]),
                new Note(notes["G4"], noteLengths["quarterNote"]),
                new Note(notes["A4"], noteLengths["quarterNote"]),
                new Note(notes["F#4"], noteLengths["quarterNote"] + noteLengths["halfNote"]),
                new Note(notes["A4"], noteLengths["quarterNote"]),
                new Note(notes["D5"], noteLengths["quarterNote"] + noteLengths["eighthNote"]),
                new Note(notes["D5"], noteLengths["eighthNote"]),
                new Note(notes["C#5"], noteLengths["quarterNote"]),
                new Note(notes["B4"], noteLengths["quarterNote"]),
                new Note(notes["A4"], noteLengths["quarterNote"] + noteLengths["halfNote"]),
            ]),
            new Hymn("I Will Walk with Jesus (#1004)", 1.0f, [
                new Note(notes["D5"], noteLengths["eighthNote"]),
                new Note(notes["C5"], noteLengths["eighthNote"]),
                new Note(notes["A#4"], noteLengths["eighthNote"]),
                new Note(notes["F4"], noteLengths["eighthNote"]),
                new Note(notes["D#4"], noteLengths["eighthNote"]),
                new Note(notes["A#4"], noteLengths["quarterNote"] + noteLengths["eighthNote"]),
                new Note(notes["C5"], noteLengths["eighthNote"]),
                new Note(notes["A#4"], noteLengths["eighthNote"]),
                new Note(notes["A4"], noteLengths["eighthNote"]),
                new Note(notes["F4"], noteLengths["eighthNote"]),
                new Note(notes["D4"], noteLengths["quarterNote"]),
                new Note(notes["G4"], noteLengths["eighthNote"]),
                new Note(notes["A4"], noteLengths["eighthNote"]),
                new Note(notes["A#4"], noteLengths["eighthNote"]),
                new Note(notes["A4"], noteLengths["eighthNote"]),
                new Note(notes["G4"], noteLengths["eighthNote"]),
                new Note(notes["D4"], noteLengths["eighthNote"]),
                new Note(notes["D#4"], noteLengths["eighthNote"]),
                new Note(notes["A#4"], noteLengths["quarterNote"]),
                new Note(notes["A#4"], noteLengths["eighthNote"]),
                new Note(notes["A#4"], noteLengths["eighthNote"]),
                new Note(notes["A4"], noteLengths["eighthNote"]),
                new Note(notes["G4"], noteLengths["eighthNote"]),
                new Note(notes["F4"], noteLengths["eighthNote"]),
                new Note(notes["F4"], noteLengths["halfNote"]),
            ]),
            new Hymn("Come, Thou Fount of Every Blessing (#1001)", 1.2f, [
                new Note(notes["F#4"], noteLengths["eighthNote"]),
                new Note(notes["E4"], noteLengths["eighthNote"]),
                new Note(notes["D4"], noteLengths["quarterNote"]),
                new Note(notes["D4"], noteLengths["quarterNote"]),
                new Note(notes["F#4"], noteLengths["eighthNote"]),
                new Note(notes["A4"], noteLengths["eighthNote"]),
                new Note(notes["E4"], noteLengths["quarterNote"]),
                new Note(notes["E4"], noteLengths["quarterNote"]),
                new Note(notes["F#4"], noteLengths["eighthNote"]),
                new Note(notes["A4"], noteLengths["eighthNote"]),
                new Note(notes["B4"], noteLengths["quarterNote"]),
                new Note(notes["A4"], noteLengths["quarterNote"]),
                new Note(notes["F#4"], noteLengths["eighthNote"]),
                new Note(notes["E4"], noteLengths["eighthNote"]),
                new Note(notes["D4"], noteLengths["halfNote"]),
            ]),
            new Hymn("Gethsemane (#1009)", 1.0f, [
                new Note(notes["F4"], noteLengths["quarterNote"] + noteLengths["eighthNote"]),
                new Note(notes["G4"], noteLengths["quarterNote"]),
                new Note(notes["A4"], noteLengths["eighthNote"]),
                new Note(notes["A4"], noteLengths["quarterNote"] + noteLengths["halfNote"]),
                new Note(notes["F4"], noteLengths["quarterNote"] + noteLengths["eighthNote"]),
                new Note(notes["G4"], noteLengths["quarterNote"]),
                new Note(notes["C5"], noteLengths["eighthNote"]),
                new Note(notes["C5"], noteLengths["eighthNote"]),
                new Note(notes["A4"], noteLengths["quarterNote"] + noteLengths["eighthNote"]),
                new Note(notes["G4"], noteLengths["eighthNote"]),
                new Note(notes["A4"], noteLengths["eighthNote"]),
                new Note(notes["A#4"], noteLengths["quarterNote"] + noteLengths["eighthNote"]),
                new Note(notes["A4"], noteLengths["quarterNote"]),
                new Note(notes["F4"], noteLengths["eighthNote"]),
                new Note(notes["G4"], noteLengths["halfNote"] + noteLengths["quarterNote"]),
                new Note(notes["F4"], noteLengths["quarterNote"]),
                new Note(notes["F4"], noteLengths["eighthNote"]),
                new Note(notes["E4"], noteLengths["quarterNote"]),
                new Note(notes["C4"], noteLengths["eighthNote"]),
                new Note(notes["D4"], noteLengths["halfNote"] + noteLengths["quarterNote"]),
            ]),
            new Hymn("This Is the Christ (#1017)", 1.5f, [
                new Note(notes["A4"], noteLengths["eighthNote"]),
                new Note(notes["A4"], noteLengths["eighthNote"] + noteLengths["sixteenthNote"]),
                new Note(notes["G4"], noteLengths["sixteenthNote"]),
                new Note(notes["A4"], noteLengths["quarterNote"] + noteLengths["eighthNote"]),
                new Note(notes["A4"], noteLengths["eighthNote"]),
                new Note(notes["D5"], noteLengths["eighthNote"]),
                new Note(notes["G4"], noteLengths["eighthNote"]),
                new Note(notes["G4"], noteLengths["eighthNote"] + noteLengths["sixteenthNote"]),
                new Note(notes["A4"], noteLengths["sixteenthNote"]),
                new Note(notes["A#4"], noteLengths["halfNote"] + noteLengths["quarterNote"]),
                new Note(notes["A4"], noteLengths["eighthNote"]),
                new Note(notes["G4"], noteLengths["eighthNote"]),
                new Note(notes["C5"], noteLengths["eighthNote"] + noteLengths["sixteenthNote"]),
                new Note(notes["C4"], noteLengths["sixteenthNote"]),
                new Note(notes["C4"], noteLengths["quarterNote"] + noteLengths["eighthNote"]),
                new Note(notes["C4"], noteLengths["eighthNote"]),
                new Note(notes["D4"], noteLengths["eighthNote"]),
                new Note(notes["F4"], noteLengths["eighthNote"]),
                new Note(notes["F4"], noteLengths["halfNote"] + noteLengths["quarterNote"]),
            ]),
            new Hymn("Christ the Lord Is Risen Today (#200)", 0.90f, [
                new Note(notes["C4"], noteLengths["quarterNote"]),
                new Note(notes["E4"], noteLengths["quarterNote"]),
                new Note(notes["G4"], noteLengths["quarterNote"]),
                new Note(notes["C4"], noteLengths["quarterNote"]),
                new Note(notes["F4"], noteLengths["quarterNote"]),
                new Note(notes["A4"], noteLengths["quarterNote"]),
                new Note(notes["A4"], noteLengths["quarterNote"]),
                new Note(notes["G4"], noteLengths["quarterNote"]),
                new Note(notes["E4"], noteLengths["eighthNote"]),
                new Note(notes["F4"], noteLengths["eighthNote"]),
                new Note(notes["G4"], noteLengths["eighthNote"]),
                new Note(notes["C4"], noteLengths["eighthNote"]),
                new Note(notes["F4"], noteLengths["quarterNote"]),
                new Note(notes["E4"], noteLengths["eighthNote"]),
                new Note(notes["F4"], noteLengths["eighthNote"]),
                new Note(notes["E4"], noteLengths["quarterNote"]),
                new Note(notes["D4"], noteLengths["quarterNote"]),
                new Note(notes["C4"], noteLengths["halfNote"]),
            ]),
        ]);
    }
}
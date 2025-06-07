public class Hymn
{
    private string _name;
    private float _speed;
    private List<Note> _noteList;

    private static Dictionary<string, int> _noteLengths = new Dictionary<string, int>()
    {
        { "halfNote", 1000 },
        { "quarterNote", 500 },
        { "eighthNote", 250 },
        { "sixteenthNote", 125 },
    };
    private static Dictionary<string, int> _notes = new Dictionary<string, int>()
    {
        { "C4", 262 },
        { "C#4", 277 },
        { "D4", 294 },
        { "D#4", 311 },
        { "E4", 330 },
        { "F4", 349 },
        { "F#4", 370 },
        { "G4", 392 },
        { "G#4", 415 },
        { "A4", 440 },
        { "A#4", 466 },
        { "B4", 494 },
        { "C5", 523 },
        { "C#5", 554 },
        { "D5", 587 },
        { "D#5", 622 },
        { "E5", 659 },
        { "F5", 698 },
        { "F#5", 740 },
        { "G5", 784 },
        { "G#5", 831 },
        { "A5", 880 },
        { "A#5", 932 },
        { "B5", 988 },
    };
    public Hymn(string name, float speed, List<Note> noteList)
    {
        _name = name;
        _speed = speed;
        _noteList = noteList;
    }

    public string GetName()
    {
        return _name;
    }
    public static Dictionary<string, int> GetNoteLengthDictionary()
    {
        return _noteLengths;
    }
    public static Dictionary<string, int> GetNoteDictionary()
    {
        return _notes;
    }
    public void Play()
    {
        if (OperatingSystem.IsWindows())
        {
            foreach (Note note in _noteList)
            {
                Console.Beep(note.GetFrequency(), (int)Math.Round((double)(note.GetDuration() * _speed)));
            }
        }
        else
        {
            Console.Beep();
            Console.Beep();
            Console.Beep();
        }
    }
}
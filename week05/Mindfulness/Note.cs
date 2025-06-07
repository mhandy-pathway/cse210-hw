public class Note
{
    private int _frequency;
    private int _duration;

    public Note(int frequency, int duration)
    {
        _frequency = frequency;
        _duration = duration;
    }
    public int GetFrequency()
    {
        return _frequency;
    }
    public int GetDuration()
    {
        return _duration;
    }
}
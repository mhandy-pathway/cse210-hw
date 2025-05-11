public class Entry
{
    public DateTime _date { get; set; }
    public string _prompt { get; set; }
    public string _answer { get; set; }
    public Entry(string prompt, string answer)
    {
        _date = DateTime.Now;
        _prompt = prompt;
        _answer = answer;
    }
    // Parameterless constructor for deserialization
    public Entry()
    {

    }
    public void Display()
    {
        Console.WriteLine($"DATE: {_date.ToShortDateString()} {_date.ToShortTimeString()}, PROMPT: {_prompt}");
        Console.WriteLine(_answer);
    }
}
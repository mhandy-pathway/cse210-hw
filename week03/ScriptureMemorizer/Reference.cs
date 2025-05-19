using System.ComponentModel.DataAnnotations;

public class Reference
{
    // Member Attributes
    private string _book;
    private int _chapter;
    private int _fromVerse;
    private int _toVerse;

    // Constructors
    public Reference()
    {

    }
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _fromVerse = verse;
        _toVerse = verse;
    }
    public Reference(string book, int chapter, int fromVerse, int toVerse)
    {
        _book = book;
        _chapter = chapter;
        _fromVerse = fromVerse;
        _toVerse = toVerse;
    }

    // Display Method
    public void Display()
    {
        Console.WriteLine(GetFullName());
    }

    // Generate Name Method
    public string GetFullName()
    {
        if (_fromVerse == _toVerse)
        {
            return $"{_book} {_chapter}:{_fromVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_fromVerse}-{_toVerse}";
        }

    }
}
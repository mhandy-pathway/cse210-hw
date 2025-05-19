using System.Text.RegularExpressions;
public class Word
{
    // Member Attributes
    private List<Letter> _letters = new List<Letter>();
    private string _wordString = "";
    private bool _isHidden = false;

    // Constructors
    public Word(string wordString)
    {
        _wordString = Regex.Replace(wordString, "[^A-Za-z0-9]", "");
        char[] characters = wordString.ToCharArray();
        for (int i = 0; i < characters.Count(); i++)
        {
            _letters.Add(new Letter(characters[i]));
        }
    }

    // Helper Methods
    private void CalculateIsHidden()
    {
        bool isHidden = false;
        for (int i = 0; i < _letters.Count(); i++)
        {
            if (_letters[i].IsHidden())
            {
                isHidden = true;
            }
        }
        _isHidden = isHidden;
    }

    // Public Interface Methods
    public void Display()
    {
        for (int i = 0; i < _letters.Count(); i++)
        {
            _letters[i].Display();
        }
    }
    public void Show()
    {
        _isHidden = false;
        for (int i = 0; i < _letters.Count(); i++)
        {
            _letters[i].Show();
        }
    }
    public void Show(string wordString)
    {
        if (_isHidden && _wordString.ToLower() == wordString.ToLower())
        {
            Show();
        }
    }
    public void Show(char letterString)
    {
        for (int i = 0; i < _letters.Count(); i++)
        {
            _letters[i].Show(letterString);
        }
        CalculateIsHidden();
    }
    public void Hide()
    {
        _isHidden = true;
        for (int i = 0; i < _letters.Count(); i++)
        {
            _letters[i].Hide();
        }
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public int GetVisibleLetterCount()
    {
        int visibleLetterCount = 0;
        foreach (Letter letter in _letters)
        {
            if (!letter.IsHidden())
            {
                visibleLetterCount += 1;
            }
        }
        return visibleLetterCount;
    }
}
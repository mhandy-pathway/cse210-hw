using System.Text.RegularExpressions;
public class Letter
{
    // Member Attributes
    private char _character;
    private bool _isLetterOrNumber = false;
    private bool _isHidden = false;

    // Constructor
    public Letter(char character)
    {
        _character = character;
        if (Regex.IsMatch(character.ToString(), "[A-Za-z0-9]"))
        {
            _isLetterOrNumber = true;
        }
    }

    // Public Interface Methods
    public void Display()
    {
        if (IsHidden())
        {
            Console.Write("_");
        }
        else
        {
            Console.Write(_character);
        }
    }
    public void Show()
    {
        _isHidden = false;
    }
    public void Show(char letter)
    {
        if (_character.ToString().ToLower() == letter.ToString().ToLower())
        {
            Show();
        }
    }
    public void Hide()
    {
        _isHidden = true;
    }
    public bool IsHidden()
    {
        if (_isLetterOrNumber && _isHidden)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
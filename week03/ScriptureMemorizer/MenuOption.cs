using System.ComponentModel.DataAnnotations;

public class MenuOption
{
    private int _number;
    private char _character;
    private string _text;
    private int _type;
    private const int TYPE_NUMBER = 1;
    private const int TYPE_CHAR = 2;
    private const int TYPE_BLANK = 3;

    // Constructors
    public MenuOption()
    {
        _type = TYPE_BLANK;
    }
    public MenuOption(int number, string text)
    {
        _number = number;
        _text = text;
        _type = TYPE_NUMBER;
    }
    public MenuOption(char character, string text)
    {
        _character = character;
        _text = text;
        _type = TYPE_CHAR;
    }

    // Public Interface Methods
    public string GetOptionKey()
    {
        if (_type == TYPE_NUMBER)
        {
            return _number.ToString();
        }
        else if (_type == TYPE_CHAR)
        {
            return _character.ToString();
        }
        else if (_type == TYPE_BLANK)
        {
            return "";
        }
        throw new Exception($"Invalid menu option type \"{_type}\".");
    }
    public string GetOptionText()
    {
        if (_type == TYPE_NUMBER)
        {
            return $"{_number}. {_text}";
        }
        else if (_type == TYPE_CHAR)
        {
            return $"{_character}. {_text}";
        }
        else if (_type == TYPE_BLANK)
        {
            return "";
        }
        throw new Exception($"Invalid menu option type \"{_type}\".");
    }
    public bool CheckUserPrompt(string userPrompt)
    {
        if (_type == TYPE_NUMBER)
        {
            try
            {
                return int.Parse(userPrompt) == _number;
            }
            catch
            {
                return false;
            }
        }
        else if (_type == TYPE_CHAR)
        {
            return userPrompt.ToLower() == _character.ToString().ToLower();
        }
        else if (_type == TYPE_BLANK)
        {
            return false;
        }
        throw new Exception($"Invalid menu option type \"{_type}\".");
    }
}
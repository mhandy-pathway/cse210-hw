using System.Text.RegularExpressions;
public class Verse
{
    private int _number;
    private List<Word> _words = new List<Word>();

    // Constructors
    public Verse(int number, string verseString)
    {
        _number = number;
        AddWords(verseString);
    }
    public Verse(int number, List<Word> wordList)
    {
        _number = number;
        AddWords(wordList);
    }

    // Private Helper Methods
    private void AddWords(string verseString)
    {
        string[] wordList = Regex.Split(verseString, "\\s+");
        for (int i = 0; i < wordList.Count(); i++)
        {
            _words.Add(new Word(wordList[i]));
        }
    }
    private void AddWords(List<Word> wordList)
    {
        _words = wordList;
    }
    private List<int> GetVisibleWordIndexList()
    {
        List<int> indexList = new List<int>();
        for (int i = 0; i < _words.Count(); i++)
        {
            if (!_words[i].IsHidden())
            {
                indexList.Add(i);
            }
        }
        return indexList;
    }

    // Public Interface Methods
    public void Display()
    {
        Console.Write(_number);
        for (int i = 0; i < _words.Count(); i++)
        {
            Console.Write(" ");
            _words[i].Display();
        }
    }
    public void Show()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
    }
    public void Show(string wordString)
    {
        foreach (Word word in _words)
        {
            word.Show(wordString);
        }
    }
    public void Show(char letter)
    {
        foreach (Word word in _words)
        {
            word.Show(letter);
        }
    }
    public void Hide()
    {
        foreach (Word word in _words)
        {
            word.Hide();
        }
    }
    public void HideRandom(int numberToHide)
    {
        List<int> indexList = GetVisibleWordIndexList();
        Random random = new Random();
        IEnumerable<int> indexListToHide = indexList.OrderBy(x => random.Next()).Take(numberToHide);
        foreach (int index in indexListToHide)
        {
            _words[index].Hide();
        }
    }
    public bool IsCompletelyVisible()
    {
        bool isVisible = true;
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                isVisible = false;
            }
        }
        return isVisible;
    }
    public bool IsCompletelyHidden()
    {
        bool isHidden = true;
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                isHidden = false;
            }
        }
        return isHidden;
    }
    public int GetVisibleWordCount()
    {
        int visibleWordCount = 0;
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWordCount += 1;
            }
        }
        return visibleWordCount;
    }
    public int GetVisibleLetterCount()
    {
        int visibleLetterCount = 0;
        foreach (Word word in _words)
        {
            visibleLetterCount += word.GetVisibleLetterCount();
        }
        return visibleLetterCount;
    }
}
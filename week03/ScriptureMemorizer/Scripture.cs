using System.ComponentModel.DataAnnotations;

public class Scripture
{
    private Reference _reference;
    private List<Verse> _verses = new List<Verse>();

    // Constructors
    public Scripture(Reference reference, List<Verse> verseList)
    {
        _reference = reference;
        _verses = verseList;
    }

    // Public Interface Methods
    public Reference GetReference()
    {
        return _reference;
    }
    public void Display()
    {
        _reference.Display();
        for (int i = 0; i < _verses.Count(); i++)
        {
            _verses[i].Display();
            Console.WriteLine();
        }
    }
    public void Show()
    {
        foreach (Verse verse in _verses)
        {
            verse.Show();
        }
    }
    public void Show(string wordString)
    {
        foreach (Verse verse in _verses)
        {
            verse.Show(wordString);
        }
    }
    public void Show(char letter)
    {
        foreach (Verse verse in _verses)
        {
            verse.Show(letter);
        }
    }
    public void Hide()
    {
        foreach (Verse verse in _verses)
        {
            verse.Hide();
        }
    }
    public void HideRandom(int numberToHide)
    {
        foreach (Verse verse in _verses)
        {
            verse.HideRandom(numberToHide);
        }
    }
    public bool IsCompletelyVisible()
    {
        bool isVisible = true;
        foreach (Verse verse in _verses)
        {
            if (!verse.IsCompletelyVisible())
            {
                isVisible = false;
            }
        }
        return isVisible;
    }
    public bool IsCompletelyHidden()
    {
        bool isHidden = true;
        foreach (Verse verse in _verses)
        {
            if (!verse.IsCompletelyHidden())
            {
                isHidden = false;
            }
        }
        return isHidden;
    }
    public int GetVisibleWordCount()
    {
        int visibleWordCount = 0;
        foreach (Verse verse in _verses)
        {
            visibleWordCount += verse.GetVisibleWordCount();
        }
        return visibleWordCount;
    }
    public int GetVisibleLetterCount()
    {
        int visibleLetterCount = 0;
        foreach (Verse verse in _verses)
        {
            visibleLetterCount += verse.GetVisibleLetterCount();
        }
        return visibleLetterCount;
    }
}
public class Level
{
    private int _minimumScore;
    private string _name;
    public Level(string name, int minimumScore)
    {
        _name = name;
        _minimumScore = minimumScore;
    }
    public bool DoesScoreQualify(int score)
    {
        return (score >= _minimumScore);
    }
    public string GetName()
    {
        return _name;
    }
    public string GetCongratulationsString()
    {
        return $"CONGRATULATIONS! You have achieved the \"{GetName()}\" Level!";
    }
}
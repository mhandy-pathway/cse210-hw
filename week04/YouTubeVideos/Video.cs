public class Video
{
    private string _title;
    private string _author;
    private int _videoLength;
    private List<Comment> _commentList = new List<Comment>();

    // Constructor
    public Video(string title, string author, int videoLength, List<Comment> commentList)
    {
        _title = title;
        _author = author;
        _videoLength = videoLength;
        _commentList = commentList;
    }

    // Public Interface Methods
    public void AddComment(Comment comment)
    {
        _commentList.Add(comment);
    }
    public int GetCommentCount()
    {
        return _commentList.Count();
    }
    public string GetDisplayString()
    {
        string returnStr;
        returnStr = $"Title: {_title}\n";
        returnStr += $"Author: {_author}\n";
        returnStr += $"Video Length: {GetVideoLengthString()}\n";
        returnStr += $"# of Comments: {GetCommentCount()}\n";
        returnStr += $"Comments:\n";
        foreach (Comment comment in _commentList)
        {
            returnStr += $"\n{comment.GetDisplayString()}\n";
        }
        return returnStr;
    }

    // Private Helper Methods
    private string GetVideoLengthString()
    {
        double minutes = Math.Floor((double)_videoLength / 60);
        double seconds = _videoLength - (minutes * 60);
        string returnStr = "";
        if (minutes > 0)
        {
            returnStr += $"{minutes} minutes ";
        }
        returnStr += $"{seconds} seconds";
        return returnStr;
    }
}
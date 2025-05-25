using System;

class Program
{
    private static List<Video> _videoList = new List<Video>();
    static void Main(string[] args)
    {
        SetupVideos();
        for (int i = 0; i < _videoList.Count(); i++)
        {
            if (i > 0)
            {
                Console.WriteLine("---------------------------------------");
            }
            Console.WriteLine(_videoList[i].GetDisplayString());
        }
    }
    static void SetupVideos()
    {
        _videoList.Add(
            new Video(
                "Evidences of the Book of Mormon in Mesoamerica.",
                "The Angel Moroni",
                986,
                [
                    new Comment("Alma", "I love this so much! Thank you for putting this video together."),
                    new Comment("Laman", "I wish that I had stayed in Jerusalem :("),
                    new Comment("John Doe", "I prayed about the Book of Mormon and feel it is true. How can I contact the missionaries."),
                    new Comment("Dieter Uchtdorf", "This video reminded me of all the flights that I piloted over Mexico."),
                ]
            )
        );
        _videoList.Add(
            new Video(
                "The Symbolism of Death and Rebirth in the Baptismal Ordinance",
                "John the Baptist",
                514,
                [
                    new Comment("Korihor", "What I don't understand is... why should I get baptized if there will be no Christ."),
                    new Comment("Alma", "Of course there will be a Christ. Have faith, brother! You shouldn't ask for a sign... it will not end well."),
                    new Comment("Nephi", "Sign me up! As long as it is not in a river of filthy water."),
                    new Comment("Parley P. Pratt", "Getting baptized was the easiest decision of my life. I have never felt better."),
                ]
            )
        );
        _videoList.Add(
            new Video(
                "The Mayan Ball Game - Physical Torture or Spiritual Training?",
                "The Three Nephites",
                277,
                [
                    new Comment("Brigham Young", "I always knew there was spiritual significance in that ball game!"),
                    new Comment("Wilford Woodruff", "Brother Brigham, have you been to the ball court at Chichen Itza? It is amazing!"),
                    new Comment("Matt Handy", "So, you are saying that the Mayans were not necesarrily a bloodthirty civilization?!!"),
                    new Comment("King Benjamin", "Matt, no we were not! We lived to serve each other, and in so doing, serve our God."),
                ]
            )
        );
        _videoList.Add(
            new Video(
                "How to Create Golden Plates - Full fabrication and explanation video",
                "Nephi",
                1429,
                [
                    new Comment("Mormon", "Nephi, I wanted to say THANK YOU! I need to craft some more plates, and your detailed video saved by thousands of hours of research."),
                    new Comment("Lemuel", "That seems like a lot of work! Why don't you just write on paper?"),
                    new Comment("Neal A. Maxwell", "I thouroughly enjoyed the level of detail used in this video."),
                    new Comment("GenZYSA2009", "Thanks for all the details. This was very interesting, but I prefer to just use the Gospel Library app."),
                ]
            )
        );
    }
}
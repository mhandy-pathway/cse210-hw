public class ScriptureLoader
{
    // Member Attributes
    private List<Scripture> _scriptureList = new List<Scripture>();

    // Constructor
    public ScriptureLoader()
    {
        LoadScriptures();
    }

    // Public Interace Methods
    public List<Reference> GetReferenceList()
    {
        List<Reference> references = new List<Reference>();
        foreach (Scripture scripture in _scriptureList)
        {
            references.Add(scripture.GetReference());
        }
        return references;
    }
    public Scripture GetScriptureByReference(Reference reference)
    {
        foreach (Scripture scripture in _scriptureList)
        {
            if (scripture.GetReference() == reference)
            {
                return scripture;
            }
        }
        throw new Exception($"Unable to find Scripture by Reference: {reference.GetFullName()}.");
    }
    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(_scriptureList.Count());
        return _scriptureList[index];
    }

    // Internal Helper Methods
    private void LoadScriptures()
    {
        _scriptureList.Add(
            new Scripture(
                new Reference("1 Nephi", 3, 7),
                [
                    new Verse(7, "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("1 Nephi", 19, 23),
                [
                    new Verse(23, "And I did read many things unto them which were written in the books of Moses; but that I might more fully persuade them to believe in the Lord their Redeemer I did read unto them that which was written by the prophet Isaiah; for I did liken all scriptures unto us, that it might be for our profit and learning.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("2 Nephi", 2, 25),
                [
                    new Verse(25, "Adam fell that men might be; and men are, that they might have joy.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("2 Nephi", 2, 27),
                [
                    new Verse(27, "Wherefore, men are free according to the flesh; and all things are given them which are expedient unto man. And they are free to choose liberty and eternal life, through the great Mediator of all men, or to choose captivity and death, according to the captivity and power of the devil; for he seeketh that all men might be miserable like unto himself.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("2 Nephi", 9, 28, 29),
                [
                    new Verse(28, "O that cunning plan of the evil one! O the vainness, and the frailties, and the foolishness of men! When they are learned they think they are wise, and they hearken not unto the counsel of God, for they set it aside, supposing they know of themselves, wherefore, their wisdom is foolishness and it profiteth them not. And they shall perish."),
                    new Verse(29, "But to be learned is good if they hearken unto the counsels of God."),
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("2 Nephi", 28, 7, 9),
                [
                    new Verse(7, "Yea, and there shall be many which shall say: Eat, drink, and be merry, for tomorrow we die; and it shall be well with us."),
                    new Verse(8, "And there shall also be many which shall say: Eat, drink, and be merry; nevertheless, fear God—he will justify in committing a little sin; yea, lie a little, take the advantage of one because of his words, dig a pit for thy neighbor; there is no harm in this; and do all these things, for tomorrow we die; and if it so be that we are guilty, God will beat us with a few stripes, and at last we shall be saved in the kingdom of God."),
                    new Verse(9, "Yea, and there shall be many which shall teach after this manner, false and vain and foolish doctrines, and shall be puffed up in their hearts, and shall seek deep to hide their counsels from the Lord; and their works shall be in the dark.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("2 Nephi", 32, 3),
                [
                    new Verse(3, "Angels speak by the power of the Holy Ghost; wherefore, they speak the words of Christ. Wherefore, I said unto you, feast upon the words of Christ; for behold, the words of Christ will tell you all things what ye should do.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("2 Nephi", 32, 8, 9),
                [
                    new Verse(8, "And now, my beloved brethren, I perceive that ye ponder still in your hearts; and it grieveth me that I must speak concerning this thing. For if ye would hearken unto the Spirit which teacheth a man to pray, ye would know that ye must pray; for the evil spirit teacheth not a man to pray, but teacheth him that he must not pray."),
                    new Verse(9, "But behold, I say unto you that ye must pray always, and not faint; that ye must not perform any thing unto the Lord save in the first place ye shall pray unto the Father in the name of Christ, that he will consecrate thy performance unto thee, that thy performance may be for the welfare of thy soul.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("Mosiah", 2, 17),
                [
                    new Verse(17, "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("Mosiah", 3, 19),
                [
                    new Verse(19, "For the natural man is an enemy to God, and has been from the fall of Adam, and will be, forever and ever, unless he yields to the enticings of the Holy Spirit, and putteth off the natural man and becometh a saint through the atonement of Christ the Lord, and becometh as a child, submissive, meek, humble, patient, full of love, willing to submit to all things which the Lord seeth fit to inflict upon him, even as a child doth submit to his father.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("Mosiah", 4, 30),
                [
                    new Verse(30, "But this much I can tell you, that if ye do not watch yourselves, and your thoughts, and your words, and your deeds, and observe the commandments of God, and continue in the faith of what ye have heard concerning the coming of our Lord, even unto the end of your lives, ye must perish. And now, O man, remember, and perish not.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("Alma", 32, 21),
                [
                    new Verse(21, "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("Alma", 37, 35),
                [
                    new Verse(35, "O, remember, my son, and learn wisdom in thy youth; yea, learn in thy youth to keep the commandments of God.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("Alma", 41, 10),
                [
                    new Verse(10, "Do not suppose, because it has been spoken concerning restoration, that ye shall be restored from sin to happiness. Behold, I say unto you, wickedness never was happiness.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("Helaman", 5, 12),
                [
                    new Verse(12, "And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation; that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty storm shall beat upon you, it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("3 Nephi", 12, 48),
                [
                    new Verse(48, "Therefore I would that ye should be perfect even as I, or your Father who is in heaven is perfect.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("Ether", 12, 6),
                [
                    new Verse(6, "And now, I, Moroni, would speak somewhat concerning these things; I would show unto the world that faith is things which are hoped for and not seen; wherefore, dispute not because ye see not, for ye receive no witness until after the trial of your faith.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("Ether", 12, 27),
                [
                    new Verse(27, "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("Moroni", 7, 45),
                [
                    new Verse(45, "And charity suffereth long, and is kind, and envieth not, and is not puffed up, seeketh not her own, is not easily provoked, thinketh no evil, and rejoiceth not in iniquity but rejoiceth in the truth, beareth all things, believeth all things, hopeth all things, endureth all things.")
                ]
            )
        );
        _scriptureList.Add(
            new Scripture(
                new Reference("Moroni", 10, 4, 5),
                [
                    new Verse(4, "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost."),
                    new Verse(5, "And by the power of the Holy Ghost ye may know the truth of all things."),
                ]
            )
        );
    }
}
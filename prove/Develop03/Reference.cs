class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _startVerse;
    private int _endVerse;



    public Reference(string book, int chapter, int verse)
    {
        this._book = book;
        this._chapter = chapter;
        this._verse = verse;
    }


    public Reference(string book, int chapter, int verse, int startVerse, int endVerse)
    {
        this._book = book;
        this._chapter = chapter;
        this._verse = verse;
        this._startVerse = startVerse;
        this._endVerse = endVerse;
    }


    public string GetDisplayText()
    {
        if (_startVerse == 0 && _endVerse == 0)
        {
            return $"{_book} {_chapter}:{_verse}";
        }

        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }

        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}
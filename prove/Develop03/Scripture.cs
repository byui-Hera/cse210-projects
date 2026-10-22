using System;


class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;


    public Scripture(Reference reference, string text)
    {
        this._reference = reference;
        _words = new List<Word>();
        _random = new Random();


        foreach (string word in text.Split(" "))
        {
            _words.Add(new Word(word));
        }
    }



    public void HideRandomWords(int numberToHide)
    {
        List<Word> wordsStillShowing = new List<Word>();


        foreach (Word word in _words)
        {
            if (!word.isHidden())
            {
                wordsStillShowing.Add(word);
            }
        }



        for (int i = 0; i < numberToHide; i++)
        {
            if (wordsStillShowing.Count == 0)
            {
                break;
            }

            int randomIndex = _random.Next(wordsStillShowing.Count);
            Word wordToHide = wordsStillShowing[randomIndex];
            wordToHide.Hide();
            wordsStillShowing.RemoveAt(randomIndex);
        }
    }


    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.isHidden())
            {
                return false;
            }
        }
        return true;
    }
    


    public string GetDisplayText()
    {
        string scriptureText = "";

        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }

        return _reference.GetDisplayText() + " " + scriptureText.Trim();
    }
}
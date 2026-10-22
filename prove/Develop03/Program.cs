class Program
{
    static void Main()
    {
        Reference reference = new("Proverbs", 3, 5, 3, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";

        Scripture scripture = new(reference, text);


        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide more words, or type 'quit' to exit: ");


            string input = Console.ReadLine();


            if (input?.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase) == true)
            {
                break;
            }

            scripture.HideRandomWords(3);
        }



        if (scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("All words are hidden. Great work!");
        }
    }
}
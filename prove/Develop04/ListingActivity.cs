class ListingActivity : BaseActivity
{
    private readonly List<string> _prompts;
    private readonly List<string> _items;
    private readonly Random _random;

    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many items as you can in a certain area.")
    {
        _random = new Random();
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "Who are some of your personal heroes?"
        };

        _items = new List<string>();
    }

    public void Run()
    {
        StartActivity();
        _items.Clear();

        RunSpinnerMessage("Get ready...", 3);

        string prompt = GetRandomPrompt();
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");

        Console.WriteLine();
        Console.WriteLine("You will have a few seconds to think.");
        ShowCountDown(5);

        Console.WriteLine();
        Console.WriteLine("Start listing items:");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(item))
            {
                _items.Add(item);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {_items.Count} items.");

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}


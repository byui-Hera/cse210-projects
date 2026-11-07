class BaseActivity
{
    private readonly string _name;
    private readonly string _description;
    private int _duration;
    private DateTime _endTime;

    public BaseActivity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 30;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity!");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like your session to last? ");

        string input = Console.ReadLine() ?? "30";
        if (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            _duration = 30;
        }

        SetTimer();
        Console.Clear();
        Console.WriteLine("Get ready...");
        RunSpinnerMessage("Starting", 3);
    }

    public void SetTimer()
    {
        _endTime = DateTime.Now.AddSeconds(_duration);
    }

    public bool HasTimerExpired()
    {
        return DateTime.Now >= _endTime;
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        RunSpinnerMessage("Finishing up", 3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
    }

    public void ShowCountDown(int seconds)
    {
        RunCountDownMessage("Get Ready", seconds);
    }

    public static void RunCountDownMessage(string message, int seconds)
    {
        Console.CursorVisible = false;

        for (int i = seconds; i > 0; i--)
        {
            Console.Clear();
            Console.WriteLine($"{message}: {i} second{(i == 1 ? "" : "s")}");
            Thread.Sleep(1000);
        }

        Console.CursorVisible = true;
    }

    public static void RunSpinnerMessage(string message, int seconds)
    {
        Console.CursorVisible = false;

        if (!string.IsNullOrWhiteSpace(message))
        {
            Console.WriteLine(message);
        }

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] frames = { "|", "/", "-", "\\" };
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[index % frames.Length]);
            Thread.Sleep(200);
            Console.Write("\b");
            index++;
        }

        Console.CursorVisible = true;
        Console.WriteLine();
    }
}
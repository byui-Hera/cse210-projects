using System;
using System.Collections.Generic;

class ReflectionActivity : BaseActivity
{
    private readonly List<string> _prompts;
    private readonly List<string> _questions;
    private readonly Random _random = new Random();

    public ReflectionActivity()
        : base(
            "Reflection",
            "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different from other times?",
            "What did you learn about yourself?",
            "How can you remember this experience in the future?"
        };
    }

    public void Run()
    {
        StartActivity();

        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.WriteLine();
        Console.WriteLine("Think about this experience for a moment.");
        RunSpinnerMessage("Get ready...", 3);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.WriteLine(GetRandomQuestion());

            int remainingSeconds = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            int delaySeconds = Math.Min(5, Math.Max(1, remainingSeconds));
            RunSpinnerMessage("Reflecting", delaySeconds);
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        int index = _random.Next(_questions.Count);
        return _questions[index];
    }
}


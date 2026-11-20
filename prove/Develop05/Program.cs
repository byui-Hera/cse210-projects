using System.Text.Json;

class Program
{
    private static readonly List<BaseGoal> Goals = new();
    private static int _score;

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine($"\nYou have {_score} points. Quest level: {GetLevel(_score)}");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. Record goal event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Save quest");
            Console.WriteLine("5. Load quest");
            Console.WriteLine("6. Quit");

            switch (ReadInt("Select an option: ", 1, 6))
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    RecordGoalEvent();
                    break;
                case 3:
                    ShowGoals();
                    break;
                case 4:
                    SaveQuest();
                    break;
                case 5:
                    LoadQuest();
                    break;
                case 6:
                    running = false;
                    break;
            }
        }
    }

    private static void CreateGoal()
    {
        Console.WriteLine("Goal types: 1. Simple  2. Eternal  3. Checklist");
        int type = ReadInt("Choose a goal type: ", 1, 3);
        string name = ReadText("Goal name: ");
        string description = ReadText("Goal description: ");
        int points = ReadInt("Points per event: ", 1, int.MaxValue);

        BaseGoal goal;
        switch (type)
        {
            case 1:
                goal = new SimpleGoal(name, description, points);
                break;
            case 2:
                goal = new EternalGoal(name, description, points);
                break;
            default:
                int target = ReadInt("How many completions are required? ", 1, int.MaxValue);
                int bonus = ReadInt("Bonus points on completion: ", 0, int.MaxValue);
                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;
        }

        Goals.Add(goal);
        Console.WriteLine("Goal created.");
    }

    private static void RecordGoalEvent()
    {
        if (Goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }

        ShowGoals();
        int index = ReadInt("Which goal did you accomplish? ", 1, Goals.Count) - 1;
        int oldLevel = GetLevel(_score);
        int awardedPoints = Goals[index].RecordEvent();
        _score += awardedPoints;

        if (awardedPoints == 0)
        {
            Console.WriteLine("That goal is already complete; no points were awarded.");
        }
        else
        {
            Console.WriteLine($"You earned {awardedPoints} points!");
            if (GetLevel(_score) > oldLevel)
            {
                Console.WriteLine($"Quest level up! You reached level {GetLevel(_score)}.");
            }
        }
    }

    private static void ShowGoals()
    {
        if (Goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < Goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Goals[i].GetDisplayText()}");
        }
    }

    private static void SaveQuest()
    {
        string filename = ReadText("Save file path: ");
        var saveData = new QuestData
        {
            Score = _score,
            Goals = Goals.ConvertAll(goal => goal.ToData())
        };

        try
        {
            string json = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
            Console.WriteLine("Quest saved.");
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Could not save quest: {exception.Message}");
        }
        catch (UnauthorizedAccessException exception)
        {
            Console.WriteLine($"Could not save quest: {exception.Message}");
        }
    }

    private static void LoadQuest()
    {
        string filename = ReadText("Load file path: ");
        try
        {
            string json = File.ReadAllText(filename);
            QuestData data = JsonSerializer.Deserialize<QuestData>(json);
            if (data == null || data.Score < 0 || data.Goals == null)
            {
                Console.WriteLine("The save file does not contain valid quest data.");
                return;
            }

            List<BaseGoal> loadedGoals = new();
            foreach (GoalData goalData in data.Goals)
            {
                loadedGoals.Add(BaseGoal.FromData(goalData));
            }

            Goals.Clear();
            Goals.AddRange(loadedGoals);
            _score = data.Score;
            Console.WriteLine("Quest loaded.");
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Could not load quest: {exception.Message}");
        }
        catch (UnauthorizedAccessException exception)
        {
            Console.WriteLine($"Could not load quest: {exception.Message}");
        }
        catch (JsonException exception)
        {
            Console.WriteLine($"The save file is invalid: {exception.Message}");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"The save file contains invalid goal data: {exception.Message}");
        }
    }

    private static int GetLevel(int score) => score / 1000 + 1;

    private static string ReadText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value.Trim();
            }

            Console.WriteLine("Please enter a value.");
        }
    }

    private static int ReadInt(string prompt, int minimum, int maximum)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= minimum && value <= maximum)
            {
                return value;
            }

            Console.WriteLine($"Please enter a whole number from {minimum} to {maximum}.");
        }
    }

    // Creativity: every 1,000 points advances the user's quest level, with a celebration on level-up.
    private class QuestData
    {
        public int Score { get; set; }
        public List<GoalData> Goals { get; set; }
    }
}

abstract class BaseGoal
{
    private readonly string _name;
    private readonly string _description;
    private readonly int _points;

    protected BaseGoal(string name, string description, int points)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Goal name cannot be empty.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Goal description cannot be empty.", nameof(description));
        }

        if (points < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(points), "Points cannot be negative.");
        }

        _name = name;
        _description = description;
        _points = points;
    }

    protected string Name => _name;
    protected string Description => _description;
    protected int Points => _points;

    public abstract bool IsComplete { get; }
    public abstract int RecordEvent();
    protected abstract string GoalType { get; }
    protected abstract int Progress { get; }
    protected virtual int Target => 0;
    protected virtual int Bonus => 0;

    public virtual string GetDisplayText()
    {
        string status = IsComplete ? "X" : " ";
        return $"[{status}] {_name} ({GoalType}) - {_description}";
    }

    public GoalData ToData()
    {
        return new GoalData
        {
            Type = GoalType,
            Name = _name,
            Description = _description,
            Points = _points,
            Progress = Progress,
            Target = Target,
            Bonus = Bonus
        };
    }

    public static BaseGoal FromData(GoalData data)
    {
        if (data == null)
        {
            throw new ArgumentException("A saved goal cannot be null.", nameof(data));
        }

        return data.Type switch
        {
            "Simple" => new SimpleGoal(data.Name, data.Description, data.Points, data.Progress != 0),
            "Eternal" => new EternalGoal(data.Name, data.Description, data.Points),
            "Checklist" => new ChecklistGoal(data.Name, data.Description, data.Points, data.Target, data.Bonus, data.Progress),
            _ => throw new ArgumentException($"Unknown goal type '{data.Type}'.", nameof(data))
        };
    }
}

class GoalData
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public int Progress { get; set; }
    public int Target { get; set; }
    public int Bonus { get; set; }
}

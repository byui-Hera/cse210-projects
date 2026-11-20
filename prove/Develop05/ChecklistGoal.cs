class ChecklistGoal : BaseGoal
{
    private readonly int _target;
    private readonly int _bonus;
    private int _completedCount;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int completedCount = 0)
        : base(name, description, points)
    {
        if (target <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(target), "Target must be greater than zero.");
        }

        if (bonus < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bonus), "Bonus cannot be negative.");
        }

        if (completedCount < 0 || completedCount > target)
        {
            throw new ArgumentOutOfRangeException(nameof(completedCount), "Progress must be between zero and the target.");
        }

        _target = target;
        _bonus = bonus;
        _completedCount = completedCount;
    }

    public override bool IsComplete => _completedCount >= _target;
    protected override string GoalType => "Checklist";
    protected override int Progress => _completedCount;
    protected override int Target => _target;
    protected override int Bonus => _bonus;

    public override string GetDisplayText()
    {
        string status = IsComplete ? "X" : " ";
        return $"[{status}] {Name} ({GoalType}) - {Description} (Completed {_completedCount}/{_target} times)";
    }

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            return 0;
        }

        _completedCount++;
        return Points + (IsComplete ? _bonus : 0);
    }
}

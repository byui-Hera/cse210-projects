class EternalGoal : BaseGoal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override bool IsComplete => false;
    protected override string GoalType => "Eternal";
    protected override int Progress => 0;

    public override string GetDisplayText()
    {
        return $"[ ] {Name} ({GoalType}) - {Description}";
    }

    public override int RecordEvent()
    {
        return Points;
    }
}

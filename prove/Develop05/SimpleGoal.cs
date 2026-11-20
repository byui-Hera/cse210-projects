class SimpleGoal : BaseGoal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override bool IsComplete => _isComplete;
    protected override string GoalType => "Simple";
    protected override int Progress => _isComplete ? 1 : 0;

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return Points;
    }
}

class BreathingActivity : BaseActivity
{
    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by guiding you through slow breathing in and out.")
    {
    }

    public void RunActivity()
    {
        StartActivity();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            RunCountDownMessage("Breathe in", 4);
            RunCountDownMessage("Breathe out", 6);
        }

        DisplayEndingMessage();
    }
}
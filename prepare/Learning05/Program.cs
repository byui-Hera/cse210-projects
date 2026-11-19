using System;

class Program
{
    static void Main(string[] args)
    {
        //BaseGoal myGoal = new BaseGoal("Base goal");
        //Console.WriteLine(myGoal.GetConsoleString());


        SimpleGoal mySimpleGoal = new SimpleGoal();
        Console.WriteLine(mySimpleGoal.GetConsoleString());

        mySimpleGoal.MarkComplete();
        Console.WriteLine(mySimpleGoal.GetConsoleString());
    }
}
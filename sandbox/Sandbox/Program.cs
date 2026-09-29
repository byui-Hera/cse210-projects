using System;

class Program
{
    static void Main(string[] args)
    {
        Circle myCircle = new Circle();

        myCircle._radius = 10;

        double area = myCircle.GetArea();

        Console.WriteLine(area);
    }


    class Circle
    {

        // Recipe = includes the variable (ingredient) and the formula
        public double _radius;

        // One Method
        public double GetArea()
        {
            return 3.14159 * Math.Pow(_radius, 2);
        }
    }

    // // Functions in C#
    // static double AddNumbers(double x, int y)
    // {
    //     return x + y;
    // }

    // static string MyName()
    // {
    //     return "Bob";
    // }

    // static void DisplayGreeting(string name)
    // {
    //     Console.WriteLine($"Welcome {name}, it's nice to meet you");
    // }

    // string myName = MyName();
    // DisplayGreeting(myName);
    // double total = AddNumbers(12.234, 20);
    // Console.WriteLine(total);


}
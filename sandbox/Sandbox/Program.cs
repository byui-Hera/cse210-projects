using System;

class Program
{
    static void Main(string[] args)
    {
        // Crreate a variable
        Circle myCircle = new Circle();

        // radius
        myCircle._radius = 10;

        // Find the area of the circle
        double area = myCircle.GetArea();
        Console.WriteLine(area);
    }


    // // Functions in C#
    // static double AddNumbers(double x, double y)
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
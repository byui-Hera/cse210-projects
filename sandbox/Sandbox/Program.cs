class Program
{
    static void Main()
    {
        // Create a variable
        Circle myCircle = new Circle(100);

        // radius
        //myCircle.SetRadius(10);

        // Find the area of the circle
        double area = myCircle.GetArea();
        Console.WriteLine(area);
    }
}

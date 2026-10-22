class Circle
{

    // Recipe = includes the variable (ingredient) and the formula
    private double _radius;

    public Circle()
    {
        _radius = 1.0;
    }


    public Circle(double radius)
    {
        SetRadius(radius);
    }


    public Circle(int radius)
    {
        SetRadius(radius);
    }


    // One Method
    public double GetArea()
    {
        return 3.14159 * Math.Pow(_radius, 2);
    }

    
    public void SetRadius(double radius)
    {
        if (radius < 0)
        {
            Console.WriteLine("Invalid value, must me >= 0");
        }
        else
        {
            _radius = radius;
        }
    }
}
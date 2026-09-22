using System;

class Program
{
    static void Main(string[] args)
    {
        int x = 10;
        int y = 30;
        int z = 40;

        if ((x == 10 || y == 30) && z == 30)
        {
            Console.WriteLine("X is 10");
            Console.WriteLine("Y is fun");
        }

        else if (x == 20)
        {
            Console.WriteLine("X is 10");
        }

        else
        {
            Console.WriteLine("Default output");
        }

        // Convert string to number
        //string numberString = "123";
        //int myNumber = int.Parse(numberString);
        //Console.WriteLine(myNumber);


        // Convert number to string
        //int number = 100;
        //string stringNumber = number.ToString();
        //Console.WriteLine(stringNumber);

    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        // int x = 10;
        // int y = 30;
        // int z = 40;

        // if ((x == 10 || y == 30) && z == 30)
        // {
        //     Console.WriteLine("X is 10");
        //     Console.WriteLine("Y is fun");
        // }

        // else if (x == 20)
        // {
        //     Console.WriteLine("X is 10");
        // }

        // else
        // {
        //     Console.WriteLine("Default output");
        // }


        // While loops = it will run until it's done
        // bool done = false;

        // while (!done)
        // {
        //     Console.WriteLine("Are we done {y/n}? ");
        //     done = Console.ReadLine() == "y";
        // }


        // it will continue until you type yes
        //bool done;

        // do
        // {
        //     Console.WriteLine("Are we done {y/n}? ");
        //     done = Console.ReadLine() == "y";
        // } while (!done);



        // for loops = it's like "for x in range(1, 10, 2)" in Python
        // starts with 0 and it ends with 9
        // for (int i = 2; i <= 10; i += 2)
        // {
        //     Console.WriteLine(i);
        // }


        //Lists

        List<string> myFriends = new List<string> { "Bob", "Betty", "Bubba" };

        myFriends.Add("Doug");

        foreach(string friend in myFriends)
        {
            Console.WriteLine(friend);
        } 



    }
}
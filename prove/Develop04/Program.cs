using System;

class Program
{
    static void Main()
    {
        bool running = true;

        // Exceeds the basic requirements by letting the user switch activities repeatedly
        // until they choose to quit, instead of restarting the program after each one.
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflection Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an activity: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice.Trim())
            {
                case "1":
                    new BreathingActivity().RunActivity();
                    break;
                case "2":
                    new ListingActivity().Run();
                    break;
                case "3":
                    new ReflectionActivity().Run();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 4.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
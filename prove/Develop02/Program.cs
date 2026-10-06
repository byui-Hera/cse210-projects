using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        List<string> prompts = new List<string>
        {
            "What was the best part of the day?",
            "Who did I talk to today, and what did I learn from them?",
            "What is something new I learned?",
            "What made me laugh today?",
            "What is one thing I am grateful for?",
            "What is one small thing I did today that moved me toward a goal?",
            "When did I feel most calm or at peace today?",
            "What is something I want to remember about today?"
        };

        Random random = new Random();
        string choice = "";

        // Exceeded requirements: option 5 lets users search past entries by date, prompt, or response.
        while (choice != "6")
        {
            Console.WriteLine("1. Write a new entry: ");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Search journal entries");
            Console.WriteLine("6. Quit");
            Console.WriteLine();

            Console.Write("Enter one of the choices above: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");

                string prompt = prompts[random.Next(prompts.Count)];
                Console.WriteLine(prompt);
                Console.Write("> ");

                string response = Console.ReadLine();

                Entry entry = new Entry(date, prompt, response);
                journal.AddEntry(entry);

                Console.WriteLine("Entry added.");
            }

            else if (choice == "2")
            {
                journal.DisplayAll();
            }

            else if (choice == "3")
            {
                Console.Write("Filename to save to: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }

            else if (choice == "4")
            {
                Console.Write("Filename to load: ");
                string filename = Console.ReadLine();

                if (System.IO.File.Exists(filename))
                {
                    journal.LoadFromFile(filename);
                }
                else
                {
                    Console.WriteLine("I couldn't find that file.");
                }
            }

            else if (choice == "5")
            {
                Console.Write("Search for text in a date, prompt, or response: ");
                string searchTerm = Console.ReadLine();
                journal.DisplayMatchingEntries(searchTerm);
            }

            else if (choice == "6")
            {
                Console.WriteLine("Goodbye!");
            }

            else
            {
                Console.WriteLine("Please choose a number from 1 to 6.");
            }
        }
    }
}

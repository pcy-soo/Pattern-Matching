using System;
using System.Text.RegularExpressions;

namespace RegexConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string defaultRegex = @"^[a-z]+$";

            while (true)
            {
                Console.Clear();
                Console.Write($"Enter a regular expression (or press ENTER to use the default '{defaultRegex}'): ");
                string inputRegex = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputRegex))
                {
                    inputRegex = defaultRegex;
                }

                Regex r;
                try
                {
                    r = new Regex(inputRegex);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Invalid regular expression: {inputRegex}");
                    continue;
                }

                Console.Write("Enter some input: ");
                string userInput = Console.ReadLine();

               
                bool isMatch = r.IsMatch(userInput);
                Console.WriteLine($"{userInput} matches {inputRegex}? {isMatch}");

               
                Console.WriteLine("Press ESC to end or any key to try again.");
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                Console.WriteLine();  
            }
        }
    }
}

using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Number Checker!");
            Console.WriteLine("What's your name? Enter it below:");
            String name = Console.ReadLine();
            if (name == "Jacob Hands")
            {
                Console.WriteLine("Greetings, master.");
            }
            else
            {
                Console.WriteLine($"Hello, {name}!");
            }
            bool repeat = true;

            while (repeat)
            {
                int number = RequestNumber(name);
                PrintResults(number, name);
                repeat = RequestRepeat();
            }

            Console.WriteLine($"Goodbye, {name}!");
            Console.Read();
        }

        static int RequestNumber(String name)
        {
            Console.Write($"\n{name}, please enter a whole number between 1 and 100: ");
            int number = ValidateNumber(Console.ReadLine(), name);
            return number;
        }

        static int ValidateNumber(String inputString, String name)
        {
            if (Int32.TryParse(inputString, out int number))
            {
                if (number < 1 || number > 100)
                {
                    Console.WriteLine($"Invalid input, {name}. Number must be between 1 and 100.");
                    return RequestNumber(name);
                }
                return number;
            }
            Console.WriteLine($"Invalid input, {name}. Must be a whole number between 1 and 100.");
            return RequestNumber(name);
        }

        static void PrintResults(int number, String name)
        {
            if ((number % 2) == 1)
            {
                Console.WriteLine($"{number}, Odd");
            }
            else if ((number % 2) == 0 && number >= 2 && number <= 25)
            {
                Console.WriteLine($"{number}, Even and less than 25");
            }
            else if ((number % 2) == 0 && number >= 26 && number <= 60)
            {
                Console.WriteLine($"{number}, Even");
            }
            else if ((number % 2) == 0 && number > 60)
            //No idea why the assignment asks for the separation between these two ranges
            {
                Console.WriteLine($"{number}, Even");
            }
            else if ((number % 2) == 1 && number > 60)
            //This is impossible to reach due to the first conditional already weeding out odd numbers.
            //And it outputs the same thing anyways.
            {
                Console.WriteLine($"{number}, Odd");
            }
            else
            {
                Console.WriteLine($"Congratulations, {name}! You discovered a new integer between 1 and 100.");
                Console.WriteLine("Please publish your findings in a relevant academic journal as soon as you can.");
            }
        }

        static bool RequestRepeat()
        {
            Console.Write("Continue? (y/n): ");
            String response = Console.ReadLine().ToLower();
            if (response == "y" || response == "yes")
            {
                return true;
            }
            else if (response == "n" || response == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Not a valid response.");
                return RequestRepeat();
            }
        }
    }
}

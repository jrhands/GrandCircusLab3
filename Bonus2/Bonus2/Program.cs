using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the age calculator!");

            DateTime birthday = RequestBirthday();
            int[] age = CalcAge(birthday);
            PrintAge(age);

            Console.WriteLine("Goodbye!");
            Console.Read();
        }

        static DateTime RequestBirthday()
        {
            Console.WriteLine("This will request and validate their birthday.");
            return new DateTime(1998, 9, 23);
        }

        static int[] CalcAge(DateTime birthday)
        {
            Console.WriteLine("This will calculate the user's age in years and days based on the current date.");
            return new int[] {0, 1};
        }

        static void PrintAge(int[] age)
        {
            Console.WriteLine("This will print the person's age in years and days.");
            Console.WriteLine(age[0] + " " + age[1]);
        }
    }
}

using System;

namespace Bonus2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the age calculator!\n");
            bool repeat = true;
            while (repeat)
            {
                DateTime birthday = RequestBirthday();
                int[] age = CalcAge(birthday);
                int years = age[0], days = age[1];
                PrintAge(years, days);
                repeat = RequestRepeat();
            }

            Console.WriteLine("\nGoodbye!");
            Console.Read();
        }

        static DateTime RequestBirthday()
        {
            Console.WriteLine("What is your birthday?\n");
            bool validBDay = true;
            int year = 0, month = 0, day = 0;
            const int JAN = 1, FEB = 2, MAR = 3, APR = 4, MAY = 5, JUN = 6, JUL = 7, AUG = 8,
                SEPT = 9, OCT = 10, NOV = 11, DEC = 12;
            String input;
            do
            {
                Console.Write("Year: ");
                input = Console.ReadLine();
                if (Int32.TryParse(input, out year) && year >= 0)
                {
                    validBDay = true;
                }
                else
                {
                    Console.WriteLine($"{input} is not a valid year.");
                    validBDay = false;
                }
            } while (!validBDay);
            do
            {
                Console.Write("Month: ");
                input = Console.ReadLine();
                if (Int32.TryParse(input, out month) && month >= 1 && month <= 12)
                {
                    validBDay = true;
                }
                else
                {
                    switch (input.ToLower())
                    {
                        case "jan":
                        case "january":
                            month = JAN;
                            validBDay = true;
                            break;
                        case "feb":
                        case "february":
                            month = FEB;
                            validBDay = true;
                            break;
                        case "mar":
                        case "march":
                            month = MAR;
                            validBDay = true;
                            break;
                        case "apr":
                        case "april":
                            month = APR;
                            validBDay = true;
                            break;
                        case "may":
                            month = MAY;
                            validBDay = true;
                            break;
                        case "jun":
                        case "june":
                            month = JUN;
                            validBDay = true;
                            break;
                        case "jul":
                        case "july":
                            month = JUL;
                            validBDay = true;
                            break;
                        case "aug":
                        case "august":
                            month = AUG;
                            validBDay = true;
                            break;
                        case "sept":
                        case "september":
                            month = SEPT;
                            validBDay = true;
                            break;
                        case "oct":
                        case "october":
                            month = OCT;
                            validBDay = true;
                            break;
                        case "nov":
                        case "november":
                            month = NOV;
                            validBDay = true;
                            break;
                        case "dec":
                        case "december":
                            month = DEC;
                            validBDay = true;
                            break;
                        default:
                            Console.WriteLine($"{input} is not a valid month.");
                            validBDay = false;
                            break;
                    }
                }
            } while (!validBDay);
            do
            {
                Console.Write("Day: ");
                input = Console.ReadLine();
                switch (month)
                {
                    case JAN:
                    case MAR:
                    case MAY:
                    case JUL:
                    case AUG:
                    case OCT:
                    case DEC:
                        if (Int32.TryParse(input, out day) && day >= 1 && day <= 31)
                        {
                            validBDay = true;
                        }
                        else
                        {
                            Console.WriteLine($"{input} is not a valid day for that month.");
                            validBDay = false;
                        }
                        break;
                    case FEB:
                        if (Int32.TryParse(input, out day) && day >= 1 &&
                            ((DateTime.IsLeapYear(year) && day <= 29) || day <= 28))
                        {
                            validBDay = true;
                        }
                        else
                        {
                            Console.WriteLine($"{input} is not a valid day for that month.");
                            validBDay = false;
                        }
                        break;
                    default:
                        if (Int32.TryParse(input, out day) && day >= 1 && day <= 30)
                        {
                            validBDay = true;
                        }
                        else
                        {
                            Console.WriteLine($"{input} is not a valid day for that month.");
                            validBDay = false;
                        }
                        break;
                }
            } while (!validBDay);
            return new DateTime(year, month, day);
        }

        static int[] CalcAge(DateTime birthday)
        {
            int days = DateTime.Today.Subtract(birthday).Duration().Days - CalcLeapYears(birthday);
            int years = days / 365;
            days %= 365;
            return new int[] { years, days };
        }

        static int CalcLeapYears(DateTime birthday)
        {
            int leapYears = 0;
            DateTime today = DateTime.Today;
            if (DateTime.IsLeapYear(birthday.Year) && birthday <= new DateTime(birthday.Year, 2, 28))
            {
                leapYears++;
            }
            if (DateTime.IsLeapYear(today.Year) && today >= new DateTime(today.Year, 3, 1))
            {
                leapYears++;
            }
            for (int yearLiving = birthday.Year + 1; yearLiving < today.Year; yearLiving++)
            {
                if (DateTime.IsLeapYear(yearLiving))
                {
                    leapYears++;
                }
            }
            return leapYears;
        }

        static void PrintAge(int years, int days)
        {
            if (days == 0)
            {
                Console.WriteLine($"\nYou are {years} years old. Happy birthday!");
            }
            else
            {
                Console.WriteLine($"\nYou are {years} years and {days} days old.");
            }
        }

        static bool RequestRepeat()
        {
            Console.WriteLine("Continue? (y/n): ");
            String input = Console.ReadLine().ToLower();
            if (input == "y" || input == "yes")
            {
                return true;
            }
            else if (input == "n" || input == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine($"{input} is not a valid response.");
                return RequestRepeat();
            }
        }
    }
}

using System;

namespace CrazyTimers
{
    class Program
    {
        static void CountdownCalculator () {
            Console.WriteLine("Countdown Timer Calculator by Wendy Breiding");
            Console.WriteLine("Version 1.0");
            int numHours = MethodLibraries.readInt("Enter the number of hours: ", 0, 23);
            int numMinutes = MethodLibraries.readInt("enter the number of minutes: ", 0, 59);
            int numSeconds = MethodLibraries.readInt("Enter the number of seconds: ", 0, 59);

            int result = numHours * 3600 + numMinutes * 60 + numSeconds;

            Console.WriteLine($"The total number of seconds is: {result}");

        }

        static void ReverseCountdownCalculator() {
            Console.WriteLine("Reverse Countdown Timer Calculator by Wendy Breiding");
            Console.WriteLine("Version 1.0");
            int numSeconds = MethodLibraries.readInt("Enter the number of seconds: ", 0, 999999);
            int resultHours = numSeconds/3600;
            int remainingSeconds = numSeconds - resultHours*3600;
            int resultMinutes = remainingSeconds/60;
            remainingSeconds = remainingSeconds - resultMinutes*60;

            Console.WriteLine($"This is equal to {resultHours} hours, {resultMinutes} minutes and {remainingSeconds} seconds");
        }
        
        static void SecondsToCalculator() {
            Console.WriteLine("Seconds to Calculator by Wendy Breiding");
            Console.WriteLine("Version 1.0");
            DateTime date; 
            bool isValid;
            
            do {
                int hour = MethodLibraries.readInt("Enter the hour: ", 0, 23);
                int day = MethodLibraries.readInt("Enter the day: ", 1, 31);
                int month = MethodLibraries.readInt("Enter the month: ", 1, 12);
                int year = MethodLibraries.readInt("Enter the year: ", 2017, 9999);
                isValid = DateTime.TryParse($"{month}/{day}/{year} {hour}:00:00", out date);
                if (!isValid) {Console.WriteLine("You did not enter a valid date.");}
            } while (!isValid);

            int result = (int)date.Subtract(DateTime.Now).TotalSeconds;
            Console.WriteLine($"The total number of seconds is {result}.");
        }
        static void Main(string[] args)
        {
            string answer;
            do {
                answer = MethodLibraries.readString("Would you like to do the Countdown Calculator (A), the Reverse Countdown Calculator (B), or the Seconds to Calculator (C)? ").ToUpper();
            } while (!(answer == "A" || answer == "B" || answer == "C"));
            
            switch(answer) {
                case "A":
                    CountdownCalculator();
                    break;
                case "B":
                    ReverseCountdownCalculator();
                    break;
                case "C":
                    SecondsToCalculator();
                    break;
                default:
                    break;
            }
        }
    }
}

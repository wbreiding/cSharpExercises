using System;
    public class MethodLibraries
    {
        public static string readString(string prompt)
        {
            string result;

            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
            } while (result == "");

            return result;
        }

        public static int readInt(string prompt, int low, int high, string error)
        {
            int result;
            do
            {
                string intString = readString(prompt);
                if (!int.TryParse(intString, out result))
                {
                    Console.WriteLine("You did not enter a valid number.");
                    continue;
                };
                if ((result < low) || (result > high))
                {
                    Console.WriteLine(error);
                    continue;
                }
            } while ((result < low) || (result > high));
            return result;
        }

        public static int readInt(string prompt, int low, int high)
        {
            int result;
            do
            {
                string intString = readString(prompt);
                if (!int.TryParse(intString, out result))
                {
                    Console.WriteLine("You did not enter a valid number.");
                    continue;
                };
                if ((result < low) || (result > high))
                {
                    Console.WriteLine($"Enter a number between {low} and {high}");
                    continue;
                }
            } while ((result < low) || (result > high));
            return result;
        }
    }
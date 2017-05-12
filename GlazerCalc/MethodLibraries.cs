using System;

class MethodLibraries {
        public static string readString( string prompt) {
            string result;
            do {
                Console.WriteLine( prompt );
                result = Console.ReadLine();
            } while ( result == "");
            return result;
        }

        public static int readInt(string prompt, int low, int high) {
            int result;
            do {
                string intString = readString ( prompt );
                result = int.Parse(intString);
            } while ( (result < low) || (result > high));
            return result;
        }

        public static void Main() {
            string name;
            name = readString("Enter your name : ");
            Console.WriteLine('Name: ' + name);

            int age;
            try {
                age = readInt("Enter your age: ", 0, 100);
                Console.WriteLine("Age: " + age);
            } catch (Exception e) {
                Console.Write(e.Message);
            }
        }

}
using System;
namespace Movie {
    public class MethodLibraries {
            public static string readString( string prompt) {
                string result;
                do {
                    Console.Write( prompt );
                    result = Console.ReadLine();
                } while ( result == "");
                return result;
            }

            public static int readInt(string prompt, int low, int high, string error) {
                int result;
                do {
                    string intString = readString ( prompt );
                    result = int.Parse(intString);
                    if ((result < low) || (result > high)) {
                        Console.WriteLine( error );
                    }
                } while ( (result < low) || (result > high));
                return result;
            }

    }
}
using System;
using MethodLibraries;

namespace library
{
    class GlazerCalc
    {
        static double readValue(string prompt, double low, double high) {
            double result = 0;
            do {
                Console.WriteLine(prompt + " between " + low + " and " + high);
                string resultString = Console.ReadLine();
                result = double.Parse(resultString);
            } while ( (result < low || result > high) );
            return result;
        }
        
        public static void Main(string[] args)
        {
            double width, height, woodLength, glassArea;
            
            const double MAX_WIDTH = 5.0;
            const double MIN_WIDTH = 0.5;
            const double MAX_HEIGHT = 3.0;
            const double MIN_HEIGHT = 0.75;

            width = readValue("Enter a width of the window: ", MIN_WIDTH, MAX_WIDTH);
            height = readValue("Enter a height of the window: ", MIN_HEIGHT, MAX_HEIGHT);
            
            woodLength = 2 * ( width + height ) * 3.25 ;
            glassArea = 2 * ( width * height ) ;
            Console.WriteLine ( "The length of the wood is " +
                woodLength + " feet" ) ;
            Console.WriteLine( "The area of the glass is " +
                glassArea + " square metres" ) ;
            
        }
    }
}

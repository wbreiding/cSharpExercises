using System;
using System.Text.RegularExpressions;

namespace Movie
{
    class Cinema
    {
        private static void printMovie(Movie in_movie)
        {
            Console.WriteLine($"{in_movie}s");
        }

        public static void Main(string[] args)
        {
            var movieArray = new Movie[]{
                new Movie{
                    MovieNum = 1,
                    MovieTitle = "Rush",
                    MovieAge = "15"
                },
                new Movie{
                    MovieNum = 2,
                    MovieTitle = "How I live Now",
                    MovieAge = "15"},
                new Movie{
                    MovieNum = 3,
                    MovieTitle = "Thor: The Dark Work",
                    MovieAge = "12A"
                },
                new Movie{
                    MovieNum = 4,
                    MovieTitle = "Filth",
                    MovieAge = "18"
                },
                new Movie{
                    MovieNum = 5,
                    MovieTitle = "Planes",
                    MovieAge = "U"
                }
            };

            Console.WriteLine("Welcome to our Multiplex");

            Console.WriteLine("We are presently showing:");
            for (int i = 0; i < movieArray.Length; i++)
            {
                printMovie(movieArray[i]);
            }

            int selection = MethodLibraries.readInt("Enter the number of the film you wish to see: ", 1, movieArray.Length);
            int age = MethodLibraries.readInt("Enter your age: ", 0, 150);

            string movieAge = movieArray[selection - 1].MovieAge;

            if (movieAge == "U")
            {
                Console.WriteLine("Enjoy the movie");
            }
            else
            {
                movieAge = Regex.Replace(movieAge, "[^0-9.]", "");
                int int_movieAge = Convert.ToInt32(movieAge);
                if (age < int_movieAge)
                {
                    Console.WriteLine("Access denied – you are too young");
                }
                else
                {
                    Console.WriteLine("Enjoy the movie");
                }
            }
        }
    }
}
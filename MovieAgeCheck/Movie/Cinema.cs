using System;
using System.Text.RegularExpressions;

namespace Movie {
    class Cinema
    {
        private const int NUM_MOVIES = 5;

        private static void printMovie(Movie in_movie) {
            Console.WriteLine(in_movie.getMovieNum() + ". " + in_movie.getMovieTitle() + " (" + in_movie.getMovieAge() + ")");
        }

        public static void Main(string[] args)
        {
            
            Movie[] movieArray = new Movie[NUM_MOVIES];
            movieArray[0] = new Movie(1, "Rush", "15");
            movieArray[1] = new Movie (2, "How I live Now", "15");
            movieArray[2] = new Movie(3, "Thor: The Dark Work", "12A");
            movieArray[3] = new Movie(4, "Filth", "18");
            movieArray[4] = new Movie(5, "Planes", "U");
            
            Console.WriteLine("Welcome to our Multiplex");
            
            Console.WriteLine("We are presently showing:");
            for (int i=0; i<NUM_MOVIES; i++) {
                printMovie(movieArray[i]);
            }

            int selection = MethodLibraries.readInt("Enter the number of the film you wish to see: ", 1, NUM_MOVIES);
            int age = MethodLibraries.readInt("Enter your age: ", 0, 150);

            string movieAge = movieArray[selection-1].getMovieAge();

            if (movieAge == "U") {
                Console.WriteLine("Enjoy the movie");
            } else {
                movieAge = Regex.Replace(movieAge, "[^0-9.]", "");
                int int_movieAge = System.Convert.ToInt32(movieAge);
                if (age < int_movieAge) {
                    Console.WriteLine("Access denied – you are too young");
                } else {
                    Console.WriteLine("Enjoy the movie");
                }
            }
        }
    }
}
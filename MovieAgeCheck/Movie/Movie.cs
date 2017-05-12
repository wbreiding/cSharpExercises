using System;

namespace Movie {
    public class Movie {

        private int movieNum;
        private string movieTitle;
        private string movieAge;

        public Movie (int in_movieNum, string in_movieTitle, string in_movieAge) {
            movieNum = in_movieNum;
            movieTitle = in_movieTitle;
            movieAge = in_movieAge;
        }

        public int getMovieNum() {
            return movieNum;
        }
        
        public string getMovieTitle() {
            return movieTitle;
        }

        public string getMovieAge() {
            return movieAge;
        }
    }
}
using System;

namespace Movie {
    public class Movie {

        private int movieNum;
        private string movieTitle;
        private string movieAge;

        public int MovieNum {
            get {
                return movieNum;
            }
            set {
                movieNum = value;
            }
        }

        public string MovieTitle {
            get {
                return movieTitle;
            }
            set {
                movieTitle = value;
            }
        }

        public string MovieAge {
            get {
                return movieAge;
            }
            set {
                movieAge = value;
            }
        }

        public override String ToString() {
            return $"{MovieNum}. {MovieTitle} ({MovieAge})";
        }
    }
}
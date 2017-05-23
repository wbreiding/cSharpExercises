using System;

namespace CricketScores
{
    struct Player {
        public string Name;
        public int Score;
    }
    class Program
    {
        private const int NUM_PLAYERS = 11;

       private static Player getPlayerInfo(int i) {
            Player player = new Player();
            player.Name = MethodLibraries.readString($"Enter Player {i+1}'s name: ");
            player.Score = MethodLibraries.readInt($"Enter Player {i+1}'s score: ", 0, 500, "Score too large. Please enter a score between 0 and 500");
            return player;
       }

       private static Player[] sortPlayersByName(Player[] players) {
            for (int i=0; i<NUM_PLAYERS; i++) {
                for (int j=i+1; j<NUM_PLAYERS; j++) {
                    string a = players[i].Name;
                    string b = players[j].Name;
                    int a_score = players[i].Score;
                    int b_score = players[j].Score;
                    if (a.CompareTo(b) > 0)
                    {
                        players[i].Name = b;
                        players[i].Score = b_score;
                        players[j].Name = a;
                        players[j].Score = a_score;
                    }
                }

            }
            return players;
       }

       private static Player[] sortPlayersByScore(Player[] players) {
            for (int i=0; i<NUM_PLAYERS; i++) {
                for (int j=i+1; j<NUM_PLAYERS; j++) {
                    int a = players[i].Score;
                    string a_name = players[i].Name;
                    int b = players[j].Score;
                    string b_name = players[j].Name;
                    if (a > b) {
                        players[i].Score = b;
                        players[i].Name = b_name;
                        players[j].Score = a;
                        players[j].Name = a_name;
                    }
                }
            }
            return players;
       }
        static void Main(string[] args)
        {
            Player[] players = new Player[NUM_PLAYERS]; 
            for (int i=0; i<NUM_PLAYERS; i++) {
                players[i] = getPlayerInfo(i);
            }
            
            string sort;
            do {
                sort = MethodLibraries.readString("Do you want to sort by name or by scores? (enter N or S): ");
            } while (!(sort.Equals("N") || sort.Equals("S")));
                
            if (sort.Equals("N")) {
                players = sortPlayersByName(players);
            } else {
                players = sortPlayersByScore(players);
            }

            for (int i=0; i<NUM_PLAYERS; i++) {
                Console.WriteLine(players[i].Name + ": " + players[i].Score);
            }
            
        }
    }
}

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
        static void Main(string[] args)
        {
            Player[] players = new Player[NUM_PLAYERS]; 
            for (int i=0; i<NUM_PLAYERS; i++) {
                players[i] = getPlayerInfo(i);
            }
            string sort = MethodLibraries.readString("Do you want to sort by name or by scores? (enter N or S): ");
        }
    }
}

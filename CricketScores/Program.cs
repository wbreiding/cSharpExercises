using System;

namespace CricketScores
{
    struct Player
    {
        public string Name;
        public int Score;
    }
    class Program
    {
        private const int NUM_PLAYERS = 11;

        private static Player getPlayerInfo(int i)
        {
            Player player = new Player();
            player.Name = MethodLibraries.readString($"Enter Player {i + 1}'s name: ");
            player.Score = MethodLibraries.readInt($"Enter Player {i + 1}'s score: ", 0, 500, "Score too large. Please enter a score between 0 and 500");
            return player;
        }

        private static Player[] sortPlayersByName(Player[] players)
        {
            for (int i = 0; i < NUM_PLAYERS; i++)
            {
                for (int j = i + 1; j < NUM_PLAYERS; j++)
                {
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

        private static void DoMerge(Player[] players, int left, int mid, int right)
        {
            Player[] temp = new Player[players.Length];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (players[left].Score <= players[mid].Score)
                {
                    temp[tmp_pos++] = players[left++];
                }
                else
                {
                    temp[tmp_pos++] = players[mid++];
                }
            }

            while (left <= left_end)
            {
                temp[tmp_pos++] = players[left++];
            }

            while (mid <= right)
            {
                temp[tmp_pos++] = players[mid++];
            }

            for (i = 0; i < num_elements; i++)
            {
                players[right] = temp[right];
                right--;
            }
        }

        private static void RecursiveMergeSort(Player[] players, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                RecursiveMergeSort(players, left, mid);
                RecursiveMergeSort(players, (mid + 1), right);

                DoMerge(players, left, (mid + 1), right);
            }
        }
        private static Player[] sortPlayersByScore(Player[] players)
        {
            int left = 0;
            int right = players.Length - 1;

            RecursiveMergeSort(players, left, right);

            return players;
        }
        static void Main(string[] args)
        {
            Player[] players = new Player[NUM_PLAYERS];
            for (int i = 0; i < NUM_PLAYERS; i++)
            {
                players[i] = getPlayerInfo(i);
            }

            string sort;
            do
            {
                sort = MethodLibraries.readString("Do you want to sort by name or by scores? (enter N or S): ").ToUpper();
            } while (!(sort.Equals("N") || sort.Equals("S")));

            if (sort.Equals("N"))
            {
                players = sortPlayersByName(players);
            }
            else
            {
                players = sortPlayersByScore(players);
            }

            for (int i = 0; i < NUM_PLAYERS; i++)
            {
                Console.WriteLine(players[i].Name + ": " + players[i].Score);
            }

        }
    }
}

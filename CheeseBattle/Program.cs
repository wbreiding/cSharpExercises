using System;

namespace CheeseBattle
{
    
    struct Player {
            public string Name;
            public int X;
            public int Y;
    }

    class Program
    {
        enum directions {
            right,
            up,
            left,
            down
        }
        /*  0 = right arrow,
            1 = up arrow,
            2 = left arrow,
            3 = down arrow
         */
        static int[,] board = new int[,] {
            {1,1,1,1,1,1,1,1}, //row 0
            {0,0,1,3,1,1,2,2}, //row 1
            {0,0,1,0,2,0,2,2}, //row 2
            {0,0,1,0,1,1,2,2}, //row 3
            {0,0,1,0,1,1,2,2}, //row 4
            {0,0,0,0,1,1,2,2}, //row 5
            {0,0,1,3,1,0,2,2}, //row 6
            {3,0,0,0,0,0,3,0} //row 7
        };

        
        static Player[] players = new Player[4];
        static int[,] playerPositions = new int[4,2];

        static void ResetGame() {
            int numPlayers = MethodLibraries.readInt("How many players? ", 1,4);
            players = new Player[numPlayers];
            playerPositions = new int[numPlayers,2];
            for (int i=0; i<numPlayers; i++) {
                playerPositions[i,0] = 0;
                playerPositions[i,1] = 0;
                players[i].Name = "Player" + (i+1);
                players[i].X = 0;
                players[i].Y = 0;
            }
        }

        static int DiceThrow() {
            return 1;
        }
        private static void PlayerTurn(int PlayerNo) {
            // TODO: Makes a move for the given player
            int roll = DiceThrow();
            int[] position = playerPositions[PlayerNo];
            int direction = board[position];
            switch (direction) {
                case directions.right:
                    position[0] = position[0]+roll;
                    break;
                case directions.up:
                    position[1] = position[1]+roll;
                    break;
                case directions.down:
                    position[1] = position[1]-roll;
                    break;
                case directions.left:
                    position[0] = position[0]-roll;
                    break;
                default:
                    //error
            }
            Console.WriteLine("You are now at: " + position);
        }

        static void Main(string[] args)
        {
            ResetGame();
        }
    }
}

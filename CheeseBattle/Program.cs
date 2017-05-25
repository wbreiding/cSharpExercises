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
            {1,0,0,0,0,0,0,3}, //row 0
            {1,0,0,0,0,0,0,0}, //row 1
            {1,1,1,1,1,0,1,0}, //row 2
            {1,3,0,0,0,0,3,0}, //row 3
            {1,1,2,1,1,1,1,0}, //row 4
            {1,1,0,1,1,1,0,0}, //row 5
            {1,2,2,2,2,2,2,3}, //row 6
            {1,2,2,2,2,2,2,0} //row 7
        };

        
        static Player[] players = new Player[4];
        static int numPlayers;
        static void ResetGame() {
            numPlayers = MethodLibraries.readInt("How many players? ", 1,4);
            players = new Player[numPlayers];
            for (int i=0; i<numPlayers; i++) {
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

            int[] position = {players[PlayerNo].X, players[PlayerNo].Y};
            int direction = board[position[0], position[1]];            
            switch (direction) {
                case (int)directions.right:
                    position[0] = position[0]+roll;
                    while (RocketInSquare(position[0],position[1])) {
                        Bounce(position);
                    }
                    players[PlayerNo].X = position[0];
                    players[PlayerNo].Y = position[1];
                    break;
                case (int)directions.up:
                    position[1] = position[1]+roll;
                    while (RocketInSquare(position[0],position[1])) {
                        Bounce(position);
                    }
                    players[PlayerNo].X = position[0];
                    players[PlayerNo].Y = position[1];
                    break;
                case (int)directions.down:
                    position[1] = position[1]-roll;
                    while (RocketInSquare(position[0],position[1])) {
                        Bounce(position);
                    }
                    players[PlayerNo].X = position[0];
                    players[PlayerNo].Y = position[1];
                    break;
                case (int)directions.left:
                    position[0] = position[0]-roll;
                    while (RocketInSquare(position[0],position[1])) {
                        Bounce(position);
                    }
                    players[PlayerNo].X = position[0];
                    players[PlayerNo].Y = position[1];
                    break;
                default:
                    //error
                    Console.WriteLine($"Player {PlayerNo} did not move.");
                    break;
            }
            Console.WriteLine($"Player {PlayerNo} is now at ({position[0]}, {position[1]})");
        }

        static bool RocketInSquare(int X, int Y) {
            for (int i=0; i<numPlayers; i++) {
                if (X == players[i].X && Y == players[i].Y) {
                    return true;
                } else {
                    continue;
                }
            }
            return false;
        }
        
        static void Bounce(int[] position) {
            int direction = board[position[0], position[1]];
            
            switch (direction) {
                case (int)directions.right:
                    position[0] = position[0]+1;
                    while (RocketInSquare(position[0],position[1])) {
                        Bounce(position);
                    }
                    break;
                case (int)directions.up:
                    position[1] = position[1]+1;
                    while (RocketInSquare(position[0],position[1])) {
                        Bounce(position);
                    }
                    break;
                case (int)directions.down:
                    position[1] = position[1]-1;
                    while (RocketInSquare(position[0],position[1])) {
                        Bounce(position);
                    }
                    break;
                case (int)directions.left:
                    position[0] = position[0]-1;
                    while (RocketInSquare(position[0],position[1])) {
                        Bounce(position);
                    }
                    break;
                default:
                    //error
                    Console.WriteLine("Player did not move.");
                    break;
            }

        }

        static void Main(string[] args)
        {
            ResetGame();
            
            for (int i = 0; i<numPlayers; i++) {
                PlayerTurn(i);
            }
        }
    }
}

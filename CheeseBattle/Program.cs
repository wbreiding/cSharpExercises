using System;

namespace CheeseBattle
{

    struct Player
    {
        public string Name;
        public int X;
        public int Y;
    }

    class Program
    {
        enum directions
        {
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
        static bool gameOver = false;
        static bool TESTMODE = false;

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

        static bool[,] cheeseBoard = new bool[,] {
            {false, false, false, true, false, false, false, false},
            {false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false},
            {false, false, false, false, false, true, false, false},
            {false, true, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false},
            {false, false, false, false, true, false, false, false},
            {false, false, false, false, false, false, false, false}
        };

        static int[] diceValues = new int[] { 2, 2, 3, 3 };
        static int diceValuePos = 0;
        static Random diceRandom = new Random();

        static Player[] players = new Player[4];
        static int numPlayers;
        static int winner;
        static void ResetGame()
        {
            numPlayers = MethodLibraries.readInt("How many players? ", 1, 4);
            players = new Player[numPlayers];
            for (int i = 0; i < numPlayers; i++)
            {
                players[i].Name = MethodLibraries.readString("Enter a name for this player: ");
                players[i].X = 0;
                players[i].Y = 0;
            }
        }

        static int PresetDiceThrow()
        {
            int spots = diceValues[diceValuePos];
            diceValuePos = diceValuePos + 1;
            if (diceValuePos == diceValues.Length) diceValuePos = 0;
            return spots;
        }
        static int RandomDiceThrow()
        {
            int spots = diceRandom.Next(1, 7);
            return spots;
        }

        private static void PlayerTurn(int PlayerNo)
        {
            int roll;
            if (TESTMODE)
            {
                roll = PresetDiceThrow();
            }
            else
            {
                roll = RandomDiceThrow();
            }

            Console.WriteLine($"{players[PlayerNo].Name} rolled a {roll}");
            int[] position = { players[PlayerNo].X, players[PlayerNo].Y };
            int direction = board[position[0], position[1]];
            switch (direction)
            {
                case (int)directions.right:
                    position[0] = position[0] + roll;
                    while (RocketInSquare(position[0], position[1]))
                    {
                        Bounce(position);
                    }
                    if (position[0] <= 7 && position[1] <= 7)
                    {
                        players[PlayerNo].X = position[0];
                        players[PlayerNo].Y = position[1];
                        if (CheesePowerSquare(position[0], position[1]))
                        {
                            int bottomPosition;
                            int CheesePowerAction = MethodLibraries.readInt("Do you want to Explode another players Engine (1) or Roll the Dice Again (2)? ", 1, 2);
                            if (CheesePowerAction == 1)
                            {
                                int PlayerToExplode = MethodLibraries.readInt($"Which Player would you like to explore (0-{numPlayers - 1})? ", 0, numPlayers - 1);
                                do
                                {
                                    bottomPosition = MethodLibraries.readInt($"{players[PlayerToExplode].Name}, which position would you like to move to (0-7)? ", 0, 7);
                                } while (RocketInSquare(0, bottomPosition));
                                players[PlayerToExplode].X = 0;
                                players[PlayerToExplode].Y = bottomPosition;
                            }
                            else
                            {
                                PlayerTurn(PlayerNo);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{players[PlayerNo].Name} rolled off the board, so didn't move.");
                    }
                    break;
                case (int)directions.up:
                    position[1] = position[1] + roll;
                    while (RocketInSquare(position[0], position[1]))
                    {
                        Bounce(position);
                    }
                    if (position[0] <= 7 && position[1] <= 7)
                    {
                        players[PlayerNo].X = position[0];
                        players[PlayerNo].Y = position[1];
                        if (CheesePowerSquare(position[0], position[1]))
                        {
                            int bottomPosition;
                            int CheesePowerAction = MethodLibraries.readInt("Do you want to Explode another players Engine (1) or Roll the Dice Again (2)? ", 1, 2);
                            if (CheesePowerAction == 1)
                            {
                                int PlayerToExplode = MethodLibraries.readInt($"Which Player would you like to explore (0-{numPlayers - 1})? ", 0, numPlayers - 1);
                                do
                                {
                                    bottomPosition = MethodLibraries.readInt($"{players[PlayerToExplode].Name}, which position would you like to move to (0-7)? ", 0, 7);
                                } while (RocketInSquare(0, bottomPosition));
                                players[PlayerToExplode].X = 0;
                                players[PlayerToExplode].Y = bottomPosition;
                            }
                            else
                            {
                                PlayerTurn(PlayerNo);
                            }
                        }
                    }
                    break;
                case (int)directions.down:
                    position[1] = position[1] - roll;
                    while (RocketInSquare(position[0], position[1]))
                    {
                        Bounce(position);
                    }
                    if (position[0] <= 7 && position[1] <= 7)
                    {
                        players[PlayerNo].X = position[0];
                        players[PlayerNo].Y = position[1];
                        if (CheesePowerSquare(position[0], position[1]))
                        {
                            int bottomPosition;
                            int CheesePowerAction = MethodLibraries.readInt("Do you want to Explode another players Engine (1) or Roll the Dice Again (2)? ", 1, 2);
                            if (CheesePowerAction == 1)
                            {
                                int PlayerToExplode = MethodLibraries.readInt($"Which Player would you like to explore (0-{numPlayers - 1})? ", 0, numPlayers - 1);
                                do
                                {
                                    bottomPosition = MethodLibraries.readInt($"{players[PlayerToExplode].Name}, which position would you like to move to (0-7)? ", 0, 7);
                                } while (RocketInSquare(0, bottomPosition));
                                players[PlayerToExplode].X = 0;
                                players[PlayerToExplode].Y = bottomPosition;
                            }
                            else
                            {
                                PlayerTurn(PlayerNo);
                            }
                        }
                    }
                    break;
                case (int)directions.left:
                    position[0] = position[0] - roll;
                    while (RocketInSquare(position[0], position[1]))
                    {
                        Bounce(position);
                    }
                    if (position[0] <= 7 && position[1] <= 7)
                    {
                        players[PlayerNo].X = position[0];
                        players[PlayerNo].Y = position[1];
                        if (CheesePowerSquare(position[0], position[1]))
                        {
                            int bottomPosition;
                            int CheesePowerAction = MethodLibraries.readInt("Do you want to Explode another players Engine (1) or Roll the Dice Again (2)? ", 1, 2);
                            if (CheesePowerAction == 1)
                            {
                                int PlayerToExplode = MethodLibraries.readInt($"Which Player would you like to explore (0-{numPlayers - 1})? ", 0, numPlayers - 1);
                                do
                                {
                                    bottomPosition = MethodLibraries.readInt($"{players[PlayerToExplode].Name}, which position would you like to move to (0-7)? ", 0, 7);
                                } while (RocketInSquare(0, bottomPosition));
                                players[PlayerToExplode].X = 0;
                                players[PlayerToExplode].Y = bottomPosition;
                            }
                            else
                            {
                                PlayerTurn(PlayerNo);
                            }
                        }
                    }
                    break;
                default:
                    //error
                    Console.WriteLine($"Player {PlayerNo} did not move.");
                    break;
            }

            if (position[0] == 7 && position[1] == 7)
            {
                gameOver = true;
                winner = PlayerNo;
            }

        }

        static bool RocketInSquare(int X, int Y)
        {
            for (int i = 0; i < numPlayers; i++)
            {
                if (X == players[i].X && Y == players[i].Y)
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        static void Bounce(int[] position)
        {
            int direction = board[position[0], position[1]];

            switch (direction)
            {
                case (int)directions.right:
                    position[0] = position[0] + 1;
                    while (RocketInSquare(position[0], position[1]))
                    {
                        Bounce(position);
                    }
                    break;
                case (int)directions.up:
                    position[1] = position[1] + 1;
                    while (RocketInSquare(position[0], position[1]))
                    {
                        Bounce(position);
                    }
                    break;
                case (int)directions.down:
                    position[1] = position[1] - 1;
                    while (RocketInSquare(position[0], position[1]))
                    {
                        Bounce(position);
                    }
                    break;
                case (int)directions.left:
                    position[0] = position[0] - 1;
                    while (RocketInSquare(position[0], position[1]))
                    {
                        Bounce(position);
                    }
                    break;
                default:
                    //error
                    Console.WriteLine("Player did not move.");
                    break;
            }

        }

        static void ShowStatus()
        {
            Console.WriteLine("Hyperspace Cheese Battle Status Report");
            Console.WriteLine("======================================");
            Console.WriteLine($"There are {players.Length} players in the game");

            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine($"{players[i].Name} is on square ({players[i].X},{players[i].Y})");
            }
            Console.WriteLine(" ");
        }

        static void MakeMoves()
        {
            for (int i = 0; i < numPlayers; i++)
            {
                PlayerTurn(i);
                if (gameOver)
                {
                    break;
                }
            }
            ShowStatus();

        }

        static bool CheesePowerSquare(int x, int y)
        {
            bool result = false;
            if (cheeseBoard[x, y] == true)
            {
                result = true;
            }
            return result;
        }

        static void Main(string[] args)
        {
            ResetGame();
            while (!gameOver)
            {
                MakeMoves();
                Console.Write("Press return for next turns");
                Console.ReadLine();
            }
            if (gameOver)
            {
                Console.WriteLine($"{players[winner].Name} has won the game!");
            }

        }
    }
}

using UnitMovement.TestModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitMovement
{
    class Program
    {
        Random rand = new Random();

        public Character[,] units = new Character[15,15];

        Spaces[,] grid = new Spaces[15, 15];

        int[] selected = new int[2];

        static void Main(string[] args)
        {
            (new Program()).Run();
        }

        public void Run()
        {
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    if (x == 14 && y == 9)
                    {
                        grid[x, y] = new Spaces();

                    }
                    else
                    {
                        //units[x, y] = new Character();
                        grid[x, y] = new Spaces();
                        grid[x, y].genChar();
                    }                    
                }
            }

            //for (int x = 0; x < 15; x++)
            //{
            //    for (int y = 0; y < 15; y++)
            //    {
            //        StartTurn(units[x, y]);
            //    }
            //}

            int[] moveTo = new int[2];
            moveTo[0] = 14;
            moveTo[1] = 9;

            int[] currentLocation = new int[2];
            currentLocation[0] = 0;
            currentLocation[1] = 0;

            MoveCharacter(grid[1, 2].c, currentLocation, moveTo);
        }


        public void StartTurn(Character player)
        {
            int squares = player.SquaresToMove;


        }

        public static int setCharacterInitiative()
        {
            Random rand = new Random();
            return rand.Next(1, 21);
        }

        public void MoveCharacter(Character player, int[] currentLocation, int[] moveTo)
        {
            //moveTo = new int[2];
            //moveTo[0] = 7;
            //moveTo[1] = 9;            

            int selectedX = moveTo[0];
            int selectedY = moveTo[1];

            if (grid[selectedX, selectedY].c != null)
            {
                Console.WriteLine("Square Occupied");
                return;
            }

            int currentX = currentLocation[0];
            int currentY = currentLocation[1];
            
            int xSquaresToMove = moveTo[0] - currentLocation[0];
            int ySquaresToMove = moveTo[1] - currentLocation[1];

            int xSquaresBeforeDiagonal = xSquaresToMove;
            int ySquaresBeforeDiagonal = ySquaresToMove;

            int diagonalSquaresThisTurn = 0;

            int squaresPerTurn = player.SquaresToMove;
            int currentlyAllowedSquares = squaresPerTurn;

            int attemptedSquaresToMove = 0;

            for (int i = 0; i < xSquaresBeforeDiagonal; i++)
            {
                if (ySquaresToMove > 0)
                {
                    --xSquaresToMove;
                    --ySquaresToMove;
                    ++diagonalSquaresThisTurn;
                }
            }

            for (int i = 1; i < diagonalSquaresThisTurn; i++)
            {
                if (i % 2 == 0)
                {
                    if ((attemptedSquaresToMove + 2) <= squaresPerTurn)
                    {
                        attemptedSquaresToMove += 2;
                        currentlyAllowedSquares -= 2;
                    }
                    else
                    {
                        int k = (diagonalSquaresThisTurn - i);

                        i = diagonalSquaresThisTurn;

                        xSquaresToMove += k;
                        ySquaresToMove += k;
                    }
                }
                else
                {
                    if ((attemptedSquaresToMove + 1) <= squaresPerTurn)
                    {
                        ++attemptedSquaresToMove;
                        currentlyAllowedSquares -= 1;
                    }
                    else
                    {
                        int k = (diagonalSquaresThisTurn - i);

                        i = diagonalSquaresThisTurn;                       

                        xSquaresToMove += k;
                        ySquaresToMove += k;

                    }
                }
            }

            if (currentlyAllowedSquares != 0 && xSquaresToMove > 0)
            {
                for (int i = xSquaresToMove; i > 0; i--)
                {
                    if (currentlyAllowedSquares > 0)
                    {
                        --xSquaresToMove;
                        --currentlyAllowedSquares;
                    }
                    else
                    {
                        i = 0;
                    }
                }
            }

            if (currentlyAllowedSquares != 0 && ySquaresToMove > 0)
            {
                for (int i = ySquaresToMove; i > 0; i--)
                {
                    if (currentlyAllowedSquares > 0)
                    {
                        --ySquaresToMove;
                        --currentlyAllowedSquares;
                    }
                    else
                    {
                        i = 0;
                    }
                }
            }

            if (xSquaresToMove == 0 && ySquaresToMove == 0)
            {
                grid[selectedX, selectedY].c = player;
                grid[currentX, currentY].c = null;

                Console.WriteLine("Move Successful");
            }
            else
            {
                Console.WriteLine("Impossible of movement");
            }

        }
    }
}
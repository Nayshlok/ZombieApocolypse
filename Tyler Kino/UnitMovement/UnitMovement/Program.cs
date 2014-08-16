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
        static Random rand = new Random();

        public Character[,] units = new Character[15,15];

        List<Spaces> characterList = new List<Spaces>();

        Spaces[,] grid = new Spaces[15, 15];

        int[] selected = new int[2];

        readonly int pickUpItem = 2;
        readonly int dropItem = 1;
        readonly int giveItem = 3;
        //Melee Attacks cost half total squares
        //Aimed Ranged Attacks cost ALL of the squares
        //Un-Aimed Ranged Attackes cost half total squares

        static void Main(string[] args)
        {
            (new Program()).Run();
        }

        #region run()
        public void Run()
        {
            int possible = 25;

            Console.WriteLine("Below is a list of all of the character's Initiative \n");

            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    grid[x, y] = new Spaces();

                    if (rand.Next(0, 2) == 1 && possible > 0)
                    {
                        grid[x, y].genChar(setCharacterInitiative());
                        --possible;
                    }                    
                }
            }

            //checkCharactersInitiatives();
            genTurns();

            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    if (grid[x, y].c != null)
                    {
                        Console.WriteLine(grid[x, y].c.Inititative);
                    }
                }
            }

            Console.WriteLine("\nList Below \n\n");

            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(characterList.ElementAt(i).c.Inititative); 
            }

            testDropItem();
            testPickupItem();
            testGiveItem();

        }
#endregion

        #region genTurns()
        public void genTurns()
        {            
            Spaces holder1;
            Spaces holder2;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (grid[i, j].c != null)
                    {
                        characterList.Add(grid[i, j]);  
                    }
                }
            }
            int times = 0;
            for (int s = 0; s < characterList.Count; s++ )
            {
                holder1 = characterList.ElementAt(s);
                for (int i = s + 1; i < characterList.Count; i++)
                {
                    holder2 = characterList.ElementAt(i);

                    if (i != s)
                    {
                        if (holder1.c.Inititative == holder2.c.Inititative)
                        {
                            if (rand.Next(0, 2) == 0)
                            {
                                characterList.Insert(s, holder2);
                                characterList.RemoveAt(i + 1);
                            }
                            else
                            {
                                characterList.Insert(s + 1, holder2);
                                characterList.RemoveAt(i + 1);
                                i = i - 1;
                                holder1 = characterList.ElementAt(s);
                            }
                        }
                        else if (holder1.c.Inititative < holder2.c.Inititative)
                        {
                            characterList.Insert(s, holder2);
                            characterList.RemoveAt(i + 1);
                            i = i - 1;

                            holder1 = characterList.ElementAt(s);
                        }
                    }
                    else
                    {
                        times++;
                        Console.WriteLine("Times: " + times);
                    }
                }
            }
        }
        #endregion

        #region StartTurn()
        public void StartTurn(Character player)
        {
            int squares = player.SquaresToMove;
        }
        #endregion

        #region setCharacterInitiative()
        public int setCharacterInitiative()
        {
            return rand.Next(1, 21);
        }
        #endregion

        #region checkCharacterInitiatives()
        public void checkCharactersInitiatives()
        {

            int[] used = new int[20];
            int count = 0;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (grid[i, j] != null && grid[i, j].c != null)
                    {
                        used[count] = grid[i, j].c.Inititative;
                        ++count;
                    }
                }
            }

            int current;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (grid[i, j] != null && grid[i, j].c != null)
                    {
                        current = grid[i, j].c.Inititative;
                        for (int k = 0; k < count - 1; k++)
                        {
                            if (current == used[k])
                            {
                                grid[i, j].c.Inititative = newInitiative(used);
                                used[k] = grid[i, j].c.Inititative;
                                k = count;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region newInitiative()
        public int newInitiative(int[] inits)
        {
            int newInit = rand.Next(1, 21);

            for (int i = 0; i < inits.Count(); i++)
            {
                if (newInit == inits[i])
                {
                    newInit = newInitiative(inits);
                }
            }

            return newInit;
        }
        #endregion

        #region MoveCharacter()
        public void MoveCharacter(Character player, int[] currentLocation, int[] moveTo)
        {      

            int selectedX = moveTo[0];
            int selectedY = moveTo[1];

            if (grid[selectedX, selectedY].c != null)
            {
                Console.WriteLine("Character at [" + currentLocation[0] + ", " + currentLocation[1] + "] Requested to \nmove to [" + moveTo[0] + ", " + moveTo[1] + "] which was an occupied square \n\n");
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

                Console.WriteLine("Character at [" + currentLocation[0] + ", " + currentLocation[1] + "] Requested to\n move to [" + moveTo[0] + ", " + moveTo[1] + "] and was granted the movement \n\n");

            }
            else
            {
                Console.WriteLine("Character at [" + currentLocation[0] + ", " + currentLocation[1] + "] Requested to\n move to [" + moveTo[0] + ", " + moveTo[1] + "] and was denied due to lack of squares possible per turn");
                Console.WriteLine("Squares per turn:" + player.SquaresToMove.ToString());
                Console.WriteLine("\n\n");
            }

        }
        #endregion

        #region DropItem()
        public void DropItem(Character player, bool isWeapon, int inventoryIndex, int[] square)
        {
            int currentlyAllowedSquares = player.SquaresToMove;
            Items item;

            if (currentlyAllowedSquares >= dropItem)
            {
                currentlyAllowedSquares -= dropItem;

                if (isWeapon)
                {
                    item = player.weapons[inventoryIndex];
                    player.weapons[inventoryIndex] = null;
                    grid[square[0], square[1]].itemList.Add(item);
                }
                else
                {
                    item = player.inventory.ElementAt(inventoryIndex);
                    player.inventory.RemoveAt(inventoryIndex);
                    grid[square[0], square[1]].itemList.Add(item);
                }
            }
            else
            {
                Console.WriteLine("Player Does not currently have enough squares to Drop Item at Index " + inventoryIndex);
            }
        }
        #endregion

        #region PickUpItem()
        public void PickUpItem(Character player, Items item, bool isWeapon, int[] square)
        {
            int currentlyAllowedSquares = player.SquaresToMove;

            if (currentlyAllowedSquares >= pickUpItem)
            {
                currentlyAllowedSquares -= pickUpItem;

                if (isWeapon)
                {
                    for (int i = 5; i > 0; i--)
                    {
                        if (i == 5 && player.weapons[4] != null)
                        {
                            return;
                        }
                        else if (i == 1)
                        {
                            player.weapons[0] = item;
                            grid[square[0], square[1]].itemList.Remove(item);
                            return;
                        }
                        else if (player.weapons[i - 1] == null)
                        {

                        }
                        else if (player.weapons[i - 1] != null)
                        {
                            player.weapons[i] = item;
                            grid[square[0], square[1]].itemList.Remove(item);
                            return;
                        }
                    }
                }
                else
                {
                    player.inventory.Add(item);
                    grid[square[0], square[1]].itemList.Remove(item);
                }
            }
        }
        #endregion

        #region GiveItem()
        public void GiveItem(Character giver, Character givee, int inventoryIndex, bool isWeapon)
        {
            Items item;
            int currentlyAllowedSquares = giver.SquaresToMove;

            if (currentlyAllowedSquares >= giveItem)
            {
                currentlyAllowedSquares -= giveItem;
                if (isWeapon)
                {
                    item = giver.weapons[inventoryIndex];
                    for (int i = 5; i > 0; i--)
                    {
                        if (i == 5 && givee.weapons[4] != null)
                        {
                            return;
                        }
                        else if (i == 1)
                        {
                            givee.weapons[0] = item;
                            giver.weapons[inventoryIndex] = null;
                            return;
                        }
                        else if (givee.weapons[i - 1] == null)
                        {

                        }
                        else if (givee.weapons[i - 1] != null)
                        {
                            givee.weapons[i] = item;
                            giver.weapons[inventoryIndex] = null;
                            return;
                        }
                    }
                }
                else
                {
                    item = giver.inventory.ElementAt(inventoryIndex);
                    givee.inventory.Add(item);
                    giver.inventory.RemoveAt(inventoryIndex);
                }
            }
            else
            {
                Console.WriteLine("The Giver does not have enought available squares to perform said action");
            }
        }
        #endregion

        #region MakeMeleeAttack()
        public void MakeMeleeAttack(Character player)
        {
            int totalSquares = player.SquaresToMove;
            int currentlyAvailableSquares = player.SquaresToMove;

            if ((totalSquares / 2) > currentlyAvailableSquares)
            {
                Console.WriteLine("Player does not have enough squares to perform this action");
            }
            else
            {
                currentlyAvailableSquares -= (totalSquares / 2);

                /*
                 * Kind of need david's logic in order to do this.  
                 * 
                 */
            }
        }
        #endregion

        #region MakeUn-AimedRangedAttack()
        public void MakeUnAimedRangeAttack(Character player)
        {
            int totalSquares = player.SquaresToMove;
            int currentlyAvailableSquares = player.SquaresToMove;

            if ((totalSquares / 2) > currentlyAvailableSquares)
            {
                Console.WriteLine("Player does not have enough squares to perform this action");
            }
            else
            {
                currentlyAvailableSquares -= (totalSquares / 2);

                /*
                 * Kind of need david's logic in order to do this.  
                 * 
                 */
            }
        }
        #endregion

        #region MakeAimedRangeAttack()
        public void MakeAimedRangeAttack(Character player)
        {
            int totalSquares = player.SquaresToMove;
            int currentlyAvailableSquares = player.SquaresToMove;

            if (totalSquares != currentlyAvailableSquares)
            {
                Console.WriteLine("Player does not have enough squares to perform this action");
            }
            else
            {
                currentlyAvailableSquares -= totalSquares;

                /*
                 * Kind of need david's logic in order to do this.  
                 * 
                 */
            }
        }
        #endregion

        public void testDropItem()
        {
            for (int i = 0; i < 15; i++)
            {
                if (grid[0, i].c != null)
                {
                    grid[0, i].c.weapons[0] = new Items { name = "pistol", damage = 10 };
                    int[] s = new int[2] { 0, i };
                    DropItem(grid[0, i].c, true, 0, s);

                    grid[0, i].c.inventory.Add(new Items { name = "Health Pack", damage = -6 });
                    DropItem(grid[0, i].c, false, 0, s);

                    if (grid[0, i].c.inventory.Count != 0)
                    {
                        Console.WriteLine("Character's Inventory List: " + grid[0, i].c.inventory.ElementAt(0).name);
                    }
                    if (grid[0, i].c.weapons[0] != null || grid[0, i].c.weapons[1] != null || grid[0, i].c.weapons[2] != null || grid[0, i].c.weapons[3] != null || grid[0, i].c.weapons[4] != null)
                    {
                        Console.WriteLine("Character's Inventory List: " + grid[0, i].c.weapons[0].name);
                    }
                    Console.WriteLine("\n\nSquare Item List: " + grid[0, i].itemList.ElementAt(0).name + "  -and-  " + grid[0, i].itemList.ElementAt(1).name);
                    return;
                }
            }

            Console.WriteLine("No Characters on first row?!");
        }

        public void testPickupItem()
        {

            for (int i = 0; i < 15; i++)
            {
                if (grid[0, i].c != null)
                {
                    grid[0, i].itemList.Clear();


                    grid[0, i].itemList.Add(new Items { name = "rifle", damage = 20 });
                    int[] s = new int[2]{0, i};
                    PickUpItem(grid[0, i].c, grid[0, i].itemList.ElementAt(0), true, s);
                    
                    grid[0, i].itemList.Add(new Items { name = "Health Pack", damage = -6 });
                    PickUpItem(grid[0, i].c, grid[0, i].itemList.ElementAt(0), false, s);

                    if (grid[0, i].itemList.Count != 0)
                    {
                        Console.WriteLine(" \n\nSquare Item List: " + grid[0, i].itemList.ElementAt(0).name);
                    }

                    Console.WriteLine("\n\nCharacter's Inventory List: " + grid[0, i].c.weapons[0].name + "  -and-  " + grid[0, i].c.inventory.ElementAt(0).name);

                    grid[0, i].c.weapons = new Items[5];
                    grid[0, i].c.inventory.Clear();
                    return;
                }
            }

            Console.WriteLine("No Characters on first row?!");
        }

        public void testGiveItem()
        {
            Character giver;
            Character givee;


            for (int i = 0; i < 15; i++)
            {
                if (grid[0, i].c != null)
                {
                    giver = grid[0, i].c;

                    for (int j = i + 1; j < 15; j++)
                    {
                        if (grid[0, j].c != null)
                        {
                            givee = grid[0, j].c;

                            giver.weapons[0] = new Items { name = "sniper", damage = 50 };
                            GiveItem(giver, givee, 0, true);

                            giver.inventory.Add(new Items { name = "MEDICAL kit", damage = -25 });
                            GiveItem(giver, givee, 0, false);

                            Console.WriteLine("\n\nCharacter's Inventory List: " + grid[0, j].c.weapons[0].name + "  -and-  " + grid[0, j].c.inventory.ElementAt(0).name);
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("There are not two people on the First row?!");
        }
    }
}
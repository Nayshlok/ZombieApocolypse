using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zombieApocalypse.Model;
using zombieApocalypse.Combat;

namespace zombieApocalypse
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Player player = new Player();
            player.Class = ClassType.Warrior;
            Dice statDice = new Dice(5, 6);
            player.PS = statDice.Roll();
            //player.PS = 30;
            player.PP = statDice.Roll();
            player.SPD = statDice.Roll();
            player.HP = statDice.Roll() + (new Dice(1, 6)).Roll();
            player.SDC = (new Dice(1, 10)).Roll() + 12;
            player.CanDodge = true;
            player.canParry = true;
            player.inventory.equippedWeapon = new SmallCrowbar();

            Zed zed = new Zed();
            zed.HP = rand.Next(16,21);
            zed.SDC = rand.Next(33,48);
            zed.PS = rand.Next(20, 30);
            zed.PP = rand.Next(2, 7);
            zed.SPD = 8;
            zed.Strike = 2;
            zed.canParry = true;
            zed.baseDamage = new Dice(1, 6);
            zed.ZedClass = ZedClass.Tank;
            
            Console.WriteLine("Player PP: " + player.PP + "; Player PS: " + player.PS);
            Console.WriteLine("Zed PP: " + zed.PP + "; Zed PS: " + zed.PS);
            Console.WriteLine("Player HP: " + player.HP + "; Player SDC: " + player.SDC);
            Console.WriteLine("Zed HP: " + zed.HP + "; Zed SDC: " + zed.SDC);
            Console.WriteLine();

            int playerWin = 0;
            int zedWin = 0;
            CombatManager manager = new CombatManager();
            for (int i = 0; i < 5; i++)
            {
                
                Console.WriteLine("Defender: Player HP: " + player.HP + "; Player SDC: " + player.SDC);
                Console.WriteLine("Attacker: Zed HP: " + zed.HP + "; Zed SDC: " + zed.SDC);
                manager.startCombat(zed, player);
                Console.WriteLine();

                Console.WriteLine("Attacker: Player HP: " + player.HP + "; Player SDC: " + player.SDC);
                Console.WriteLine("Defender: Zed HP: " + zed.HP + "; Zed SDC: " + zed.SDC);
                manager.startCombat(player, zed);
                Console.WriteLine();
                 /*/
                playerWin += (manager.startCombat(player, zed)) ? 1 : 0;
                zedWin += manager.startCombat(zed, player) ? 1 : 0;
                /**/
            }
            /*
            Console.WriteLine();
            Console.WriteLine("Player Success: " + playerWin);
            Console.WriteLine("Zed Success: " + zedWin);
            */
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalypseSimulator
{
    class Program
    {
        public void printPlayer(Player character)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Player:\n\t" +
                "HP: " + character.HP + "\n\t" +
                "SCD: " + character.SCD + "\n\t" +
                "PS: " + character.PS + "\n\t" +
                "PE: " + character.PE + "\n\t" +
                "IQ: " + character.IQ + "\n\t" +
                "ME: " + character.ME + "\n\t" +
                "MA: " + character.MA + "\n\t" +
                "PB: " + character.PB + "\n\t" +
                "SPD: " + character.SPD + "\n\t" +
                "Strike: " + character.Strike + "\n\t" +
                "Dodge: " + character.Dodge + "\n\t" +
                "Parry: " + character.Parry + "\n\t" +
                "Squares to move: " + character.SquaresToMove + "\n\t" +
                "Name " + character.Name + "\n\t" +
                "Is living: " + character.IsLiving + "\n\t" +
                "Can Dodge: " + character.CanDodge + "\n\t" +
                "Can Parry: " + character.CanParry + "\n\n\t" +
                "Player class: " + character.PlayerClass + "\n\t" +
                "inventory: " + character.inventory + "\n\t" +
                "Zombify chance: " + character.ZombifyChance + "%\n\t" +
                "Money: " + character.Money + "\n\t" +
                "Initiative: " + character.Initiative + "\n\t" +
                "Armor rating: " + character.AR);
            Console.ResetColor();
        }

        public void printZed(Zed character)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Zed:\n\t" +
                "HP: " + character.HP + "\n\t" +
                "SCD: " + character.SCD + "\n\t" +
                "PS: " + character.PS + "\n\t" +
                "PE: " + character.PE + "\n\t" +
                "IQ: " + character.IQ + "\n\t" +
                "ME: " + character.ME + "\n\t" +
                "MA: " + character.MA + "\n\t" +
                "PB: " + character.PB + "\n\t" +
                "SPD: " + character.SPD + "\n\t" +
                "Strike: " + character.Strike + "\n\t" +
                "Dodge: " + character.Dodge + "\n\t" +
                "Parry: " + character.Parry + "\n\t" +
                "Squares to move: " + character.SquaresToMove + "\n\t" +
                "Name " + character.Name + "\n\t" +
                "Is living: " + character.IsLiving + "\n\t" +
                "Can Dodge: " + character.CanDodge + "\n\t" +
                "Can Parry: " + character.CanParry + "\n\n\t" +
                "Zed Class: " + character.ZedClass + "\n\t" +
                "Base Damage: " + character.BaseDamage + "%\n\t" +
                "Drop item: " + character.DropItem + "\n\t" +
                "Money value: " + character.MoneyValue + "\n\t" +
                "Armor rating: " + character.AR);
            Console.ResetColor();
        }


        static void Main(string[] args)
        {
            Program test = new Program();

            Warrior warrior = new Warrior("PLAYER_TEST");
            test.printPlayer(warrior);
            Console.WriteLine();

            SharpShooter shooter = new SharpShooter("PLAYER_TEST");
            test.printPlayer(shooter);
            Console.WriteLine();

            Survivalist survivor = new Survivalist("PLAYER_TEST");
            test.printPlayer(survivor);
            Console.WriteLine();

            Sloucher sloucher = new Sloucher("ZED_TEST");
            test.printZed(sloucher);
            Console.WriteLine();

            FastAttack fastattack = new FastAttack("ZED_TEST");
            test.printZed(fastattack);
            Console.WriteLine();

            Tank tank = new Tank("ZED_TEST");
            test.printZed(tank);
            Console.WriteLine();

            Shank shank = new Shank("ZED_TEST");
            test.printZed(shank);
            Console.WriteLine();

            Spitter spitter = new Spitter("ZED_TEST");
            test.printZed(spitter);
            Console.WriteLine();
        }
    }
}

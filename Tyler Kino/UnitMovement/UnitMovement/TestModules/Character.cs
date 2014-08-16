using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitMovement.TestModules
{
    class Character
    {

        public int HP;
        public int SDC;
        public int PS;
        public int PP;
        public int PE;
        public int IQ;
        public int ME;
        public int MA;
        public int PB;
        public int SPD;
        public int Strike;
        public int Dodge = 1;
        public int Parry = 1;
        public string Name;
        public int SquaresToMove;
        public bool IsLiving = true;
        public bool CanDodge = true;
        public bool CanParry = true;
        public int zombifyChance = 5;
        public int Inititative;
        static Random rand = new Random();
        public Items[] weapons = new Items[5];
        public List<Items> inventory = new List<Items>();

        public Character()
        {
            

            SPD = rand.Next(1, 20);
            IQ = rand.Next(1, 20);
            ME = rand.Next(1, 20);
            MA = rand.Next(1, 20);
            PS = rand.Next(1, 20);
            PE = rand.Next(1, 20);
            PP = rand.Next(1, 20);
            PB = rand.Next(1, 20);
            HP = rand.Next(1, 20);
            SDC = rand.Next(1, 20);
            Strike = rand.Next(1, 20);            

            SquaresToMove = ((SPD * 5) / 4);
        }

    }
}

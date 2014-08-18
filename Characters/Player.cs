using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalypseSimulator
{
    enum ClassPlayer
    {
        Warrior,
        Sharp_Shooter,
        Survivalist
    }

    class Player:Character
    {
        private ClassPlayer _PlayerClass;
        public ClassPlayer PlayerClass
        {
            get { return _PlayerClass; }
            set { _PlayerClass = value; }
        }

        private Inventory _Inventory;
        public Inventory inventory
        {
            get { return _Inventory; }
            set { _Inventory = value; }
        }
        private int _ZombifyChance;
        public int ZombifyChance
        {
            get { return _ZombifyChance; }
            set { _ZombifyChance = value; }
        }

        private int _Money;
        public int Money
        {
            get { return _Money; }
            set { _Money = value; }
        }

        public Player(string name):base(name)
        {

        }
    }
}

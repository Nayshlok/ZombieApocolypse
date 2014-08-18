using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalypseSimulator
{
    enum ClassZed
    {
        Sloucher,
        Fast_Attack,
        Tank,
        Shank,
        Spitter
    }

    class Zed:Character
    {
        private Random rand= new Random();

        private ClassZed _ZedClass;
        public ClassZed ZedClass
        {
            get { return _ZedClass; }
            set { _ZedClass = value; }
        }

        private int _BaseDamage;
        public int BaseDamage
        {
            get { return _BaseDamage; }
            set { _BaseDamage = value; }
        }

        private Item _DropItem;
        public Item DropItem
        {
            get { return _DropItem; }
            set { _DropItem = value; }
        }

        private int _MoneyValue;
        public int MoneyValue
        {
            get { return _MoneyValue; }
            set { _MoneyValue = value; }
        }
        
        public Zed(string name):base(name)
        {
            base.IQ = 0;
            base.MA = 0;
            base.ME = 0;
        }
    }
}

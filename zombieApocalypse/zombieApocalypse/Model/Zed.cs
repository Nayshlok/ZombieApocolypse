using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombieApocalypse.Model
{
    public enum ZedClass
    {
        Spitter, Shank, Tank, other
    }

    class Zed : Character
    {
        public Dice baseDamage { get; set; }
        public ZedClass ZedClass { get; set; }


    }
}

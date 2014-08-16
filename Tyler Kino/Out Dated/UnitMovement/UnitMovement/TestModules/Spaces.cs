using UnitMovement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitMovement.TestModules
{
    class Spaces
    {
        public Character c;
        List<Items> itemList = new List<Items>();

        public Spaces()
        {            
            itemList.Add(new Items());
        }

        public void genChar()
        {
            c = new Character();
            c.Inititative = UnitMovement.Program.setCharacterInitiative();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombieApocalypse.Model
{
    class Character
    {
        public int HP { get; set; }
        public int SDC { get; set; }
        public int PS { get; set; }
        public int PP { get; set; }
        public int SPD { get; set; }
        public int Strike { get; set; }
        public bool CanDodge { get; set; }
        public bool canParry { get; set; }
    }
}

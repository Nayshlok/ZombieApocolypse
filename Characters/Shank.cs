﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalypseSimulator
{
    class Shank:Zed
    {
        public Shank(string name):base(name)
        {
            ZedClass = ClassZed.Shank;
            Strike += 3;
            Parry += 3;
            Dodge += 3;
            Initiative -= 1;
            PS = DummyDice(24, min: 19);
            PP = DummyDice(15, min: 10);
            PE = DummyDice(21, min: 16);
            SPD = DummyDice(20, min: 12);
            BaseDamage = DummyDice(6, 2) + PS;
            SCD = DummyDice(20, min: 30);
            HP = DummyDice(20, min: 15);
            MoneyValue = DummyDice(20, min: 10);
        }
    }
}

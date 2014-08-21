﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalypseSimulator
{
    public class Character
    {

        private int _HP;
        public int HP
        {
            get { return _HP; }
            set { _HP = value; }
        }
        
        private int _SCD;
        public int SCD
        {
            get { return _SCD; }
            set { _SCD = value; }
        }

        private int _PS;
        public int PS
        {
            get { return _PS; }
            set { _PS = value; }
        }

        private int _PP;
        public int PP
        {
            get { return _PP; }
            set { _PP = value; }
        }

        private int _PE;
        public int PE
        {
            get { return _PE; }
            set { _PE = value; }
        }

        private int _IQ;
        public int IQ
        {
            get { return _IQ; }
            set { _IQ = value; }
        }
        
        private int _ME;
        public int ME
        {
            get { return _ME; }
            set { _ME = value; }
        }

        private int _MA;
        public int MA
        {
            get { return _MA; }
            set { _MA = value; }
        }

        private int _PB;
        public int PB
        {
            get { return _PB; }
            set { _PB = value; }
        }

        private int _SPD;
        public int SPD
        {
            get { return _SPD; }
            set { _SPD = value; }
        }

        private int _Strike;
        public int Strike
        {
            get { return _Strike; }
            set { _Strike = value; }
        }

        private int _Dodge;
        public int Dodge
        {
            get { return _Dodge; }
            set { _Dodge = value; }
        }

        private int _Parry;
        public int Parry
        {
            get { return _Parry; }
            set { _Parry = value; }
        }

        private int _SquaresToMove;
        public int SquaresToMove
        {
            get { return _SquaresToMove; }
            set { _SquaresToMove = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private bool _IsLiving;
        public bool IsLiving
        {
            get { return _IsLiving; }
            set { _IsLiving = value; }
        }

        private bool _CanDodge;
        public bool CanDodge 
        {
            get { return _CanDodge; }
            set { _CanDodge = value; }
        }

        private bool _CanParry;
        public bool CanParry
        {
            get { return _CanParry; }
            set { _CanParry = value; }
        }

        private int _AR;
        public int AR
        {
            get { return _AR; }
            set { _AR = value; }
        }

        private int _Initiative;
        public int Initiative
        {
            get { return _Initiative; }
            set { _Initiative = value; }
        }

        private bool _canDodge;
        public bool canDodge
        {
            get { return _canDodge; }
            set { _canDodge = value; }
        }

        private bool _canParry;
        public bool canParry
        {
            get { return _canParry; }
            set { _canParry = value; }
        }

        public override string ToString()
        {
            return Name + ": HP = " + HP + ", SDC = " + SCD;
        }

        private Random rand = new Random();
        public int DummyDice(int max, int numb = 1, int min = 0)
        {
            int temp = 0;
            int temp2 = 0;
            int result = 0;

            for (int i = 0; i < numb; i++)
            {
                temp = rand.Next(min, max + 1);
                result += temp; ;
            }
            if (result.Equals(16) || result.Equals(17) || result.Equals(18))
            {
                temp2 = rand.Next(1, 7);
                if (temp2.Equals(6))
                {
                    temp2 += rand.Next(1, 7);
                }
                result += temp2;
            }
            return result;
        }

        public Character(string name)
        {
            SCD = DummyDice(6, 3);
            PS = DummyDice(6, 3);
            PP = DummyDice(6, 3);
            PE = DummyDice(6, 3);
            HP = PE + DummyDice(6, 3);
            IQ = DummyDice(6, 3);
            ME = DummyDice(6, 3);
            MA = DummyDice(6, 3);
            PB = DummyDice(6, 3);
            SPD = DummyDice(6, 3);
            Strike = DummyDice(6, 3);
            Dodge = DummyDice(6, 3);
            Parry = DummyDice(6, 3);
            SquaresToMove = DummyDice(6, 3);
            Name = name;
            IsLiving = true;
            CanDodge = false;
            CanParry = false;
            AR = 14;
            Initiative = DummyDice(6, 3);
        }
    }
}

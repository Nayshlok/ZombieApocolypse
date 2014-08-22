using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CedenoB_ZombieGame.Testing_other_things;

namespace ZombieApocalypseSimulator.Model
{
   public class Character : Entity
    {
		private int _IQ, _ME, _MA, _PS, _PE, _PP, _PB, _SPD, _currentHP, _currentSDC, _baseHP, _baseSDC, _actionPoints, _baseActionPoints;

		public bool IsAlive { get; set; }
		public int IQ
		{
			get { return _IQ; }
			set
			{
				_IQ = value;
				OnPropertyChanged("IQ");
			}
		}
		public int ME
		{
			get { return _ME; }
			set
			{
				_ME = value;
				OnPropertyChanged("ME");
			}
		}
		public int MA
		{
			get { return _MA; }
			set
			{
				_MA = value;
				OnPropertyChanged("MA");
			}
		}
		public int PS
		{
			get { return _PS; }
			set
			{
				_PS = value;
				OnPropertyChanged("PS");
			}
		}
		public int PE
		{
			get { return _PE; }
			set
			{
				_PE = value;
				OnPropertyChanged("PE");
				SetHP();
			}
		}
		public int PP
		{
			get { return _PP; }
			set
			{
				_PP = value;
				OnPropertyChanged("PP");
			}
		}
		public int PB
		{
			get { return _PB; }
			set
			{
				_PB = value;
				OnPropertyChanged("PB");
			}
		}
		public int SPD
		{
			get { return _SPD; }
			set
			{
				_SPD = value;
				OnPropertyChanged("SPD");
				ResetActionPoints();
			}
		}

		public bool HasDodged { get; set; }
		public bool HasParried { get; set; }

		protected int toHit, damage = 0;
		/// <summary>
		/// ActionPoints are also known as the movement squares specified in the requirements
		/// </summary>
		public int ActionPoints
		{
			get { return _actionPoints; }
			set
			{
				_actionPoints = value;
				OnPropertyChanged("ActionPoints");
			}
		}
		public int BaseActionPoints
		{
			get { return _baseActionPoints; }
			set
			{
				_baseActionPoints = value;
				OnPropertyChanged("BaseActionPoints");
			}
		}
		public int MeleeBonusDamage { get; set; }
		public int CurrentHP
		{
			get { return _currentHP; }
			set
			{
				_currentHP = value;
				OnPropertyChanged("CurrentHP");
				if (CurrentHP <= 0)
					DummyDice(6, 1);
			}
		}
		public int CurrentSDC
		{
			get { return _currentSDC; }
			set
			{
				_currentSDC = value;
				OnPropertyChanged("CurrentSDC");
			}
		}
		public int BaseHP
		{
			get { return _baseHP; }
			set
			{
				_baseHP = value;
				OnPropertyChanged("BaseHP");
			}
		}
		public int BaseSDC
		{
			get { return _baseSDC; }
			set
			{
				_baseSDC = value;
				OnPropertyChanged("BaseSDC");
			}
		}

		public Inventory Inventory;


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
            BaseSDC = DummyDice(6, 3);
            PS = DummyDice(6, 3);
            PP = DummyDice(6, 3);
            PE = DummyDice(6, 3);
            BaseHP = PE + DummyDice(6, 3);
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
            HasDodged = false;
            HasParried = false;
            AR = 14;
            Initiative = DummyDice(6, 3);
        }



		public void SetHP()
		{
			BaseHP = PE + DummyDice(6, 3);
			CurrentHP = BaseHP;
		}

		public void SetSDC()
		{
			BaseSDC = DummyDice(6, 3) + 12;
			CurrentSDC = BaseSDC;
		}


		public int getBaseHP()
		{
			return BaseHP;
		}

		public int getBaseSDC()
		{
			return BaseSDC;
		}
       
		/// <summary>
		/// Methods to calculate the base stats and damage
		/// of newly created characters.
		/// </summary>
		/// <returns></returns>
		#region BaseCalculationMethods

		private int CalcBonusDamage()
		{
			int num = PS - 15;
			if (num > 0)
				return num;
			else
				return 0;
		}

		private int CalcPDSBonus()
		{
			double tmp = PE / 2;
			return (int)(Math.Round(tmp, MidpointRounding.AwayFromZero));
		}

		public void ResetActionPoints()
		{
			ActionPoints = (_SPD * 5) / 4;
			BaseActionPoints = (_SPD * 5) / 4;
		}
		#endregion
    }
}

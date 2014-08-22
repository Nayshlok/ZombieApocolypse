﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using ZombieApocalypseSimulator;
using zombieApocalypse.Combat;
using CedenoB_ZombieGame.Model;


namespace CedenoB_ZombieGame
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 

	public partial class MainWindow : Window
	{
		Square[,] GameBoard;

        public int stageHeight { get; set; }
        public int stageWidth { get; set; }
        private Character attacker;
        private Character defender;
        public int FirstX { get; set; }
        public int FirstY { get; set; }
        public int SecondX { get; set; }
        public int SecondY { get; set; }
        private double CellWidth { get; set; }
        private double CellHeight { get; set; }
        private Grid battleView;
        private CombatManager combatManager;

		public MainWindow()
		{
            combatManager = new CombatManager();
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.SourceInitialized += (s, a) => this.WindowState = WindowState.Maximized;
            this.DataContext = this;
			SetupEntityGrid();
		}

		private void SetupEntityGrid()
		{
			GameUniformGrid.Children.Clear();
			GameBoard = new Square[25, 25];

			for (int x = 0; x < 25; x++)
			{
				for (int y = 0; y < 25; y++)
				{
                    Square r = new Square(AddCharacter, x, y);
                    r.Background = new SolidColorBrush(Color.FromArgb(255, 225, 225, 255));
                    GameBoard[x, y] = r;
					GameBoard[x, y].Margin = new Thickness(1);
					GameUniformGrid.Children.Add(GameBoard[x, y]);

				}
			}
		}

        public Coordinate FindCharacter(Character character)
        {
            for (int i = 0; i < 25; i++)
            {
                for(int j = 0; j < 25 j++)
                {
                    if(GameBoard[i, j].Token == character)
                    {
                        return new Coordinate(i, j);
                    }
                }
            }
            return null;
        }

        public void AddCharacter(Character character, int x, int y)
        {
            if (character != null)
            {
                if (attacker == null || (attacker != null && defender != null))
                {
                    FirstX = x;
                    FirstY = y;
                    attacker = character;
                    defender = null;
                }
                else if (attacker != null && defender == null)
                {
                    SecondX = x;
                    SecondY = y;
                    defender = character;
                }
            }
        }

        private void testButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (attacker != null && defender != null && combatManager != null)
            {
                BuildGrid(combatManager.startCombat(attacker, defender));
            }
            else
            {
                GameGrid.Children.Remove(battleView);
            }
        }

        #region CombatGUI
        private void BuildGrid(CombatResults results)
        {
            CellHeight = GameGrid.ActualHeight / 25;
            CellWidth = GameGrid.ActualWidth / 25;
            Grid combatView = new Grid();
            combatView.RowDefinitions.Add(new RowDefinition());
            combatView.RowDefinitions.Add(new RowDefinition());
            combatView.RowDefinitions.Add(new RowDefinition());
            combatView.RowDefinitions.Add(new RowDefinition());
            combatView.ColumnDefinitions.Add(new ColumnDefinition());
            combatView.ColumnDefinitions.Add(new ColumnDefinition());
            combatView.ColumnDefinitions.Add(new ColumnDefinition());
            combatView.ColumnDefinitions.Add(new ColumnDefinition());
            combatView.Background = new SolidColorBrush(Colors.Wheat);
            //Attacker and Defender Labels
            Label AttackerLabel = new Label();
            AttackerLabel.Content = "Attacker";
            Grid.SetColumnSpan(AttackerLabel, 2);
            combatView.Children.Add(AttackerLabel);
            Label DefenderLabel = new Label();
            DefenderLabel.Content = "Defender";
            Grid.SetColumn(DefenderLabel, 2);
            Grid.SetColumnSpan(DefenderLabel, 2);
            combatView.Children.Add(DefenderLabel);
            //Name Labels
            Label AttackerName = new Label();
            AttackerName.Content = attacker.Name;
            Grid.SetColumnSpan(AttackerName, 2);
            Grid.SetRow(AttackerName, 1);
            combatView.Children.Add(AttackerName);
            Label DefenderName = new Label();
            DefenderName.Content = defender.Name;
            Grid.SetColumn(DefenderName, 2);
            Grid.SetColumnSpan(DefenderName, 2);
            Grid.SetRow(DefenderName, 1);
            combatView.Children.Add(DefenderName);
            //AttackRoll DefendRoll
            if (!results.Allies)
            {
                Label AttackRollLabel = new Label();
                AttackRollLabel.Content = "Attack Roll";
                Grid.SetRow(AttackRollLabel, 2);
                combatView.Children.Add(AttackRollLabel);
                Label AttackRoll = new Label();
                AttackRoll.Content = results.AttackRoll;
                if (results.AttackCrit)
                {
                    AttackRollLabel.Background = new SolidColorBrush(Colors.Green);
                    AttackRoll.Background = new SolidColorBrush(Colors.Green);
                }
                if (results.AttackFail)
                {
                    AttackRollLabel.Background = new SolidColorBrush(Colors.Red);
                    AttackRoll.Background = new SolidColorBrush(Colors.Red);
                }
                Grid.SetRow(AttackRoll, 2);
                Grid.SetColumn(AttackRoll, 1);
                combatView.Children.Add(AttackRoll);
                if (results.AttackHit)
                {
                    Label DefendRollLabel = new Label();
                    DefendRollLabel.Content = results.DefenseType;
                    Grid.SetColumn(DefendRollLabel, 2);
                    Grid.SetRow(DefendRollLabel, 2);
                    combatView.Children.Add(DefendRollLabel);
                    Label DefendRoll = new Label();
                    DefendRoll.Content = results.DefendRoll;
                    if (results.DefendCrit)
                    {
                        DefendRollLabel.Background = new SolidColorBrush(Colors.Green);
                        DefendRoll.Background = new SolidColorBrush(Colors.Green);
                    }
                    if (results.DefendFail)
                    {
                        DefendRollLabel.Background = new SolidColorBrush(Colors.Red);
                        DefendRoll.Background = new SolidColorBrush(Colors.Red);
                    }
                    Grid.SetColumn(DefendRoll, 3);
                    Grid.SetRow(DefendRoll, 2);
                    combatView.Children.Add(DefendRoll);
                    if (results.Damage != 0)
                    {
                        Label DamageDoneLabel = new Label();
                        DamageDoneLabel.Content = "Damage";
                        Grid.SetRow(DamageDoneLabel, 3);
                        combatView.Children.Add(DamageDoneLabel);
                        Label DamageDone = new Label();
                        DamageDone.Content = results.Damage;
                        Grid.SetColumn(DamageDone, 2);
                        Grid.SetRow(DamageDone, 3);
                        combatView.Children.Add(DamageDone);
                    }
                    else
                    {
                        Label SuccessDefend = new Label();
                        SuccessDefend.Content = "Successfully Defended Attack";
                        Grid.SetRow(SuccessDefend, 3);
                        Grid.SetColumnSpan(SuccessDefend, 4);
                        combatView.Children.Add(SuccessDefend);
                    }
                }
                else
                {
                    Label AttackMiss = new Label();
                    AttackMiss.Content = attacker.Name + " missed";
                    Grid.SetRow(AttackMiss, 3);
                    Grid.SetColumnSpan(AttackMiss, 4);
                    combatView.Children.Add(AttackMiss);
                }
            }
            else
            {
                Label FriendlyMessage = new Label();
                FriendlyMessage.Content = results.Message;
                Grid.SetRow(FriendlyMessage, 2);
                Grid.SetColumnSpan(FriendlyMessage, 4);
                combatView.Children.Add(FriendlyMessage);
            }
            //Add grid to canvas at location, wait 3 seconds and close
            Canvas.SetTop(combatView, (CellHeight * (FirstX + 1)));
            Canvas.SetLeft(combatView, (CellWidth * (FirstY)));
            GameGrid.Children.Add(combatView);

            if(GameGrid.Children.Contains(battleView))
            {
                GameGrid.Children.Remove(battleView);
            }
            battleView = combatView;
        }
        #endregion


    }
}



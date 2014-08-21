using System;
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

		public MainWindow()
		{
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
            if (attacker != null && defender != null)
            {
                BuildGrid();
            }
            else
            {
                MessageBox.Show("Attacker: " + attacker + "\n" + "Defender: " + defender);
                GameGrid.Children.Remove(battleView);
            }
        }

        #region CombatGUI
        private void BuildGrid()
        {
            CellHeight = GameGrid.ActualHeight / 25;
            CellWidth = GameGrid.ActualWidth / 25;
            Grid combatView = new Grid();
            combatView.RowDefinitions.Add(new RowDefinition());
            combatView.RowDefinitions.Add(new RowDefinition());
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
            Label DefenderLabel = new Label();
            DefenderLabel.Content = "Defender";
            Grid.SetColumn(DefenderLabel, 2);
            Grid.SetColumnSpan(DefenderLabel, 2);
            //Name Labels
            Label AttackerName = new Label();
            AttackerName.Content = attacker.Name;
            Grid.SetColumnSpan(AttackerName, 2);
            Grid.SetRow(AttackerName, 1);
            Label DefenderName = new Label();
            DefenderName.Content = defender.Name;
            Grid.SetColumn(DefenderName, 2);
            Grid.SetColumnSpan(DefenderName, 2);
            Grid.SetRow(DefenderName, 1);

            //Add Components to grid
            combatView.Children.Add(AttackerLabel);
            combatView.Children.Add(DefenderLabel);
            combatView.Children.Add(AttackerName);
            combatView.Children.Add(DefenderName);

            //Add grid to canvas at location, wait 3 seconds and close
            Canvas.SetLeft(combatView, (CellWidth * (FirstX + 1)));
            Canvas.SetTop(combatView, (CellHeight * (FirstY + 1)));
            GameGrid.Children.Add(combatView);

            if(GameGrid.Children.Contains(battleView))
            {
                GameGrid.Children.Remove(battleView);
            }
            battleView = combatView;
        }
        #endregion

        private void GameGrid_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

        }
    }
}



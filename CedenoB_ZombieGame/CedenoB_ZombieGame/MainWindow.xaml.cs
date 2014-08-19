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
					Square r = new Square { Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)) };
                    GameBoard[x, y] = r;
					GameBoard[x, y].Margin = new Thickness(1);
					GameUniformGrid.Children.Add(GameBoard[x, y]);

				}
			}
		}
    }
}



using CedenoB_ZombieGame.Testing_other_things;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CedenoB_ZombieGame.View
{
	/// <summary>
	/// Interaction logic for CharacterCreator.xaml
	/// </summary>
	public partial class CharacterCreator : UserControl
	{
		private MainWindow mainWindow;

		  ObservableCollection<Clock> clocks = new ObservableCollection<Clock>();

		public CharacterCreator()
		{
			InitializeComponent();

			 clocks = new ObservableCollection<Clock>
            {
                new Clock { Item = "Gun"}
            };

           // mainPanel.DataContext = clocks;
			MainGrid.DataContext = clocks;
            //mainDataGrid.ItemsSource = clocks;
        }

        private void changeCollectionButton_Click(object sender, RoutedEventArgs e)
        {
			Clock clock = new Clock { Item = "Gun" };
           // clocks.Add(clock);
        }

		public CharacterCreator(MainWindow mainWindow)
		{
			// TODO: Complete member initialization
			this.mainWindow = mainWindow;
		}

		private void ClassComboBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{

		}

		private void ClassComboBox_MouseLeave(object sender, MouseEventArgs e)
		{

		}

		private void ClassComboBox_MouseEnter(object sender, MouseEventArgs e)
		{

		}

		private void PlayerTypeComboBox_MouseEnter(object sender, MouseEventArgs e)
		{

		}

		private void PlayerTypeComboBox_MouseLeave(object sender, MouseEventArgs e)
		{

		}

		private void PlayerTypeComboBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{

		}

		private void ClassComboBox_MouseEnter_1(object sender, MouseEventArgs e)
		{

		}

		private void PlayerTypeComboBox_MouseEnter_1(object sender, MouseEventArgs e)
		{

		}

		private void PlayerTypeComboBox_MouseLeave_1(object sender, MouseEventArgs e)
		{

		}

		private void PlayerTypeComboBox_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
		{

		}

		private void AddItemButton_Click(object sender, RoutedEventArgs e)
		{
		//	Clock clock = new Clock { CurrentTime = "12:00", HasNumbers = true, Manufacturer = "Swiss", NumberOfHands = 0 };
		}

		private void PlayerNameBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
	}
}

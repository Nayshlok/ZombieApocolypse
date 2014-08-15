using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Shop.CodeTest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string messageBoxText;
        string caption;
        MessageBoxButton button;
        MessageBoxImage icon;
        MessageBoxResult result;
        public Window1()
        {
            InitializeComponent();
            Player Billy = new Player("1000", 5, "Billy");
            Player Mario = new Player("2300", 28, "Mario");
            Player CJ = new Player("10000", 15, "CJ");
            Player Link = new Player("30", 20, "Link");
            ObservableCollection<Player> playerlist = new ObservableCollection<Player>
           {
               Billy,
               Mario,
               CJ,
               Link
           };

            playChoices.ItemsSource = playerlist;
        }

        private void openShop_Click(object sender, RoutedEventArgs e)
        {
            sender = playChoices.SelectedItem;
            if (sender != null)
            {
                var newWindow = new MainWindow((Player)sender);
                newWindow.Show();
            }
            else
                MessageBox.Show("Please select a character!");
        }

        private void playChoices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            messageBoxText = "Open the shop for player " + ((Player)playChoices.SelectedItem).name + "?";
            caption = "Open Shop";
            button = MessageBoxButton.YesNo;
            icon = MessageBoxImage.Warning;
            result = MessageBox.Show(messageBoxText, caption, button, icon);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    openShop_Click(sender, e);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}

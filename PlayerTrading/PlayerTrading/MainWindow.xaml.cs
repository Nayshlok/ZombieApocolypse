using PlayerTrading.CodeTest;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace PlayerTrading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        Player playerLeft, playerRight;
        Items item;
        string messageBoxText, caption;
        MessageBoxButton button;
        MessageBoxImage icon;
        MessageBoxResult result;
        List<Items> selectedItemIndexes;
        int initialval, invcheck;
        #endregion

        #region Main
        public MainWindow(Player passedInLeft, Player passedInRight)
        {
            InitializeComponent();
            playerLeft = passedInLeft;
            playerRight = passedInRight;
            playerNameLeft.DataContext = playerLeft;
            playerNameRight.DataContext = playerRight;
            playerItemsLeft.ItemsSource = playerLeft.currentItems;
            playerItemsRight.ItemsSource = playerRight.currentItems;

            GiveToLeftName.Content = "Give to " + passedInLeft.name;
            GiveToRightName.Content = "Give to " + passedInRight.name;
        }
        #endregion

        #region PlayerLeftGiveAway
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            item = ((Items)playerItemsLeft.SelectedItem);

            if (playerRight.currentItems.Count <= 9 && playerRight.currentItems.Count >= 0)
            {
                if (item != null)
                {
                        playerRight.addToInventory(item);
                        playerLeft.removeFromInventory((byte)playerItemsLeft.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("Left, what are you giving?");
                }
            }
            else
            {
                MessageBox.Show("Sorry, your inventory is full!");
            }
        }
        #endregion

        #region PlayerRightGiveAway
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (playerLeft.currentItems.Count <= 9 && playerLeft.currentItems.Count >= 0)
            {
                for (int i = 0; i < playerItemsRight.SelectedItems.Count; i++)
                {
                    if (playerItemsRight.SelectedItems[i] != null)
                    {
                        playerLeft.addToInventory((Items)playerItemsRight.SelectedItems[i]);
                        playerRight.removeFromInventory((byte)playerItemsRight.SelectedIndex);

                    }
                    else
                    {
                        MessageBox.Show("Right, what are you giving?");
                    }
                }
            }
            else
            {
                MessageBox.Show("Sorry, your inventory is full!");
            }

        }
        #endregion

        #region DoubleClickGiveLeft
        private void playerItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            messageBoxText = "Are you sure you want to give this item?";
            caption = "Give Item";
            button = MessageBoxButton.YesNo;
            icon = MessageBoxImage.Warning;
            result = MessageBox.Show(messageBoxText, caption, button, icon);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    Button_Click(sender, e);
                    break;
                case MessageBoxResult.No:
                    break;
            }

        }
        #endregion

        #region DoubleClickGiveRight
        private void shopItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            messageBoxText = "Are you sure you want to give this item?";
            caption = "Buy Item";
            button = MessageBoxButton.YesNo;
            icon = MessageBoxImage.Warning;
            result = MessageBox.Show(messageBoxText, caption, button, icon);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    Button_Click_1(sender, e);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        #endregion

        #region GiveHandlers
        private void GiveToRightName_Click(object sender, RoutedEventArgs e)
        {

            selectedItemIndexes = new List<Items>();

            foreach (object o in playerItemsLeft.SelectedItems)
            {
                selectedItemIndexes.Add((Items)o);
            }
            initialval = playerItemsLeft.SelectedItems.Count;
            invcheck = playerRight.currentItems.Count + playerItemsLeft.SelectedItems.Count;
            if (playerItemsLeft.SelectedItem == null)
            {
                MessageBox.Show("Please select and item to give!");
            }
            else
            {
                if (invcheck <= 10 && invcheck >= 0)
                {

                    for (int i = 0; i < initialval; i++)
                    {
                        item = (Items)playerItemsLeft.SelectedItems[0];
                        playerRight.addToInventory(item);
                        playerLeft.removeFromInventory(selectedItemIndexes[i]);

                    }
                }
                else
                {
                    MessageBox.Show(playerRight.name + " does not have enough space in their inventory!");
                }
            }

        }

        private void GiveToLeftName_Click(object sender, RoutedEventArgs e)
        {
            selectedItemIndexes = new List<Items>();

            foreach (object o in playerItemsRight.SelectedItems)
            {
                selectedItemIndexes.Add((Items)o);
            }
            initialval = playerItemsLeft.SelectedItems.Count;
            invcheck = playerLeft.currentItems.Count + playerItemsRight.SelectedItems.Count;

            if (playerItemsRight.SelectedItem == null)
            {
                MessageBox.Show("Please select and item to give!");
            }
            else
            {
                if (invcheck <= 10 && invcheck >= 0)
                {

                    for (int i = 0; i < initialval; i++)
                    {
                        item = (Items)playerItemsRight.SelectedItems[0];
                        playerLeft.addToInventory(item);
                        playerRight.removeFromInventory(selectedItemIndexes[i]);
                    }
                }
                else
                {
                    MessageBox.Show(playerLeft.name + " does not have enough space in their inventory!");
                }
            }

        }
        #endregion
    }
}

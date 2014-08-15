using Shop.CodeTest;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        string shownBonus;
        double bonus;
        Player currentplayer;
        string sendbackgold;
        double currentgold;
        ObservableCollection<Items> shopList;
        Items item;
        string messageBoxText;
        string caption;
        MessageBoxButton button;
        MessageBoxImage icon;
        MessageBoxResult result;
        #endregion

        #region Main
        public MainWindow(Player passedIn)
        {
            InitializeComponent();
            currentplayer = passedIn;
            playerCurrency.DataContext = currentplayer;
            playerName.DataContext = currentplayer;
            playerItems.ItemsSource = currentplayer.currentItems;
            playerPB.DataContext = currentplayer.PB;

            #region Bonus
            if (currentplayer.PB >= 10 && currentplayer.PB <= 16)
                shownBonus = "20%";
            else if (currentplayer.PB >= 17 && currentplayer.PB <= 25)
                shownBonus = "50%";
            else if (currentplayer.PB >= 26)
                shownBonus = "Full Price";
            else
                shownBonus = "None";
            #endregion

            saleBonus.DataContext = shownBonus;

            #region Items
            shopList = new ObservableCollection<Items>
            {
                //Melee
                new Items { Weapon = "Survival Knife", Price = 15, sellPrice = ((double)15/(double)2), description = "1d6" },
                new Items { Weapon = "Small Crowbar", Price = 20, sellPrice = ((double)20/(double)2), description = "2d6" },
                new Items { Weapon = "Large Crowbar", Price = 35, sellPrice = ((double)35/(double)2), description = "2d8"},
                new Items { Weapon = "Machete", Price = 45, sellPrice = ((double)45/(double)2), description = "3d6" },
                new Items { Weapon = "12-Pound Sludgehammer", Price = 75, sellPrice = ((double)75/(double)2), description = "2d12" },
                //Hand Guns
                new Items { Weapon = ".22 Sport", Price = 35, sellPrice = ((double)35/(double)2), description = "2d4" },
                new Items { Weapon = "9mm Rogue", Price = 45, sellPrice = ((double)45/(double)2), description = "3d6" },
                new Items { Weapon = "9mm Gangsta", Price = 55, sellPrice = ((double)55/(double)2), description = "3d6 x2" },
                new Items { Weapon = ".45 Defender", Price = 65, sellPrice = ((double)65/(double)2), description = "4d6" },
                new Items { Weapon = ".50 Israeli", Price = 200, sellPrice = ((double)200/(double)2), description = "5d6" },
                //Rifles
                new Items { Weapon = ".223 Militia", Price = 65, sellPrice = ((double)65/(double)2), description = "4d6" },
                new Items { Weapon = ".556 Desert", Price = 75, sellPrice = ((double)75/(double)2), description = "4d6 x2" },
                new Items { Weapon = ".762 Hunter", Price = 85, sellPrice = ((double)85/(double)2), description = "5d6" },
                new Items { Weapon = ".50 Sniper", Price = 400, sellPrice = ((double)400/(double)2), description = "6d6 + 10 Damage" },
                //Shotguns
                new Items { Weapon = "12 Guage Farmer", Price = 65, sellPrice = ((double)65/(double)2), description = "4d6" },
                new Items { Weapon = "12 Guage Ronin", Price = 75, sellPrice = ((double)75/(double)2), description = "4d6 x2" },
                new Items { Weapon = "12 Guage Slugger", Price = 90, sellPrice = ((double)90/(double)2), description = "4d6" },  
                new Items { Weapon = "Swat-a-be Special", Price = 300, sellPrice = ((double)200/(double)2), description = "5d6 x2" },
                //Ammo
                new Items { Weapon = "Pistol Bullet", Price = 2, sellPrice = ((double)2/(double)2), description = "Bullet for pistol." },
                new Items { Weapon = "Rifle Bullet", Price = 4, sellPrice = ((double)4/(double)2), description = "Bullet for rifle." },
                new Items { Weapon = "Shutgun Bullet", Price = 3, sellPrice = ((double)3/(double)2), description = "Bullet for shutgun." },



            };
            #endregion

            updatePrices();
            

            shopItems.ItemsSource = shopList;
        }
        #endregion

        #region BuyItemHandler
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            item = ((Items)shopItems.SelectedItem);

            double.TryParse(currentplayer._Currency, out currentgold);
            if (item != null)
            {
                if (currentgold >= ((Items)shopItems.SelectedItem).Price)
                {
                    currentgold = currentgold - ((Items)shopItems.SelectedItem).Price;
                    currentplayer.addToInventory(item);

                    sendbackgold = currentgold.ToString();
                    currentplayer.Currency = sendbackgold;
                }
                else
                {
                    MessageBox.Show("Sorry pal, you don't have enough currency for that!");
                }
            }
            else
            {
                MessageBox.Show("I'm sorry, what was that you wanted?");
            }
        }
        #endregion

        #region SellItemHandler
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            item = ((Items)playerItems.SelectedItem);
            if (item != null)
            {        
                double.TryParse(currentplayer._Currency, out currentgold);
                currentgold = currentgold + (((Items)playerItems.SelectedItem).sellPrice);
                currentplayer.removeFromInventory((byte)playerItems.SelectedIndex);

                sendbackgold = currentgold.ToString();
                currentplayer.Currency = sendbackgold;
            }
            else
            {
                MessageBox.Show("What is it you are selling?");
            }

        }
        #endregion

        #region BonusInfo
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("This is the bonus you will get for selling items. You will recieve a " + shownBonus + " bonus on any items you sell. Physical Beauty matters here. Increase it to get higher bonuses!");
        }
        #endregion

        #region DoubleClickSell
        private void playerItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            messageBoxText = "Are you sure you want to sell this item?";
            caption = "Sell Item";
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

        #region DoubleClickBuy
        private void shopItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            messageBoxText = "Are you sure you want to buy this item?";
            caption = "Buy Item";
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

        #region UpdatePrices
        public void updatePrices()
        {
            for (int i = 0; i < shopList.Count; i++)
            {
                if (currentplayer.PB >= 10 && currentplayer.PB <= 16)
                    bonus = shopList[i].sellPrice * .20;
                else if (currentplayer.PB >= 17 && currentplayer.PB <= 25)
                    bonus = shopList[i].sellPrice * .50;
                else if (currentplayer.PB >= 26 && currentplayer.PB <= 30)
                    bonus = shopList[i].sellPrice;
                else
                    bonus = 0;

                shopList[i].sellPrice = shopList[i].sellPrice + bonus;
            }
        }
        #endregion
    }
}

using System.Collections.ObjectModel;
using System.Windows;

namespace PlayerTrading.CodeTest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
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
            #region Items
            ObservableCollection<Items> shopList = new ObservableCollection<Items>
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

            
            Billy.addToInventory(shopList[0]);
            Billy.addToInventory(shopList[4]);
            Billy.addToInventory(shopList[3]);
            Billy.addToInventory(shopList[7]);
            Billy.addToInventory(shopList[1]);
            Billy.addToInventory(shopList[9]);

            CJ.addToInventory(shopList[0]);
            CJ.addToInventory(shopList[4]);
            CJ.addToInventory(shopList[3]);
            CJ.addToInventory(shopList[7]);
            CJ.addToInventory(shopList[1]);
            CJ.addToInventory(shopList[9]);

            Mario.addToInventory(shopList[0]);
            Mario.addToInventory(shopList[4]);
            Mario.addToInventory(shopList[3]);
            Mario.addToInventory(shopList[7]);
            Mario.addToInventory(shopList[1]);
            Mario.addToInventory(shopList[9]);

            Link.addToInventory(shopList[0]);
            Link.addToInventory(shopList[4]);
            Link.addToInventory(shopList[3]);
            Link.addToInventory(shopList[7]);
            Link.addToInventory(shopList[1]);
            Link.addToInventory(shopList[9]);

            playChoices.ItemsSource = playerlist;
        }

        private void openShop_Click(object sender, RoutedEventArgs e)
        {
            
            if (playChoices.SelectedItems.Count == 2)
            {
                Player left = (Player)playChoices.SelectedItems[0];
                Player right = (Player)playChoices.SelectedItems[1];
                if (sender != null)
                {
                    var newWindow = new MainWindow(left, right);
                    newWindow.Show();
                }
                else
                {
                    MessageBox.Show("Please select a character!");
                }
            }
            else
            {
                MessageBox.Show("You may only trade with two people at a time!");
            }
        }
    }
}

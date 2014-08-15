using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Shop.CodeTest
{
    public class Player : INotifyPropertyChanged
    {
        public byte PB { get; set; }
        public string name { get; set; }
        public string _Currency;
        public string Currency
        {
            
            set
            {
                this._Currency = value;
                this.FirePropertyChanged("Currency");
            }
            get { return this._Currency; }
        }
        public ObservableCollection<Items> currentItems { get; set; }


        public Player(string money, byte beauty, string namechoice)
        {
            name = namechoice;
            Currency = money;
            currentItems = new ObservableCollection<Items>();
            PB = beauty;
        }
        public void addToInventory(Items item)
        {
            currentItems.Add(item);
        }
        public void removeFromInventory(byte index)
        {
            currentItems.RemoveAt(index);
        }

        private void FirePropertyChanged(string p)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(p));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}

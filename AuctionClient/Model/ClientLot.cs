using AuctionClient.TimerClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionClient.LotModel
{
     public class ClientLot:INotifyPropertyChanged
    {
        public TimeClass MyTimeClass { get; set; }


        public int iD;

        private string _info;
        public string Info
        {
            get { return _info; }
            set { _info = value;
                OnPropertyChanged("Info");
            }
        }


        private string _buyerName;
        public string BuyerName
        {
            get { return _buyerName; }
            set { _buyerName = value;
                OnPropertyChanged("BuyerName");
            }
        }

        // public int Id { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        private decimal _soldPrice;
        public decimal SoldPrice
        {
            get { return _soldPrice; }
            set
            {
                _soldPrice = value;
                OnPropertyChanged("SoldPrice");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _photo;
        public string Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                OnPropertyChanged("Photo");
            }
        }
        public ClientLot()
        {
            MyTimeClass = new TimeClass();
        }
    }
}

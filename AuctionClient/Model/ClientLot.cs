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

        public int iD;

        private string _info;
        public string Info
        {
            get { return _info; }
            set { _info = value;
                PropertyChange("Info");
            }
        }


        private string _buyerName;
        public string BuyerName
        {
            get { return _buyerName; }
            set { _buyerName = value;
                PropertyChange("BuyerName");
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
                PropertyChange("Name");
            }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                PropertyChange("Price");
            }
        }

        private decimal _soldPrice;
        public decimal SoldPrice
        {
            get { return _soldPrice; }
            set
            {
                _soldPrice = value;
                PropertyChange("SoldPrice");
            }
        }

        private string _photo;

        public event PropertyChangedEventHandler PropertyChanged;
        public void PropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;

            }
        }
        public ClientLot()
        {

        }
    }
}

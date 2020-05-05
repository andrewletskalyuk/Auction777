using AuctionClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionClient.ViewModel
{
	public class AuctionViewModel:INotifyPropertyChanged
	{
		private int _buyerCash;

		public int BuyerCash
		{
			get { return _buyerCash; }
			set { _buyerCash = value;
				PropertyChanger("BuyerCash");
			}
		}

		private ObservableCollection<ServerLotDTO> _myLot;


		public ObservableCollection<ServerLotDTO> MyLot
		{
			get { return _myLot; }
			set { _myLot = value; }
		}

		public AuctionViewModel()
		{
			MyLot = new ObservableCollection<ServerLotDTO>();
		}
		public void PropertyChanger(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));

		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
}

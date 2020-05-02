using AuctionClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionClient.ViewModel
{
    public class AuctionViewModel
    {
		
		//public ICallBack call;
		public AuctionViewModel()
		{
			MyLot = new ObservableCollection<Lot>();
			
			
		}

		private ObservableCollection<Lot> myLot;

		public ObservableCollection<Lot> MyLot
		{
			get { return myLot; }
			set { myLot = value; }
		}
	}
}

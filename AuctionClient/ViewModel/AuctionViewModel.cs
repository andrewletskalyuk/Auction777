﻿using AuctionClient.ServiceReference1;
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
		private ObservableCollection<Lot> _myLot;

		public ObservableCollection<Lot> MyLot
		{
			get { return _myLot; }
			set { _myLot = value; }
		}

		public AuctionViewModel()
		{
			MyLot = new ObservableCollection<Lot>();
		}

	}
}

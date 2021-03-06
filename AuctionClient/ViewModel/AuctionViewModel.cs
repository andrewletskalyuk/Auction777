﻿using AuctionClient.LotModel;
using AuctionClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace AuctionClient.ViewModel
{
	public class AuctionViewModel:INotifyPropertyChanged
	{
		private string _buyerName;
		public string BuyerName
		{
			get { return _buyerName; }
			set { _buyerName = value;
				PropertyChanger("BuyerName");
			}
		}

		private int _buyerCash;
		public int BuyerCash
		{
			get { return _buyerCash; }
			set { _buyerCash = value;
				PropertyChanger("BuyerCash");
			}
		}

		public void MyTimerStart(int value)
		{
			var timer = new DispatcherTimer();
			timer.Tick += new EventHandler(ClientLots[value].MyTimeClass.counterOne_Tick);
			timer.Interval = new TimeSpan(0, 0, 1);
			timer.Start();


		}
		
		//private ObservableCollection<int> _myTime;
		//public ObservableCollection<int> MyTime
		//{
		//	get { return _myTime; }
		//	set { _myTime = value; }
		//}

		private ClientLot _selectedLot;
		public ClientLot SelectedLot
		{
			get { return _selectedLot; }
			set { _selectedLot = value; }
		}

		private ObservableCollection<ServerLotDTO> _mySelectedLot;
		public ObservableCollection<ServerLotDTO> MySelectedLot
		{
			get { return _mySelectedLot; }
			set { _mySelectedLot = value; }
		}


		private ObservableCollection<ServerLotDTO> _myLot;
		public ObservableCollection<ServerLotDTO> MyLot
		{
			get { return _myLot; }
			set { _myLot = value; }
		}

		private ObservableCollection<ClientLot> _clientLots;
		public ObservableCollection<ClientLot> ClientLots
		{
			get { return _clientLots; }
			set { _clientLots = value; }
		}
		public AuctionViewModel()
		{
			MyLot = new ObservableCollection<ServerLotDTO>();
			ClientLots = new ObservableCollection<ClientLot>();
		}
		public void PropertyChanger(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));

		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
}

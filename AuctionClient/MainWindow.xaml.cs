using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Transactions;
using System.Windows;
using AuctionClient.ServiceReference1;
using AuctionClient.ViewModel;

namespace AuctionClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window, IAukzionContractCallback
    {
        
        public AukzionContractClient client;
        public AuctionViewModel viewmodel { get; set; }
        public MainWindow()
        {
            viewmodel = new AuctionViewModel();
            InitializeComponent();

            stTest.DataContext = viewmodel;
            client = new AukzionContractClient(new InstanceContext(this));
          //  var connection = client.ConnectionForBuyer("None", 0);
            GetProducts("None",1000000);

            lstAuction.ItemsSource = viewmodel.MyLot;
        }
        public MainWindow(string name, int money)
        {
            viewmodel = new AuctionViewModel();
            InitializeComponent();

            stTest.DataContext = viewmodel;
            client = new AukzionContractClient(new InstanceContext(this));
            var connection = client.ConnectionForBuyer(name,money);
            //Вибираємо лоти для viewmodel
            GetProducts(name,money);
           

            lstAuction.ItemsSource = viewmodel.MyLot;
        }
        public void GetProducts(string name,int money)
        {
            var obj = client.GetAllProduct();
            //Створює усі колекції масивами
            foreach (ServerLotDTO item in obj)
            {
                viewmodel.MyLot.Add(item);
            }
            viewmodel.BuyerCash = money;
            viewmodel.BuyerName = name;
        }

               
        private async void MakeBet_BtnClick(object sender, RoutedEventArgs e)
        {
            ServerLotDTO makeBetLot = (lstAuction.SelectedItem as ServerLotDTO);

                try
                {
                    if (makeBetLot != null)
                    {
                        await client.MakeBetAsync(viewmodel.BuyerName, makeBetLot.Id, int.Parse(tbBet.Text));
                    }
                }
                catch(InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void Windows_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.DisconnectBayer(viewmodel.BuyerName);
        }

        public void UpdateLotsForBuyer(ServerLotDTO[] lots, ServerLotDTO[] lotsForBuyer)
        {
            ObservableCollection<ServerLotDTO> update = new ObservableCollection<ServerLotDTO>();
            foreach (ServerLotDTO item in lots)
            {
                update.Add(item);
            }
            viewmodel.MyLot = update;
            lstAuction.ItemsSource = update;
            ObservableCollection<ServerLotDTO> updateSelectedLots = new ObservableCollection<ServerLotDTO>();
            foreach (ServerLotDTO item in lotsForBuyer)
            {
                updateSelectedLots.Add(item);
            }
            viewmodel.MySelectedLot = updateSelectedLots;
            lstBuyerLots.ItemsSource = viewmodel.MySelectedLot;
        }

        public void Bet(decimal buyerCash)
        {           
            viewmodel.BuyerCash = (int)buyerCash;
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Transactions;
using System.Windows;
using AuctionClient.LotModel;
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

          //  lstAuction.ItemsSource = viewmodel.MyLot;
        }
        public MainWindow(string name, int money)
        {
            viewmodel = new AuctionViewModel();
            InitializeComponent();

            stTest.DataContext = viewmodel;
            client = new AukzionContractClient(new InstanceContext(this));
            var connection = client.ConnectionForBuyer(name,money);
            if (connection)
            { //Вибираємо лоти для viewmodel
                GetProducts(name, money);


                lstAuction.ItemsSource = viewmodel.ClientLots;
            }
            else
            {
                throw new InvalidOperationException("User not found");
            }
        }
        public void GetProducts(string name,int money)
        {

            var obj = client.GetAllProduct();
            //Створює усі колекції масивами
            foreach (ServerLotDTO item in obj)
            {
                viewmodel.ClientLots.Add(new ClientLot()
                {
                    iD=item.Id,
                    BuyerName = "None",
                    Price = item.Price,
                    Name=item.Name,
                    Info="Non info",
                    Photo=item.Photo
                });
            }
            //foreach (ServerLotDTO item in obj)
            //{
            //    viewmodel.MyLot.Add(item);
            //}
            viewmodel.BuyerCash = money;
            viewmodel.BuyerName = name;
        }

               
        private async void MakeBet_BtnClick(object sender, RoutedEventArgs e)
        {

            ClientLot makeBetLot = (lstAuction.SelectedItem as ClientLot);
            decimal isSelectedPrice = Decimal.Parse(tbBet.Text);
            if (CheckOutCash(makeBetLot.Price,isSelectedPrice))
            {
                try
                {
                    if (makeBetLot != null)
                    {
                        await client.MakeBetAsync(viewmodel.BuyerName, makeBetLot.iD, (int)isSelectedPrice);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool CheckOutCash(decimal price,decimal selprice)
        {

            return viewmodel.BuyerCash > price&& (lstAuction.SelectedItem as ClientLot).Price<selprice ? true : false;
           
        }

        private void Windows_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.DisconnectBayer(viewmodel.BuyerName);
        }

        public void UpdateLotsForBuyer(ServerLotDTO[] lots, ServerLotDTO[] lotsForBuyer)
        {
            //ObservableCollection<ServerLotDTO> update = new ObservableCollection<ServerLotDTO>();
            //foreach (ServerLotDTO item in lots)
            //{
            //    update.Add(item);
            //}
            //viewmodel.MyLot = update;

          //  ObservableCollection<ServerLotDTO> updateSelectedLots = new ObservableCollection<ServerLotDTO>();
            ObservableCollection<ClientLot> clientLot = new ObservableCollection<ClientLot>();
            foreach (ServerLotDTO item in lots)
            {
                clientLot.Add(new ClientLot()
                {
                    iD = item.Id,
                    BuyerName =item.BuyerName,
                    Price = item.Price,
                    Name = item.Name,
                    Info = "Non info",
                    Photo = item.Photo
                });
            }
            viewmodel.ClientLots = clientLot;
            lstAuction.ItemsSource = clientLot;
          //  lstBuyerLots.ItemsSource = clientLot;
            //ObservableCollection<ServerLotDTO> updateSelectedLots = new ObservableCollection<ServerLotDTO>();
            //foreach (ServerLotDTO item in lotsForBuyer)
            //{
            //    updateSelectedLots.Add(item);
            //}
            //viewmodel.MySelectedLot = updateSelectedLots;
            //lstBuyerLots.ItemsSource = viewmodel.MySelectedLot;
        }

        public void Bet(decimal buyerCash)
        {           
            viewmodel.BuyerCash = (int)buyerCash;
        }
    }
}

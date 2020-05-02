using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        public StartWindow PR { get; set; }
        public AuctionViewModel viewmodel { get; set; }

        string buyerName;
        int buyerMoney;
        public MainWindow()
        {

            viewmodel = new AuctionViewModel();
            InitializeComponent();
            buyerMoney =0;
            buyerName = "None";
            this.DataContext = viewmodel;
            lstAuction.ItemsSource = viewmodel.MyLot;
        }
        public MainWindow(string name,int money)
        {
            this.Title = name;
            viewmodel = new AuctionViewModel();
            InitializeComponent();
            buyerMoney = money;
            buyerName = name;

            client = new AukzionContractClient(new System.ServiceModel.InstanceContext(this));

            client.ConnectionForBuyer(buyerName, buyerMoney);

            var obj = client.GetAllProduct();
            //Створює усі колекції масивами
            foreach (Lot item in obj)
            {
                viewmodel.MyLot.Add(item);
            }
            this.DataContext = viewmodel;
            lstAuction.ItemsSource = viewmodel.MyLot;
        }

        public void Bet()
        {
            throw new NotImplementedException();
        }

        public void UpdateLotsForBuyer(Lot[] lots)
        {
            ObservableCollection<Lot> update = new ObservableCollection<Lot>();
            foreach (Lot item in lots)
            {
                update.Add(item);
            }
            viewmodel.MyLot = update;
        }

        private void MakeBet_BtnClick(object sender, RoutedEventArgs e)
        {
            Lot makeBetLot = (lstAuction.SelectedItem as Lot);

            //Передача ціни та Ід
            client.MakeBet(buyerName, makeBetLot.Id, 1000000);
            
            for(int i=0;i< viewmodel.MyLot.Count;i++)
            {
                if(makeBetLot== viewmodel.MyLot[i])
                {
                    viewmodel.MyLot[i].BuyerName = buyerName;
                  //  buyerMoney -= viewmodel.MyLot[i].SoldPrice;
                }
            }
        }

        private void Windows_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.DisconnectBayer(buyerName);
        }
    }
    //public class ICallBack : IAukzionContractCallback
    //{

    //    public void Bet()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void UpdateLotsForBuyer(Lot[] lots)
    //    {
    //        ObservableCollection<Lot> update = new ObservableCollection<Lot>();
    //        foreach (Lot item in lots)
    //        {
    //            update.Add(item);
                
    //        }
    //    }
    //}
}

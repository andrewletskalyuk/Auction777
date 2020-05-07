using AuctionClient.ServiceReference1;
using AuctionClient.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AuctionClient
{
    /// <summary>
    /// Interaction logic for SellerWindow.xaml
    /// </summary>
    public partial class SellerWindow : Window, IAukzionContractCallback
    {
        private string sellerName;
        private int sellerCash;
        public AukzionContractClient seller;
        public AuctionViewModel viewmodel { get; set; }

        public SellerWindow()
        {
            viewmodel = new AuctionViewModel();
            InitializeComponent();
            sellerName = "NoName";
            sellerCash = 0;
            this.DataContext = viewmodel;
            lbLots.ItemsSource = viewmodel.MyLot;
        }

        /// <summary>
        /// Start window with parameters
        /// </summary>
        /// <param name="sellerName"></param>
        /// <param name="sellerCash"></param>
        public SellerWindow(string sellerName, int sellerCash)
        {
            InitializeComponent();
            this.sellerName = sellerName;
            this.sellerCash = sellerCash;
            viewmodel = new AuctionViewModel();
            this.DataContext = viewmodel;
            ConnectionForSeller();
        }
        /// <summary>
        /// ConnectionForSeller - add data for view, and make datasource for listbox
        /// </summary>
        private void ConnectionForSeller()
        {
            seller = new AukzionContractClient(new InstanceContext(this));
            var serverLotDTOs = seller.GetAllProduct();
            sellerWindowTitle.Title = sellerName;
            //Створює усі колекції масивами
            foreach (ServerLotDTO lotDTO in serverLotDTOs)
            {
                viewmodel.MyLot.Add(lotDTO);
            }
            this.DataContext = viewmodel;
            //lbLots = new ListBox();
            lbLots.ItemsSource = viewmodel.MyLot;
        }


        /// <summary>
        /// Callback Contract 
        /// </summary>
        public void Bet()
        {
            throw new NotImplementedException();
        }

        public void UpdateLotsForBuyer(ServerLotDTO[] lots)
        {
            throw new NotImplementedException();
        }

        private void btnChooseThPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Jpeg files (*.jpeg) | *.jpg | Png files (*.png) | *.png";
            openFileDialog.ShowDialog();
            var fileName = openFileDialog.FileName;
            var rootFile = System.IO.Path.GetFullPath(openFileDialog.FileName);
        }
    }
}

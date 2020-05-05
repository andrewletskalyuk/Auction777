using AuctionClient.ServiceReference1;
using AuctionClient.ViewModel;
using System;
using System.Collections.Generic;
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
        }

        public SellerWindow(string sellerName, int sellerCash)
        {
            this.sellerName = sellerName;
            this.sellerCash = sellerCash;
            viewmodel = new AuctionViewModel();


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
    }
}

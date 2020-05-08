using AuctionClient.LotModel;
using AuctionClient.ServiceReference1;
using AuctionClient.ViewModel;
using Microsoft.Win32;
using System;
using System.IO;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AuctionClient
{
    /// <summary>
    /// Interaction logic for SellerWindow.xaml
    /// </summary>
    public partial class SellerWindow : Window, IAukzionContractCallback
    {
        private string sellerName;
        private int sellerCash;
        private int startPriceOfLot;
        public AukzionContractClient seller;
        public AuctionViewModel viewmodel { get; set; }

        public SellerWindow()
        {
            viewmodel = new AuctionViewModel();
            InitializeComponent();
            sellerName = "NoName";
            sellerCash = 0;
         //   this.DataContext = viewmodel; 
            lbLots.ItemsSource = viewmodel.MyLot; //це треба буде переробити
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
          //  this.DataContext = viewmodel;
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
            foreach (ServerLotDTO item in serverLotDTOs)
            {
                viewmodel.ClientLots.Add(new ClientLot()
                {
                    iD = item.Id,
                    BuyerName = "None",
                    Price = item.Price,
                    Name = item.Name,
                    Info = "Non info",
                    Photo = item.Photo
                });
            }

            lbLots.ItemsSource = viewmodel.ClientLots;
        }

        private void btnChooseThPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.png;*.jpeg;*.jpg";
            openFileDialog.ShowDialog();
            var sourceFilePath = openFileDialog.FileName;
            var destinantionFilePath = Directory.GetCurrentDirectory() + 
                                        $"\\ImagesForLots\\" + 
                                        System.IO.Path.GetFileName(sourceFilePath);
            File.Copy(sourceFilePath, destinantionFilePath, true);

            Image lotImage = new Image();
            //lotImage.Width = 100;
            //lotImage.Height = 100;

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(destinantionFilePath);
            bitmapImage.EndInit();

            lotImage.Source = bitmapImage;

            imageForLot.Source = bitmapImage;
        }

        private async void btnCreateNewLot_Click(object sender, RoutedEventArgs e)
        {
            if (IsCorrectDataNewProduct(tbNameProduct.Text, tbNameProductStartPrice.Text, imageForLot.Source))
            {
                var tempPriceLot = Int32.Parse(tbNameProductStartPrice.Text);


                ClientLot sellerLot = new ClientLot()              
                {
                    Name = tbNameProduct.Text,
                    BuyerName = "Just added product",
                    Price = tempPriceLot,
                    SoldPrice = tempPriceLot,
                    Photo = imageForLot.Source.ToString()
                };
                await seller.AddProductToDBSellerAsync(sellerLot.Name, sellerLot.Price, sellerLot.Photo);

                viewmodel.ClientLots.Add(sellerLot);

            }
            else
            {
                MessageBox.Show("Incorrect data's put in");
            }
        }
        
        /// <summary>
        /// Check out for correct data which putting in
        /// </summary>
        /// <param name="nameProduct"></param>
        /// <param name="startPrice"></param>
        /// <param name="sourceOfProduct"></param>
        /// <returns></returns>
        private bool IsCorrectDataNewProduct(string nameProduct, string startPrice, ImageSource sourceOfProduct)
        {
            if (!String.IsNullOrEmpty(nameProduct)
                && Int32.TryParse(startPrice, out startPriceOfLot)
                && sourceOfProduct!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Callback Contract 
        /// </summary>
    

        public void Bet(decimal buyerCash)
        {
            throw new NotImplementedException();
        }

        public void UpdateLotsForBuyer(ServerLotDTO[] allLots, ServerLotDTO[] buyerLots)
        {
            throw new NotImplementedException();
        }
    }
}

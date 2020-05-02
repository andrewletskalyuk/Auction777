using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AukzionLibrary
{
    
    [ServiceContract(CallbackContract =typeof(IAuctionCallBack))]
    public interface IAukzionContract
    {
        [OperationContract]
        bool ConnectionForBuyer(string name, int money);
        [OperationContract]
        ObservableCollection<Lot> GetAllProduct();
        [OperationContract(IsOneWay = true)]
        void Sold(int productId,int buyerId);
        [OperationContract(IsOneWay = true)]
        void DisconnectBayer(string name);
        [OperationContract(IsOneWay = true)]
        void MakeBet(string name, int productId, int bet);
        [OperationContract(IsOneWay =true)]
        void AddProduct(string name, decimal startPrice, string pathToPhoto);
    }

    public interface IAuctionCallBack
    {
        [OperationContract(IsOneWay = true)]
        void Bet();
        [OperationContract(IsOneWay = true)]
        void UpdateLotsForBuyer(ObservableCollection<Lot> lots);
    }
   
   public class Lot
    {
        public string BuyerName { get; set; }
       
        public int Id { get; set; }

        private string name;
        
        public string Name
        {
            get { return name; }
            set { name = value;
               
            }
        }

        private int price;
       
        public int Price
        {
            get { return price; }
            set { price = value;
             
            }
        }

        private int soldPrice;
       
        public int SoldPrice
        {
            get { return soldPrice; }
            set { soldPrice = value;
              
            }
        }

        private string photo;

        public string Photo
        {
            get { return photo; }
            set { photo = value;
        
            }
        }

        public Lot()
        {

        }
     
    }
}

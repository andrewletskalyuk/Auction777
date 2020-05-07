using AukzionLibrary.DTOClasses;
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
        ObservableCollection<ServerLotDTO> GetAllProduct();
        [OperationContract(IsOneWay = true)]
        void Sold(int productId,int buyerId);
        [OperationContract(IsOneWay = true)]
        void DisconnectBayer(string name);
        [OperationContract]
        void MakeBet(string name, int productId, int bet);
        [OperationContract(IsOneWay =true)]
        void AddProductToDB(string name, decimal startPrice, string pathToPhoto);
        [OperationContract(IsOneWay = true)]
        void AddProductToDBSeller(string name, decimal startPrice, string pathToPhoto);
    }

    public interface IAuctionCallBack
    {
        [OperationContract(IsOneWay = true)]
        void Bet(decimal buyerCash);
        [OperationContract(IsOneWay = true)]
        void UpdateLotsForBuyer(ObservableCollection<ServerLotDTO> allLots, ObservableCollection<ServerLotDTO> buyerLots);
    }
   
}

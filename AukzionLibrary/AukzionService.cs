using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AukzionLibrary.DBContext;
using AukzionLibrary.DTOClass;

namespace AukzionLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class AukzionService : IAukzionContract
    {
        public Model MyAuction;

        public List<ServerBuyerDTO> ServerBuyers;

        public AukzionService()
        {
            
            MyAuction = new Model();
            ServerBuyers = new List<ServerBuyerDTO>();
            AddForViewProduct();
        }

        private void AddForViewProduct()
        {
            var allLot = (from obj in MyAuction.Product
                          select obj).ToList();
            foreach (var item in allLot)
            {

                auctionLot.Add(new Lot()
                {
                    Name = item.Name,
                    Id = item.Id,
                    Photo = item.Photo,
                    Price = (int)item.StartPrice,
                    BuyerName = "Yo"
                });
            }
        }

        //метод буде bool для того щоб в Покупця викликати методи Connect i Disconnect 
        public bool ConnectionForBuyer(string name, int money)
        {
            bool connect = false;

            ServerBuyers.Add(new ServerBuyerDTO() { 
                Name = name,
                Money = money,
                operationContextCallBack= OperationContext.Current
            });

            //Заповнення в базу
            //foreach (Buyer item in MyAuction.Buyer)
            //{
            //    if (item.Name == name)
            //    {
            //        connect = true;
            //    }
            //    else
            //    {
            //        MyAuction.Buyer.Add(new Buyer() {
            //            Name=name,
            //            Cash=money});
            //        //MyAuction.SaveChanges();
            //        connect = true;
            //    }
            //}
            //  return connect;

            //Перевірка ДТО
            return true;
        }

        //збережемо дані про юзера і що він зробив
        public void DisconnectBayer(string name)
        {
             //  var user = MyAuction.Buyer.FirstOrDefault(x => x.Name == name);
            //if (user != null)
            //{
            //    MyAuction.SaveChanges(); 
            //}
            foreach(ServerBuyerDTO item in ServerBuyers)
            {
                if (item.Name == name)
                    ServerBuyers.Remove(item);
            }
        }
        
        //зробимо ставку - це для Покупця
        public void MakeBet(string nameOfBuyer, int productId, int bet)
        {
            var user = MyAuction.Buyer.FirstOrDefault(x => x.Name == nameOfBuyer);
            var product = MyAuction.Product.FirstOrDefault(y => y.Id == productId);
            if (product.SellPrice > bet)
            {
                product.SellPrice = bet;
            }
            //auctionLot.
            for (int i = 0; i < auctionLot.Count; i++)
            {
                if (auctionLot[i].Name == product.Name)
                {
                    auctionLot[i].BuyerName = nameOfBuyer;
                }
            }

            foreach(ServerBuyerDTO item in ServerBuyers)
            {
                item.operationContextCallBack.GetCallbackChannel<IAuctionCallBack>().UpdateLotsForBuyer(auctionLot);
            }
        }

        public void Sold(int productId, int buyerId)
        {
            throw new NotImplementedException();
        }

          public  ObservableCollection<Lot> auctionLot = new ObservableCollection<Lot>();
        public ObservableCollection<Lot> GetAllProduct()
        {

            
            return auctionLot;

        }
        //додаємо продукт в базу
        public void AddProduct(string name, decimal startPrice, string pathToPhoto)
        {
            MyAuction.Product.Add(new Product() { Name = name, StartPrice = startPrice, Photo = pathToPhoto, Status = false });
        }
    }

}

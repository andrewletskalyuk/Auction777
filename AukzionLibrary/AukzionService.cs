using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AukzionLibrary.DBContext;
using AukzionLibrary.DTOClass;
using AukzionLibrary.DTOClasses;

namespace AukzionLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class AukzionService : IAukzionContract
    {
        public Model MyAuction;
        public List<ServerBuyerDTO> ServerBuyers;
        public ObservableCollection<ServerLotDTO> auctionLot;
        public AukzionService()
        {
            MyAuction = new Model();
            ServerBuyers = new List<ServerBuyerDTO>();
            auctionLot = new ObservableCollection<ServerLotDTO>();
            AddForViewProduct();
        }

        private void AddForViewProduct()
        {
            var allLot = (from obj in MyAuction.Product
                          select obj).ToList();
            foreach (var item in allLot)
            {
                auctionLot.Add(new ServerLotDTO()
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



            var user = MyAuction.Buyer.FirstOrDefault(n => n.Name == name);
            ServerBuyers.Add(new ServerBuyerDTO()
            {
                Name = name,
                Money = money,
                operationContextCallBack = OperationContext.Current,
                BuyerSelectedLots = new ObservableCollection<ServerLotDTO>()
            });
            //Перевіряти на однакові імена
            if (user != null)
            {
                foreach (Buyer item in MyAuction.Buyer)
                {
                    if (item.Name == name)
                    {
                        connect = true;
                    }
                }
            }
            else
            {
                MyAuction.Buyer.Add(new Buyer()
                {
                    Name = name,
                    Cash = money
                });
                MyAuction.SaveChanges();
                connect = true;
            }

            return connect;
        }

        //збережемо дані про юзера і що він зробив
        public void DisconnectBayer(string name)
        {
            var buyer = MyAuction.Buyer.FirstOrDefault(x => x.Name == name);
            if (buyer != null)
            {
                MyAuction.SaveChanges();
            }
            var buyerServer = ServerBuyers.FirstOrDefault(b => b.Name == name);
            ServerBuyers.Remove(buyerServer);
        }


        //зробимо ставку - це для Покупця
        public void MakeBet(string nameOfBuyer, int productId, int bet)
        {

            //var user = MyAuction.Buyer.FirstOrDefault(x => x.Name == nameOfBuyer);
            //var product = MyAuction.Product.FirstOrDefault(y => y.Id == productId);

            var user = ServerBuyers.FirstOrDefault(x => x.Name == nameOfBuyer);
            var product = auctionLot.FirstOrDefault(y => y.Id == productId);

            if (user.Money > bet)
            {
                // user.Money -= bet;
                if (product.Price < bet)
                {
                    //    product.SellPrice = bet;
                }
                else
                {
                    throw new InvalidOperationException("Small Price");
                }
            }
            else
            {
                throw new InvalidOperationException("No Chash");
            }

            //Придумати щось по типу откату ставки
            for (int i = 0; i < auctionLot.Count; i++)
            {
                if (auctionLot[i].Name == product.Name)
                {
                    if (auctionLot[i].BuyerName != nameOfBuyer)
                    {
                        if (auctionLot[i].BuyerName != "Yo")
                        {
                            ServerBuyers.FirstOrDefault(x => x.Name == auctionLot[i].BuyerName).Money += (int)auctionLot[i].Price;
                            ServerBuyers.FirstOrDefault(x => x.Name == auctionLot[i].BuyerName).BuyerSelectedLots.Remove(auctionLot[i]);
                        }
                        ServerBuyers.FirstOrDefault(x => x.Name == nameOfBuyer).Money -= bet;
                        auctionLot[i].BuyerName = nameOfBuyer;
                        auctionLot[i].Price = bet;

                        //selected buyer lots
                        ServerBuyers.FirstOrDefault(x => x.Name == nameOfBuyer).BuyerSelectedLots.Add(auctionLot[i]);
                    }
                }
            }
            foreach (ServerBuyerDTO item in ServerBuyers)
            {
                item.operationContextCallBack.GetCallbackChannel<IAuctionCallBack>().UpdateLotsForBuyer(auctionLot, item.BuyerSelectedLots);
                item.operationContextCallBack.GetCallbackChannel<IAuctionCallBack>().Bet((decimal)item.Money);
            }

        }
        public void Sold(int productId, int buyerId) //це треба дописати
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<ServerLotDTO> GetAllProduct()
        {
            return auctionLot;
        }
        //додаємо продукт в базу
        public void AddProductToDB(string name, decimal startPrice, string pathToPhoto)
        {
            //тут треба перевірки чи даного продуктку немає в БД
            MyAuction.Product.Add(new Product()
            {
                Name = name,
                StartPrice = startPrice,
                Photo = pathToPhoto,
                Status = false
            });
            MyAuction.SaveChanges();
        }

        public async void AddProductToDBSeller(string name, decimal startPrice, string pathToPhoto)
        {
            var checkOutProduct = MyAuction.Product.FirstOrDefault(
                                                        x => x.Name == name && 
                                                        x.Photo == pathToPhoto);
            if (checkOutProduct is null)
            {
                ServerLotDTO serverLotDTO = new ServerLotDTO() { 
                    Name = name,
                    Price = startPrice,
                    Photo = pathToPhoto,
                    BuyerName = "NoName",
                    SoldPrice = startPrice,

                };
                auctionLot.Add(serverLotDTO);
                await MyAuction.SaveChangesAsync();
            }
        }
    }

}

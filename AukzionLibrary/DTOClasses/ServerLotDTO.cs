using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AukzionLibrary.DTOClasses
{
    public class ServerLotDTO
    {
        public string BuyerName { get; set; }

        public int Id { get; set; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;

            }
        }

        private int _price;

        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;

            }
        }

        private int _soldPrice;

        public int SoldPrice
        {
            get { return _soldPrice; }
            set
            {
                _soldPrice = value;

            }
        }

        private string _photo;

        public string Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;

            }
        }

        public ServerLotDTO()
        {
        }
    }
}

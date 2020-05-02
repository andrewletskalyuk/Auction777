using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAlternativeDataBaseCodeFirstAuction.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; }
        public bool IsSell { get; set; }
        List<BuyerBid> BuyerBids { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Seller Seller { get; set; }
    }
}

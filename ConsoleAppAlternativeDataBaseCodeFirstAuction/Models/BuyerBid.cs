using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAlternativeDataBaseCodeFirstAuction.Models
{
    public class BuyerBid
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BuyerId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Buyer Buyer { get; set; }
        public virtual Product Product { get; set; }
    }
}

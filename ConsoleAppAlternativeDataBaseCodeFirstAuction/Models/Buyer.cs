using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAlternativeDataBaseCodeFirstAuction.Models
{
    public class Buyer
    {
        //
        public int Id { get; set; }
        public string Name { get; set; }
        List<BuyerBid> BuyerBids { get; set; }
    }
}

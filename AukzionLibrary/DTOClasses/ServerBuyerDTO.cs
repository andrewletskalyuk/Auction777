using AukzionLibrary.DTOClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AukzionLibrary.DTOClass
{
    public class ServerBuyerDTO
    {
        public string  Name { get; set; }
        public int Money { get; set; }
        public OperationContext operationContextCallBack { get; set; }
        public ObservableCollection<ServerLotDTO> BuyerSelectedLots { get; set; }
    }
}

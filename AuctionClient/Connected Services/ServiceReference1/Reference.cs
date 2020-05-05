﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuctionClient.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServerLotDTO", Namespace="http://schemas.datacontract.org/2004/07/AukzionLibrary.DTOClasses")]
    [System.SerializableAttribute()]
    public partial class ServerLotDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BuyerNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhotoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal SoldPriceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BuyerName {
            get {
                return this.BuyerNameField;
            }
            set {
                if ((object.ReferenceEquals(this.BuyerNameField, value) != true)) {
                    this.BuyerNameField = value;
                    this.RaisePropertyChanged("BuyerName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Photo {
            get {
                return this.PhotoField;
            }
            set {
                if ((object.ReferenceEquals(this.PhotoField, value) != true)) {
                    this.PhotoField = value;
                    this.RaisePropertyChanged("Photo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal SoldPrice {
            get {
                return this.SoldPriceField;
            }
            set {
                if ((this.SoldPriceField.Equals(value) != true)) {
                    this.SoldPriceField = value;
                    this.RaisePropertyChanged("SoldPrice");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IAukzionContract", CallbackContract=typeof(AuctionClient.ServiceReference1.IAukzionContractCallback))]
    public interface IAukzionContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAukzionContract/ConnectionForBuyer", ReplyAction="http://tempuri.org/IAukzionContract/ConnectionForBuyerResponse")]
        bool ConnectionForBuyer(string name, int money);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAukzionContract/ConnectionForBuyer", ReplyAction="http://tempuri.org/IAukzionContract/ConnectionForBuyerResponse")]
        System.Threading.Tasks.Task<bool> ConnectionForBuyerAsync(string name, int money);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAukzionContract/GetAllProduct", ReplyAction="http://tempuri.org/IAukzionContract/GetAllProductResponse")]
        AuctionClient.ServiceReference1.ServerLotDTO[] GetAllProduct();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAukzionContract/GetAllProduct", ReplyAction="http://tempuri.org/IAukzionContract/GetAllProductResponse")]
        System.Threading.Tasks.Task<AuctionClient.ServiceReference1.ServerLotDTO[]> GetAllProductAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAukzionContract/Sold")]
        void Sold(int productId, int buyerId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAukzionContract/Sold")]
        System.Threading.Tasks.Task SoldAsync(int productId, int buyerId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAukzionContract/DisconnectBayer")]
        void DisconnectBayer(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAukzionContract/DisconnectBayer")]
        System.Threading.Tasks.Task DisconnectBayerAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAukzionContract/MakeBet")]
        void MakeBet(string name, int productId, int bet);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAukzionContract/MakeBet")]
        System.Threading.Tasks.Task MakeBetAsync(string name, int productId, int bet);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAukzionContract/AddProductToDB")]
        void AddProductToDB(string name, decimal startPrice, string pathToPhoto);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAukzionContract/AddProductToDB")]
        System.Threading.Tasks.Task AddProductToDBAsync(string name, decimal startPrice, string pathToPhoto);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAukzionContract/AddProductToDBSeller")]
        void AddProductToDBSeller(string name, decimal startPrice, string pathToPhoto);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAukzionContract/AddProductToDBSeller")]
        System.Threading.Tasks.Task AddProductToDBSellerAsync(string name, decimal startPrice, string pathToPhoto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAukzionContractCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAukzionContract/Bet")]
        void Bet();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAukzionContract/UpdateLotsForBuyer")]
        void UpdateLotsForBuyer(AuctionClient.ServiceReference1.ServerLotDTO[] lots);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAukzionContractChannel : AuctionClient.ServiceReference1.IAukzionContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AukzionContractClient : System.ServiceModel.DuplexClientBase<AuctionClient.ServiceReference1.IAukzionContract>, AuctionClient.ServiceReference1.IAukzionContract {
        
        public AukzionContractClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public AukzionContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public AukzionContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AukzionContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AukzionContractClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool ConnectionForBuyer(string name, int money) {
            return base.Channel.ConnectionForBuyer(name, money);
        }
        
        public System.Threading.Tasks.Task<bool> ConnectionForBuyerAsync(string name, int money) {
            return base.Channel.ConnectionForBuyerAsync(name, money);
        }
        
        public AuctionClient.ServiceReference1.ServerLotDTO[] GetAllProduct() {
            return base.Channel.GetAllProduct();
        }
        
        public System.Threading.Tasks.Task<AuctionClient.ServiceReference1.ServerLotDTO[]> GetAllProductAsync() {
            return base.Channel.GetAllProductAsync();
        }
        
        public void Sold(int productId, int buyerId) {
            base.Channel.Sold(productId, buyerId);
        }
        
        public System.Threading.Tasks.Task SoldAsync(int productId, int buyerId) {
            return base.Channel.SoldAsync(productId, buyerId);
        }
        
        public void DisconnectBayer(string name) {
            base.Channel.DisconnectBayer(name);
        }
        
        public System.Threading.Tasks.Task DisconnectBayerAsync(string name) {
            return base.Channel.DisconnectBayerAsync(name);
        }
        
        public void MakeBet(string name, int productId, int bet) {
            base.Channel.MakeBet(name, productId, bet);
        }
        
        public System.Threading.Tasks.Task MakeBetAsync(string name, int productId, int bet) {
            return base.Channel.MakeBetAsync(name, productId, bet);
        }
        
        public void AddProductToDB(string name, decimal startPrice, string pathToPhoto) {
            base.Channel.AddProductToDB(name, startPrice, pathToPhoto);
        }
        
        public System.Threading.Tasks.Task AddProductToDBAsync(string name, decimal startPrice, string pathToPhoto) {
            return base.Channel.AddProductToDBAsync(name, startPrice, pathToPhoto);
        }
        
        public void AddProductToDBSeller(string name, decimal startPrice, string pathToPhoto) {
            base.Channel.AddProductToDBSeller(name, startPrice, pathToPhoto);
        }
        
        public System.Threading.Tasks.Task AddProductToDBSellerAsync(string name, decimal startPrice, string pathToPhoto) {
            return base.Channel.AddProductToDBSellerAsync(name, startPrice, pathToPhoto);
        }
    }
}

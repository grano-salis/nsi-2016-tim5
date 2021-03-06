﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EchoCollection.WebApi.EchoServiceClient {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EchoServiceClient.IEchoCollection")]
    public interface IEchoCollection {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/GetCollections", ReplyAction="http://tempuri.org/IEchoCollection/GetCollectionsResponse")]
        EchoService.DataContracts.GetCollectionsResponse GetCollections();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/GetCollections", ReplyAction="http://tempuri.org/IEchoCollection/GetCollectionsResponse")]
        System.Threading.Tasks.Task<EchoService.DataContracts.GetCollectionsResponse> GetCollectionsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/GetItems", ReplyAction="http://tempuri.org/IEchoCollection/GetItemsResponse")]
        EchoService.DataContracts.GetItemsResponse GetItems();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/GetItems", ReplyAction="http://tempuri.org/IEchoCollection/GetItemsResponse")]
        System.Threading.Tasks.Task<EchoService.DataContracts.GetItemsResponse> GetItemsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/SaveCollection", ReplyAction="http://tempuri.org/IEchoCollection/SaveCollectionResponse")]
        EchoService.DataContracts.AddCollectionResponse SaveCollection(EchoService.DataContracts.AddCollectionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/SaveCollection", ReplyAction="http://tempuri.org/IEchoCollection/SaveCollectionResponse")]
        System.Threading.Tasks.Task<EchoService.DataContracts.AddCollectionResponse> SaveCollectionAsync(EchoService.DataContracts.AddCollectionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/UpdateCollection", ReplyAction="http://tempuri.org/IEchoCollection/UpdateCollectionResponse")]
        EchoService.DataContracts.AddCollectionResponse UpdateCollection(EchoService.DataContracts.AddCollectionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/UpdateCollection", ReplyAction="http://tempuri.org/IEchoCollection/UpdateCollectionResponse")]
        System.Threading.Tasks.Task<EchoService.DataContracts.AddCollectionResponse> UpdateCollectionAsync(EchoService.DataContracts.AddCollectionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/AddItem", ReplyAction="http://tempuri.org/IEchoCollection/AddItemResponse")]
        EchoService.DataContracts.AddItemResponse AddItem(EchoService.DataContracts.AddItemRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/AddItem", ReplyAction="http://tempuri.org/IEchoCollection/AddItemResponse")]
        System.Threading.Tasks.Task<EchoService.DataContracts.AddItemResponse> AddItemAsync(EchoService.DataContracts.AddItemRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/UpdateItem", ReplyAction="http://tempuri.org/IEchoCollection/UpdateItemResponse")]
        EchoService.DataContracts.AddItemResponse UpdateItem(EchoService.DataContracts.AddItemRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/UpdateItem", ReplyAction="http://tempuri.org/IEchoCollection/UpdateItemResponse")]
        System.Threading.Tasks.Task<EchoService.DataContracts.AddItemResponse> UpdateItemAsync(EchoService.DataContracts.AddItemRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/GetDocTypes", ReplyAction="http://tempuri.org/IEchoCollection/GetDocTypesResponse")]
        EchoService.DataContracts.GetDocumentTypeResponse GetDocTypes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/GetDocTypes", ReplyAction="http://tempuri.org/IEchoCollection/GetDocTypesResponse")]
        System.Threading.Tasks.Task<EchoService.DataContracts.GetDocumentTypeResponse> GetDocTypesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEchoCollectionChannel : EchoCollection.WebApi.EchoServiceClient.IEchoCollection, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EchoCollectionClient : System.ServiceModel.ClientBase<EchoCollection.WebApi.EchoServiceClient.IEchoCollection>, EchoCollection.WebApi.EchoServiceClient.IEchoCollection {
        
        public EchoCollectionClient() {
        }
        
        public EchoCollectionClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EchoCollectionClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EchoCollectionClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EchoCollectionClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public EchoService.DataContracts.GetCollectionsResponse GetCollections() {
            return base.Channel.GetCollections();
        }
        
        public System.Threading.Tasks.Task<EchoService.DataContracts.GetCollectionsResponse> GetCollectionsAsync() {
            return base.Channel.GetCollectionsAsync();
        }
        
        public EchoService.DataContracts.GetItemsResponse GetItems() {
            return base.Channel.GetItems();
        }
        
        public System.Threading.Tasks.Task<EchoService.DataContracts.GetItemsResponse> GetItemsAsync() {
            return base.Channel.GetItemsAsync();
        }
        
        public EchoService.DataContracts.AddCollectionResponse SaveCollection(EchoService.DataContracts.AddCollectionRequest request) {
            return base.Channel.SaveCollection(request);
        }
        
        public System.Threading.Tasks.Task<EchoService.DataContracts.AddCollectionResponse> SaveCollectionAsync(EchoService.DataContracts.AddCollectionRequest request) {
            return base.Channel.SaveCollectionAsync(request);
        }
        
        public EchoService.DataContracts.AddCollectionResponse UpdateCollection(EchoService.DataContracts.AddCollectionRequest request) {
            return base.Channel.UpdateCollection(request);
        }
        
        public System.Threading.Tasks.Task<EchoService.DataContracts.AddCollectionResponse> UpdateCollectionAsync(EchoService.DataContracts.AddCollectionRequest request) {
            return base.Channel.UpdateCollectionAsync(request);
        }
        
        public EchoService.DataContracts.AddItemResponse AddItem(EchoService.DataContracts.AddItemRequest request) {
            return base.Channel.AddItem(request);
        }
        
        public System.Threading.Tasks.Task<EchoService.DataContracts.AddItemResponse> AddItemAsync(EchoService.DataContracts.AddItemRequest request) {
            return base.Channel.AddItemAsync(request);
        }
        
        public EchoService.DataContracts.AddItemResponse UpdateItem(EchoService.DataContracts.AddItemRequest request) {
            return base.Channel.UpdateItem(request);
        }
        
        public System.Threading.Tasks.Task<EchoService.DataContracts.AddItemResponse> UpdateItemAsync(EchoService.DataContracts.AddItemRequest request) {
            return base.Channel.UpdateItemAsync(request);
        }
        
        public EchoService.DataContracts.GetDocumentTypeResponse GetDocTypes() {
            return base.Channel.GetDocTypes();
        }
        
        public System.Threading.Tasks.Task<EchoService.DataContracts.GetDocumentTypeResponse> GetDocTypesAsync() {
            return base.Channel.GetDocTypesAsync();
        }
    }
}

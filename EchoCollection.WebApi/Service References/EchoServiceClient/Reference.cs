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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/SaveCollection", ReplyAction="http://tempuri.org/IEchoCollection/SaveCollectionResponse")]
        EchoService.DataContracts.AddCollectionResponse SaveCollection(EchoService.DataContracts.AddCollectionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/SaveCollection", ReplyAction="http://tempuri.org/IEchoCollection/SaveCollectionResponse")]
        System.Threading.Tasks.Task<EchoService.DataContracts.AddCollectionResponse> SaveCollectionAsync(EchoService.DataContracts.AddCollectionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/SaveItem", ReplyAction="http://tempuri.org/IEchoCollection/SaveItemResponse")]
        EchoService.DataContracts.AddItemResponse SaveItem(EchoService.DataContracts.AddItemRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/SaveItem", ReplyAction="http://tempuri.org/IEchoCollection/SaveItemResponse")]
        System.Threading.Tasks.Task<EchoService.DataContracts.AddItemResponse> SaveItemAsync(EchoService.DataContracts.AddItemRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IEchoCollection/GetDataUsingDataContractResponse")]
        EchoService.CompositeType GetDataUsingDataContract(EchoService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoCollection/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IEchoCollection/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<EchoService.CompositeType> GetDataUsingDataContractAsync(EchoService.CompositeType composite);
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
        
        public EchoService.DataContracts.AddCollectionResponse SaveCollection(EchoService.DataContracts.AddCollectionRequest request) {
            return base.Channel.SaveCollection(request);
        }
        
        public System.Threading.Tasks.Task<EchoService.DataContracts.AddCollectionResponse> SaveCollectionAsync(EchoService.DataContracts.AddCollectionRequest request) {
            return base.Channel.SaveCollectionAsync(request);
        }
        
        public EchoService.DataContracts.AddItemResponse SaveItem(EchoService.DataContracts.AddItemRequest request) {
            return base.Channel.SaveItem(request);
        }
        
        public System.Threading.Tasks.Task<EchoService.DataContracts.AddItemResponse> SaveItemAsync(EchoService.DataContracts.AddItemRequest request) {
            return base.Channel.SaveItemAsync(request);
        }
        
        public EchoService.CompositeType GetDataUsingDataContract(EchoService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<EchoService.CompositeType> GetDataUsingDataContractAsync(EchoService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}

using EchoService.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EchoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEchoCollection
    {

        [OperationContract]
        GetCollectionsResponse GetCollections();

        [OperationContract]
        GetItemsResponse GetItems();

        [OperationContract]
        AddCollectionResponse SaveCollection(AddCollectionRequest request);

        [OperationContract]
        AddItemResponse SaveItem(AddItemRequest request);

        [OperationContract]
        GetDocumentTypeResponse GetDocTypes();

        // TODO: Add your service operations here
    }
}

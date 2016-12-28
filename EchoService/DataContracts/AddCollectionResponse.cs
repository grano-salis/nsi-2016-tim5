using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EchoService.DataContracts
{
    [DataContract]
    public class AddCollectionResponse : Response
    {
        [DataMember]
        public int CollectionId { get; set; }
    }
}
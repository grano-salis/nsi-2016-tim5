using EchoService.DataContracts;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EchoService.DataContracts
{
    [DataContract]
    public class GetCollectionsResponse : Response
    {
        [DataMember]
        public List<Collection> collections { get; set; }
    }
}
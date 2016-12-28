using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EchoService
{
    [DataContract]
    public class AddCollectionRequest
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Title { get; set; }
    }
}
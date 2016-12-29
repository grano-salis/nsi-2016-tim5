using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EchoService.DataContracts
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int CollectionId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int DocumentTypeId { get; set; }

        [DataMember]
        public bool IsPrivate { get; set; }

        [DataMember]
        public Metadata Metadata { get; set; }
    }
}
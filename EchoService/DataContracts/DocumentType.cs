using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EchoService.DataContracts
{
    [DataContract]
    public class DocumentType
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string DocumentTypeTitle { get; set; }
    }
}
using EchoService.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EchoService.DataContracts
{
    [DataContract]
    public class AddCollectionRequest
    {
       [DataMember]
       public Collection Collection { get; set; } 
    }
}
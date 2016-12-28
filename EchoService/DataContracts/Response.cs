using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EchoService.DataContracts
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public ResponseType ResponseType { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
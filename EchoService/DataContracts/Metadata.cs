using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EchoService.DataContracts
{
    [DataContract]
    public class Metadata
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int ItemId { get; set; }

        [DataMember]
        public int DocumentTypeId { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public string Abstract { get; set; }

        [DataMember]
        public string Publisher { get; set; }

        [DataMember]
        public string Language { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string Rights { get; set; }

        [DataMember]
        public string Extra { get; set; }

        [DataMember]
        public DateTime Date { get; set; }
    }
}
using EchoCollection.WebApi.Models;
using EchoService.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchoCollection.Api.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DocumentType DocumentType { get; set; }
        public bool IsPrivate { get; set; }
        public int CollectionId { get; set; }
        public string Attachment { get; set; }
        public EchoCollection.WebApi.Models.Metadata Metadata { get; set; }
    }
}
using EchoCollection.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchoCollection.Api.Models
{
    public class Item
    {
        public string Title { get; set; }
        public string DocumentType { get; set; }
        public bool IsPrivate { get; set; }
        public Metadata Metadata { get; set; }
    }
}
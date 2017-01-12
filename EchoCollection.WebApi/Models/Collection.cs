using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchoCollection.Api.Models
{
    public class Collection
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public List<Item> Items { get; set; }
    }
}
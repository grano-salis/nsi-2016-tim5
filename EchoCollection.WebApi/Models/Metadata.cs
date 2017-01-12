using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchoCollection.WebApi.Models
{
    public class Metadata
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string Abstract { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public string Url { get; set; }
        public string Rights { get; set; }
        public string Extra { get; set; } 
        public DateTime Date { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchoCollection.WebApi.Models
{
    [Serializable]
    public class CSLCompatibleItem
    {
        public string id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string @abstract { get; set; }
        public List<Author> author { get; set; }
        public string issued { get; set; }
        public string language { get; set; }
        public string publisher { get; set; }
        public string note { get; set; }
        public string URL { get; set; }
    }
}
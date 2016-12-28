using System.Runtime.Serialization;

namespace EchoService
{
    [DataContract]
    public class GetCollectionsResponse
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Title { get; set; }
    }
}
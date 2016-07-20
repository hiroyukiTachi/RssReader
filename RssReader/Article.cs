using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RssReader
{
    [DataContract]
    public class Article
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string PublishedData { get; set; }
    }
}


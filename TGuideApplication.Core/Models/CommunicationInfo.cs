using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TGuideApplication.Core.Models
{
    public class CommunicationInfo
    {
        public string Info { get; set; }
        public ICollection<CommunicationType> CommunicationType { get; set; }
    }
}

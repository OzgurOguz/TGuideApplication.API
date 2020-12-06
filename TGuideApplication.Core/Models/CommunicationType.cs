using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TGuideApplication.Core.Models
{
    public class CommunicationType
    {
        public string  TelNo{ get; set; }
        public string  Email{ get; set; }
        public string  Location{ get; set; }
    }
}

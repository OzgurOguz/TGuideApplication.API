

using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using TGuideApplication.Core.DbModels;
using TGuideApplication.Core.IRepository;
using TGuideApplication.Core.Models;

namespace TGuideApplication.Servicee.Services
{
    public class TGuidePublisherModelRepository : ITGuidePublisherModelRepository
    {
        private readonly ObjectContext _context = null;

        public TGuidePublisherModelRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public List<TGuidePublisherModel> TGuidePublisherModelRepositoryData()
        {

            var communicationData = _context.PersonInfo.Aggregate().Unwind("CommunicationInfo").Project(new BsonDocument() { { "_id", 0 }, { "TelNo", "$CommunicationInfo.CommunicationType.TelNo" }, { "Email", "$CommunicationInfo.CommunicationType.Email" }, { "Location", "$CommunicationInfo.CommunicationType.Location" } });
            var communicationDataList = communicationData.ToListAsync().Result;
            var communicationDataListDistinct = communicationDataList.ToList().Select(x => x.GetElement("Location")).ToList().Distinct().ToList();
            var communicationDataObj = JsonConvert.DeserializeObject(communicationDataListDistinct.ToJson());


            List<TGuidePublisherModel> communicationType = new List<TGuidePublisherModel>();
            List<PersonInfo> personInfo = _context.PersonInfo.Find(x => true).ToList();

            JArray jArray = (JArray)communicationDataObj;
            foreach (var item in jArray.Root)
            {
                TGuidePublisherModel c = new TGuidePublisherModel();
                c.Location = item["Value"].First().ToString();
                c.NumberOfPersonLocated = personInfo.Select(c => c.CommunicationInfo.SelectMany(bb => bb.CommunicationType).Where(b => b.Location == item["Value"].First.ToString())).Count();
                c.NumberOfTelLocated = personInfo.SelectMany(tt => tt.CommunicationInfo.SelectMany(a => a.CommunicationType).Where(b => b.Location == item["Value"].First.ToString())).Count();
              
                communicationType.Add(c);
            }

            return communicationType;
        }
    }

}

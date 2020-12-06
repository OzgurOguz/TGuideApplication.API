using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using TGuideApplication.Core.Models;

namespace TGuideApplication.Core.DbModels
{
    public class ObjectContext
    {
        public IConfigurationRoot Configuration { get; }
        private IMongoDatabase _db = null;

        public ObjectContext(IOptions<Settings> settings)
        {
            Configuration = settings.Value.IConfigurationRoot;
            settings.Value.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            settings.Value.Database = Configuration.GetSection("MongoConnection:Database").Value;
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _db = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<PersonInfo> PersonInfo
        {
            get
            {
                return _db.GetCollection<PersonInfo>("PersonInfo");
            }
        }
    }
}

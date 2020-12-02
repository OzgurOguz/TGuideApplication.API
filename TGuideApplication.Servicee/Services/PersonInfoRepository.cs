using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGuideApplication.Core.DbModels;
using TGuideApplication.Core.IRepository;
using TGuideApplication.Core.Models;

namespace TGuideApplication.Servicee.Services
{
    public class PersonInfoRepository : IPersonInfoRepository
    {

        private readonly ObjectContext _context = null;

        public PersonInfoRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public async Task AddDataAsync(PersonInfo personInfo)
        {
            await _context.PersonInfo.InsertOneAsync(personInfo);
        }

        public async Task<DeleteResult> DeleteAllDataAsync()
        {
            return await _context.PersonInfo.DeleteManyAsync(new BsonDocument());
        }

        public async Task<DeleteResult> DeleteDataAsync(string id)
        {
            return await _context.PersonInfo.DeleteOneAsync(Builders<PersonInfo>.Filter.Eq("Id", id));
        }

        public async Task<IEnumerable<PersonInfo>> GetAllDataAsync()
        {
            return await _context.PersonInfo.Find(x => true).ToListAsync();
        }

        public async Task<PersonInfo> GetDataAsync(string id)
        {
            var personInfo = Builders<PersonInfo>.Filter.Eq("Id", id);
            return await _context.PersonInfo.Find(personInfo).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateDataAsync(string id, PersonInfo personInfo)
        {
            await _context.PersonInfo.ReplaceOneAsync(pi => pi.Id == id, personInfo);
            return "";
        }


  

    }
}

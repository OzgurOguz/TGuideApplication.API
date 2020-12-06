using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TGuideApplication.Core.Models;

namespace TGuideApplication.Core.IRepository
{
    public interface IPersonInfoRepository
    {
        Task<IEnumerable<PersonInfo>> GetAllDataAsync();
        public Task<PersonInfo> GetDataAsync(string id);
        Task AddDataAsync(PersonInfo personInfo);
        public Task<string> UpdateDataAsync(string id, PersonInfo personInfo);
        Task<DeleteResult> DeleteDataAsync(string id);
        Task<DeleteResult> DeleteAllDataAsync();
    }
}

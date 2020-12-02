using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TGuideApplication.Core.DbModels;
using TGuideApplication.Core.IRepository;

namespace TGuideApplication.Servicee.Services
{
    public class UnitOfWork //: IUnitOfWork
    {

        //private PersonInfoRepository _personInfoRepository;
        //private CommunicationInfoRepository _communicationInfoRepository;

        //private readonly ObjectContext _context;
        //public IPersonInfoRepository PersonInfos => _personInfoRepository = _personInfoRepository ?? new PersonInfoRepository((IOptions<Settings>)_context);
        //public ICommunicationInfoRepository CommunicationInfos => _communicationInfoRepository = _communicationInfoRepository ?? new CommunicationInfoRepository(_context);

        //private readonly List<Func<Task>> _commands;

        //public UnitOfWork(ObjectContext settings)
        //{
        //    _context = new ObjectContext((IOptions<Settings>)settings);


        //}

    //    private PersonInfoRepository _personInfoRepository;
    //    private CommunicationInfoRepository _communicationInfoRepository;
    //    private readonly ObjectContext _context;
    //    private MongoClient _client;
    //    public IPersonInfoRepository PersonInfos => _personInfoRepository = _personInfoRepository ?? new PersonInfoRepository((IOptions<Settings>)_context);
    //    public ICommunicationInfoRepository CommunicationInfos => _communicationInfoRepository = _communicationInfoRepository ?? new CommunicationInfoRepository(_context);
    //    public UnitOfWork(ObjectContext context, MongoClient client)
    //    {
    //        _context = context;
    //        _context.
    //    }

    //    public void Save()
    //    {
    //        try
    //        {
    //            using (var transaction = client.GetDatabase(_context.Configuration.GetSection("MongoConnection:Database").Value).BeginTransaction())
    //            {
    //                try
    //                {
    //                    _context.SaveChanges();
    //                    transaction.Commit();
    //                }
    //                catch
    //                {
    //                    transaction.Rollback();
    //                    throw;
    //                }
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //        TODO: Logging
    //        }
    //    }
    //}


}
}

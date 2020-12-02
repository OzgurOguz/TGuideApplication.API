using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TGuideApplication.Core.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommmitAsync();
        void Commit();

        public IPersonInfoRepository PersonInfos { get;  }

    }
}

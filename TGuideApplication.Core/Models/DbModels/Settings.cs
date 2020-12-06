using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace TGuideApplication.Core.DbModels
{
    public class Settings
    {

        public string ConnectionString;
        public string Database;
        public IConfigurationRoot IConfigurationRoot;

    }
}

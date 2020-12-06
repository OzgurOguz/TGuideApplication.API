using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGuideApplication.Core.DbModels;
using TGuideApplication.Core.IMessageQueue;
using TGuideApplication.Core.IRepository;
using TGuideApplication.Core.Models;
using TGuideApplication.Servicee.Services;

namespace TGuideApplication.MessageQueue
{

    public class TGuidePublisher : IPublisher
    {

        public ITGuidePublisherModelRepository _tGuidePublisherModelRepository;
        public IConfigurationRoot Configuration { get; set; }

        public TGuidePublisher(ITGuidePublisherModelRepository tGuidePublisherModelRepository, IOptions<Settings> settings)
        {
            _tGuidePublisherModelRepository = tGuidePublisherModelRepository;
            Configuration = settings.Value.IConfigurationRoot;

        }

        public void Publisher()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri(Configuration.GetSection("RabbitMqConnection:Uri").Value);  
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("TGuide-Info", true, false, false, null);

                    String mesage = JsonConvert.SerializeObject(_tGuidePublisherModelRepository.TGuidePublisherModelRepositoryData());
                    var byteMessage = System.Text.Encoding.UTF8.GetBytes(mesage);

                    channel.BasicPublish("", "TGuide-Info", false, null, byteMessage);
                }
            }
        }
    }
}

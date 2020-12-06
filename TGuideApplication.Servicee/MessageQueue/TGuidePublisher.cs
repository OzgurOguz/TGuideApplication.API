using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGuideApplication.Core.IMessageQueue;
using TGuideApplication.Core.IRepository;
using TGuideApplication.Core.Models;
using TGuideApplication.Servicee.Services;

namespace TGuideApplication.MessageQueue
{


    public class TGuidePublisher : IPublisher
    {

        public TGuidePublisherModelRepository _tGuidePublisherModelRepository;
        public TGuidePublisher(TGuidePublisherModelRepository tGuidePublisherModelRepository)
        {
            _tGuidePublisherModelRepository = tGuidePublisherModelRepository;
        }

        public void Publisher()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://nohtjnhs:ov2OEjCyIJuw09Oum-bmsed6Fx_DPGFm@jaguar.rmq.cloudamqp.com/nohtjnhs");
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

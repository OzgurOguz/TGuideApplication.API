using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using TGuideApplication.Core.IRepository;
using TGuideApplication.Core.Models;
using TGuideApplication.Servicee.Services;

namespace TGuideApplication.Controllers
{
    [Route("api/[controller]")]
    public class TGuidePublisherModelController : Controller
    {
       // private readonly IPublishEndpoint _publishEndpoint;
        //private readonly IBusControl _bus;

        public TGuidePublisherModelRepository _tGuidePublisherModelRepository;

        public TGuidePublisherModelController( TGuidePublisherModelRepository tGuidePublisherModelRepository)
        {
          //  _bus = bus;
            //this._publishEndpoint = publishEndpoint;
            _tGuidePublisherModelRepository = tGuidePublisherModelRepository;
        }

        //[HttpGet]
        //public async void TGuidePublisherModelRepository()
        //{

        //    await _bus.Publish<TGuidePublisherModel>(_tGuidePublisherModelRepository.TGuidePublisherModelRepositoryData());
            
        //}
    }
}

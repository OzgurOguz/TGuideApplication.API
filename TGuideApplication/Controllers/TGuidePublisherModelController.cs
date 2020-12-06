
using Microsoft.AspNetCore.Mvc;
using TGuideApplication.Servicee.Services;

namespace TGuideApplication.Controllers
{
    [Route("api/[controller]")]
    public class TGuidePublisherModelController : Controller
    {
        public TGuidePublisherModelRepository _tGuidePublisherModelRepository;

        public TGuidePublisherModelController(TGuidePublisherModelRepository tGuidePublisherModelRepository)
        {
            _tGuidePublisherModelRepository = tGuidePublisherModelRepository;
        }

    }
}

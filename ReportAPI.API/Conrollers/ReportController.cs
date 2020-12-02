using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace ReportAPI.API.Conrollers
{
    [Route("api/[controller]")]
    public class ReportController:Controller
    {
        [HttpGet]
        public void TGuidePublisherModelRepository()
        {
            //return _personInfoRepository.TGuidePublisherModelRepository();
        }
    }
}

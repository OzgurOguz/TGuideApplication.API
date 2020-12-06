using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGuideApplication.Core.IRepository;
using TGuideApplication.Core.Models;
using TGuideApplication.Core.Models.FilterModels;

namespace TGuideApplication.Filters
{
    public class NotFoundFilterPersonInfo:ActionFilterAttribute
    {

        private readonly IPersonInfoRepository _personInfoRepository;

        public NotFoundFilterPersonInfo(IPersonInfoRepository personInfoRepository)
        {
            _personInfoRepository = personInfoRepository;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var personInfo = new PersonInfo();
            ErrorModel error = new ErrorModel();

            string id = (string)context.ActionArguments.Values.FirstOrDefault();
            try
            {
                 personInfo = await _personInfoRepository.GetDataAsync(id);
            }
            catch (Exception)
            {
                error.status = 404;
            }
            

            if (personInfo != null && error.status==0)
            {
                await next();
            }
            else 
            {
                error.status = 404;
                error.Errors.Add($"id'si {id} olan data veri tabanında bulunamadı");
                context.Result = new NotFoundObjectResult(error);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TGuideApplication.Core.Models.FilterModels
{
    public class ErrorModel
    {
        public ErrorModel()
        {
            Errors = new List<string>();
        }
        public List<String> Errors { get; set; }
        public int status { get; set; }
    }
}

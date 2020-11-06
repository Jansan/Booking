using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Web.Filters
{
    public class RequiredIdRequiredModelFilter : ActionFilterAttribute
    {
        private readonly string parameterName;

        public RequiredIdRequiredModelFilter(string parameterName)
        {
            this.parameterName = parameterName;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.RouteData.Values[parameterName] == null)
            {
                context.Result = new NotFoundResult();
            }
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ViewResult viewResult)
            {
                if (viewResult.Model is null) context.Result = new NotFoundResult();
            }
        }
    }
}

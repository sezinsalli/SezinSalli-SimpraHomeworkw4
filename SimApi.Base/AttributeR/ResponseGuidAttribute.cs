using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Base.AttributeR
{
    public class ResponseGuidAttribute : ActionFilterAttribute
    {
        public ResponseGuidAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("ResponseGuid", Guid.NewGuid().ToString());
            base.OnActionExecuted(context);
        }
    }
}

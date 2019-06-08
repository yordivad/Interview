using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Epic.Interview.Services.Filters
{
    public class ReactiveFilter  : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
           
            await next();
            var x = context.Result;
            
        }
    }
}
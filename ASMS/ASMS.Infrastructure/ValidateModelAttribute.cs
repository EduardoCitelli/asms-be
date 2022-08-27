using ASMS.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASMS.Infrastructure
{
    public class ValidateModelAttribute : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.SelectMany(x => x.Value.Errors)
                                               .Select(x => x.ErrorMessage)
                                               .ToList();

                throw new BadRequestException(errors);
            }

            var result = await next();
        }
    }
}

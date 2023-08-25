using ErpAPI.Api.Validation.FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ErpAPI.Api.Aspects
{
    public class ValidationFilter : Attribute, IAsyncActionFilter
    {
        private readonly Type _validationtype;
         
        public ValidationFilter(Type validationtype)
        {
            _validationtype = validationtype;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ValidationHelper.Validate(_validationtype, context.ActionArguments.Values.ToArray());

            await next();
        }
    }
}

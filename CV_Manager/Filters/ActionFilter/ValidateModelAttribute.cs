using CV_Manager.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CV_Manager.Filters.ActionFilter
{
    public class ValidateModelAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                // Model state is not valid, return a response indicating the validation errors
                var _resutl = new CommonResponse<object>
                {
                    RequestStatus = Core.Constant.RequestStatus.BadRequest,
                    Message = "BadRequest",
                    ModelError = context.ModelState.Values.SelectMany(v => v.Errors).Select(c => c.ErrorMessage).ToList()
                };
                context.Result = new BadRequestObjectResult(_resutl);
            }

        }
    }
}

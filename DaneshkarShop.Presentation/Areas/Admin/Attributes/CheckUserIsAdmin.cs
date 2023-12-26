using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Application.Utilities;
using DaneshkarShop.Domain.Entities.Role;
using DaneshkarShop.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Filters;
using static System.Net.Mime.MediaTypeNames;

namespace DaneshkarShop.Presentation.Areas.Admin.Attributes
{
    public class CheckUserIsAdmin : ActionFilterAttribute
    {
        
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
           
            var service = (IRoleService)context.HttpContext.RequestServices.GetService(typeof(IRoleService))!;
            int userId = (int)context.HttpContext.User.GetUserId();
            await base.OnActionExecutionAsync(context, next);

            // user is admin?
            if (await service.IsUserAdmin(userId) == false)
            {
                context.HttpContext.Response.Redirect("/");
            }
        }
    }
}

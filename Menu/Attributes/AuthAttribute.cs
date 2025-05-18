using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Menu.Attributes
{
    public class AuthAttribute : ActionFilterAttribute
    {
        private string[] Role;
        public AuthAttribute(string role)
        { 
            Role = role.Split(',');
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;

            try
            {
                //Get Session
                var user = httpContext.Session.GetString("_Id");
                var role = httpContext.Session.GetString("_Role");
                //Check Session
                if (!Role.Contains(role))
                {
                    context.Result = new RedirectToActionResult("Login", "User", null);
                }
            }
            catch (Exception e)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }

        }
    }
}

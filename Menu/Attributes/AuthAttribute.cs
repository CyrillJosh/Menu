using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Menu.Attributes
{
    public class AuthAttribute : ActionFilterAttribute
    {
        private string Role;
        private bool Auth;
        public AuthAttribute(string role, bool auth)
        { 
            Role = role;
            Auth = auth;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;

            var user = httpContext.Session.GetString("_Id");
            



        }
    }
}

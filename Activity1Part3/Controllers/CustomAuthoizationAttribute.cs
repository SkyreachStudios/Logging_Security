using Activity1Part3.Models;
using Activity1Part3.Services.Business;
using System;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    internal class CustomAuthoizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            SecurityService service = new SecurityService();

            //get user from a session variable

            UserModel user = (UserModel)filterContext.HttpContext.Session["user"];
            bool success = false;

            //checking if user is null
            if(user != null)
            {
                success = service.Authenticate(user);
            }

            if (success)
            {
                //do nothing, allow events to continue as normal as user has been logged in!!
            }
            else
            {
                filterContext.Result = new RedirectResult("/login");

            }


        }
    }
}
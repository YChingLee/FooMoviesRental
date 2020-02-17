using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace FooMoviesRental.Filters
{
    public class UserAuthFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //Logic for authenticating a user 
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["Username"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        //Runs after the OnAuthentication method    
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //TODO: Additional tasks on the request
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                            { "controller", "Account" },
                            { "action", "Login" }
                    }
                );
                //filterContext.Result = new RedirectResult("~/Home/Index");
            }
        }
    }
}
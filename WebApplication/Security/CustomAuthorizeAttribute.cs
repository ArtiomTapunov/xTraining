using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication.Models;

namespace WebApplication.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (String.IsNullOrEmpty(SessionPersister.Username))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    (new { Controller = "AccessDenied", Action = "Index" }));
            else
            {
                using (MyDbContext db = new MyDbContext())
                {
                    CustomPrincipal mp = new CustomPrincipal(db.userAccount.Where(acc => acc.Username.Equals(SessionPersister.Username)).FirstOrDefault());
                    if (!mp.IsInRole(Roles))
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                            (new { Controller = "AccessDenied", Action = "Index" }));
                    }
                }
            }
        }
    }
}
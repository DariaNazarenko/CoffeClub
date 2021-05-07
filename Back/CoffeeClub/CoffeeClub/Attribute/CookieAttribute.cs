using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoffeeClub.Attribute
{
    public class CookieAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var res = filterContext.Result.GetType().Name;
            //var r = filterContext.HttpContext.Request.Cookies.ContainsKey("DeletedCoffee");
            if (res != "BadRequestResult" && res != "NotFoundResult")
            {
                var routeData = filterContext.RouteData.Values;
                var name = routeData["name"];
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(1);
                cookieOptions.IsEssential = true;


                filterContext.HttpContext.Response.Cookies.Append("DeletedCoffee", name.ToString(), cookieOptions);
            }
        }
    }
}

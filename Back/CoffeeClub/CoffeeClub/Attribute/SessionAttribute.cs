using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeClub.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoffeeClub.Attribute
{
    public class SessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Cookies.ContainsKey("DeletedCoffee"))
            {
                var routeData = filterContext.RouteData.Values;
                var name = routeData["name"];

                filterContext.HttpContext.Session.SetString("DeletedCoffeeName", (string)name);
            }
        }
    }
}

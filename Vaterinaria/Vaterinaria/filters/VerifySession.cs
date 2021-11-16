using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vaterinaria.Controllers;
using Vaterinaria.Models;

namespace Vaterinaria.filtres
{
    public class VerifySession : ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //var user = (personal)HttpContext.Current.Session["User"];
            

        //    //if(user == null)
        //    //{
        //    //    if(filterContext.Controller is HomeController == false)
        //    //    {
        //    //        filterContext.HttpContext.Response.Redirect("~/Home/Login");
        //    //    }
        //    //}else
        //    //{
        //    //    if (filterContext.Controller is HomeController == true)
        //    //    {
        //    //        filterContext.HttpContext.Response.Redirect("~/personal/Index");
        //    //    }
        //    //}

        //    var userc = (UsuarioCliente)HttpContext.Current.Session["UserC"];
        //    if (userc == null)
        //    {
        //        if (filterContext.Controller is HomeController == false)
        //        {
        //            filterContext.HttpContext.Response.Redirect("~/Home/Login");
        //        }
        //    }
        //    else
        //    {
        //        if (filterContext.Controller is HomeController == true)
        //        {
        //            filterContext.HttpContext.Response.Redirect("~/Cliente/Index");
        //        }
        //    }

        //    base.OnActionExecuting(filterContext);
        //}
    }
}
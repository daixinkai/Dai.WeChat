using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dai.WeChat.TestWeb
{
    class Register : IRegister
    {
        void IRegister.Register()
        {

        }

        [PostApplicationStart]
        static void ApplicationStart()
        {
            AspNetMvcConfig.RemoveWebFormViewEngine();

            //AreaRegistration.RegisterAllAreas();


            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
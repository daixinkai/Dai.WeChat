using Dai.WeChat.TestWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dai.WeChat.TestWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //var test = WeChatHelper.ToEnum<MessageType>("text");
            return Content("ok");
        }
    }
}
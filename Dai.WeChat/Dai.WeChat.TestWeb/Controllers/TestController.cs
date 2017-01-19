using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dai.WeChat.TestWeb.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult CreateMenu()
        {

            CustomMenu menu = new CustomMenu();

            menu.Add(new WeChatClickButton()
            {
                Key = "button1",
                Name = "按钮1"
            });

            var parentButton = new WeChatParentButton()
            {
                Name = "按钮2"
            };

            parentButton.Add(new WeChatViewButton()
            {
                Name = "页面2-1",
                Url = "http://openwx.cn"
            });

            parentButton.Add(new WeChatClickButton()
            {
                Name = "按钮2-1",
                Key = "button2-1"
            });

            menu.Add(parentButton);


            menu.Add(new WeChatViewButton()
            {
                Name = "页面3",
                Url = "http://openwx.cn"
            });

            AccessToken accessToken = AccessToken.Get("wxb43ab71368baff54", "8148081e1e0307789026db4f63ce40fb");

            var response = WeiXinApiHelper.CreateMenu(accessToken.ToString(), menu);

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}
using Dai.WeChat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dai.WeChat.TestWeb.Controllers
{
    public class TestController : Controller
    {

        string appId = "wxb43ab71368baff54";

        string appSecret = "8148081e1e0307789026db4f63ce40fb";

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

            AccessToken accessToken = AccessToken.Get(appId, appSecret);

            var response = WeiXinApiHelper.CreateMenu(accessToken.ToString(), menu);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserList()
        {


            AccessToken accessToken = AccessToken.Get(appId, appSecret);

            WeChatApiResponse state;

            var response = WeiXinApiHelper.GetUserList(accessToken.ToString(), out state);

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}
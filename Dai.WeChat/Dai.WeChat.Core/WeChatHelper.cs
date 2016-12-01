using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dai.WeChat
{
    public static class WeChatHelper
    {
        #region EchoPass

        /// <summary>
        /// 告知微信服务器，已通过验证
        /// </summary>
        public static void EchoPass(this HttpContext context, string echostr)
        {
            context.Response.Write(echostr);
            context.Response.Flush();
        }

        /// <summary>
        /// 告知微信服务器，已通过验证
        /// </summary>
        public static void EchoPass(this HttpContext context)
        {
            context.EchoPass(context.Request["echostr"]);
        }

        /// <summary>
        /// 告知微信服务器，已通过验证
        /// </summary>
        public static void EchoPass(string echostr)
        {
            HttpContext.Current.EchoPass(echostr);
        }

        /// <summary>
        /// 告知微信服务器，已通过验证
        /// </summary>
        public static void EchoPass()
        {
            EchoPass(HttpContext.Current.Request["echostr"]);
        }

        #endregion
    }
}

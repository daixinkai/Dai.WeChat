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


        #region Internal

        /// <summary>
        /// 将字符串转换为指定枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strValue"></param>
        /// <returns></returns>

        internal static T ToEnum<T>(string strValue) where T : struct
        {
            T t = default(T);
            return Enum.TryParse<T>(strValue, true, out t) ? t : default(T);
        }

        #endregion

    }
}

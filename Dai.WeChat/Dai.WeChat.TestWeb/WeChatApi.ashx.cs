using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dai.WeChat;
using Dai.WeChat.TestWeb.Models;
using Dai.WeChat.Request;
using System.Text;
using System.Xml;

namespace Dai.WeChat.TestWeb
{
    /// <summary>
    /// WeChatApi 的摘要说明
    /// </summary>
    public class WeChatApi : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            //LogBody(context);
            string sToken = "daixinkai";
            string sEncodingAESKey = "gGnOmL5YyOlkAAcLhbogPU2wmLeboUzYlnTDwZ0231t";

            DefaultEncodingAESKeyProvider encodingAESKeyProvider = new DefaultEncodingAESKeyProvider(sToken, sEncodingAESKey, context.Request.QueryString);

            if (context.Request.InputStream == null)
            {

                if (string.IsNullOrEmpty(encodingAESKeyProvider.MsgSignature))
                {
                    context.EchoPass();
                    return;
                }
                context.EchoPass(encodingAESKeyProvider.GetEchoString(context.Request["echostr"]));
                return;
            }

            LogHelper.Debug(RequestMessageBase.GetRequestXmlString(context.Request.InputStream, encodingAESKeyProvider));
            context.Request.InputStream.Position = 0;
            var requestMessage = RequestMessageBase.GetInstance(context.Request.InputStream, encodingAESKeyProvider);

            if (requestMessage == null)
            {
                LogHelper.Debug("requestMessage=null");
                LogBody(context);
                return;
            }
            LogHelper.Debug(requestMessage.ToString());
            try
            {
                var response = DirectiveCenter.GetResponse(requestMessage).GetResponse();

                LogHelper.Debug(requestMessage.GetType().ToString());

                LogHelper.Debug(response);

                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            //context.Request.InputStream.Position = 0;
            //XmlDocument xml = new XmlDocument();

            //xml.Load(context.Request.InputStream);

            //LogHelper.Debug(context.Request.QueryString.ToString());

            //LogHelper.Debug(xml.InnerXml);

        }


        void LogBody(HttpContext context)
        {
            context.Request.InputStream.Position = 0;
            XmlDocument xml = new XmlDocument();

            xml.Load(context.Request.InputStream);

            LogHelper.Debug(context.Request.QueryString.ToString());

            LogHelper.Debug(xml.InnerXml);
            context.Request.InputStream.Position = 0;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
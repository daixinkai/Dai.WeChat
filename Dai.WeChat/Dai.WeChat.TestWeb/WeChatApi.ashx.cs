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
            //LogHelper.Debug(context.Request.InputStream.Length.ToString());
            //LogHelper.Debug(context.Request.QueryString.ToString() + "\r\n" + context.Request.Form.ToString());

            //


            if (context.Request.InputStream == null)
            {
                context.EchoPass();
                return;
            }

            var requestMessage = RequestMessageBase.GetInstance(context.Request.InputStream);

            if (requestMessage == null)
            {
                LogHelper.Debug("requestMessage=null");
            }

            context.Request.InputStream.Position = 0;
            XmlDocument xml = new XmlDocument();

            xml.Load(context.Request.InputStream);
            LogHelper.Debug(xml.InnerXml);
            return;
            if (xml.FirstChild == null)
            {
                LogHelper.Debug("xml.FirstChild=null");
            }
            else
            {
                LogHelper.Debug(xml.FirstChild.InnerXml);
                XmlNode tempNode = xml.FirstChild.SelectSingleNode("MsgType");
                LogHelper.Debug(tempNode.InnerText);
                //LogHelper.Debug(WeChatHelper.ToEnum<MessageType>(tempNode.InnerText).ToString());
            }
            LogHelper.Debug(xml.InnerXml);

            try
            {
                LogHelper.Debug(requestMessage.ToString());
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            //XmlDocument xml = new XmlDocument();

            //xml.Load(context.Request.InputStream);

            ////var buffer = new byte[context.Request.InputStream.Length];

            ////context.Request.InputStream.Read(buffer, 0, buffer.Length);

            ////string xml = Encoding.UTF8.GetString(buffer);

            ////LogHelper.Debug(xml.FirstChild.InnerText);

            //LogHelper.Debug(xml.InnerXml);
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
using Dai.WeChat.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dai.WeChat.Request
{
    /// <summary>
    /// 表示接收的消息
    /// </summary>
    public abstract class RequestMessageBase : MessageBase
    {
        ///// <summary>
        ///// 开发者填写URL，调试时将把消息推送到该URL上
        ///// </summary>
        //public string Url { get; set; }

        /// <summary>
        /// 获取或设置加密解密消息提供者
        /// </summary>
        internal IEncodingKeyProvider EncodingKeyProvider { get; set; }

        /// <summary>
        /// 获取或设置接收的XML数据
        /// </summary>
        protected XmlNode Node { get; set; }

        /// <summary>
        /// 获取具体的接收实例
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected virtual RequestMessageBase Parse() { return this; }


        /// <summary>
        /// 从当前消息创建一个用于回复的消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ToResponseMessage<T>() where T : ResponseMessageBase, new()
        {
            return new T()
            {
                FromUserName = this.ToUserName,
                ToUserName = this.FromUserName,
                CreateTime = this.CreateTime,
                EncodingKeyProvider = EncodingKeyProvider
            };
        }

        #region Instance

        public static string GetRequestXmlString(Stream xmlStream, IEncodingKeyProvider encodingKeyProvider)
        {
            if (xmlStream == null || xmlStream.Length == 0)
            {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlStream);
            XmlNode firstNode = doc.FirstChild;
            if (firstNode == null)
            {
                return null;
            }
            if (encodingKeyProvider != null)
            {
                encodingKeyProvider.InitFromXmlNode(firstNode);
            }
            var encryptXml = firstNode.GetInnerXml("Encrypt");
            if (encryptXml != null)
            {
                return encodingKeyProvider.Decrypt(encryptXml);
            }
            return doc.InnerXml;
        }

        /// <summary>
        /// 得到具体的消息处理实例
        /// </summary>
        /// <param name="xmlStream"></param>
        /// <returns></returns>
        public static RequestMessageBase GetInstance(Stream xmlStream, IEncodingKeyProvider encodingKeyProvider)
        {
            if (xmlStream == null || xmlStream.Length == 0)
            {
                return null;
            }
            ////得到请求的内容
            //byte[] bytes = new byte[xmlStream.Length];
            //xmlStream.Read(bytes, 0, (int)xmlStream.Length);
            //string xml = Encoding.UTF8.GetString(bytes);
            //return GetInstance(xml);

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlStream);
            return GetInstance(doc, encodingKeyProvider, false);
        }

        /// <summary>
        /// 得到具体的消息处理实例
        /// </summary>
        /// <param name="xmlStream"></param>
        /// <returns></returns>
        public static RequestMessageBase GetInstance(Stream xmlStream)
        {
            return GetInstance(xmlStream, null);
        }

        /// <summary>
        /// 得到具体的消息处理实例
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static RequestMessageBase GetInstance(string xml, IEncodingKeyProvider encodingKeyProvider)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return GetInstance(doc, encodingKeyProvider, false);
        }

        /// <summary>
        /// 得到具体的消息处理实例
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static RequestMessageBase GetInstance(string xml)
        {
            return GetInstance(xml, null);
        }

        static RequestMessageBase GetInstance(XmlDocument doc, IEncodingKeyProvider encodingKeyProvider, bool encoding)
        {
            RequestMessageBase message = null;
            try
            {
                XmlNode firstNode = doc.FirstChild;
                if (firstNode == null)
                {
                    return null;
                }
                if (encodingKeyProvider != null)
                {
                    encodingKeyProvider.InitFromXmlNode(firstNode);
                }

                var encryptXml = firstNode.GetInnerText("Encrypt");

                if (encryptXml != null)
                {
                    //var instance = GetEncodingInstance(encryptXml, encodingKeyProvider);
                    var instance = GetEncodingInstance(doc.InnerXml, encodingKeyProvider);
                    if (instance != null)
                    {
                        return instance;
                    }
                }

                //消息类型
                var text = firstNode.GetInnerText("MsgType");
                if (text == null)
                {
                    return null;
                }
                message = GetInstance(WeChatHelper.ToEnum<MessageType>(text));
                if (message != null)
                {
                    if (encoding)
                    {
                        message.EncodingKeyProvider = encodingKeyProvider;
                    }

                    message.Node = firstNode;
                    //发送者
                    text = firstNode.GetInnerText("FromUserName");
                    if (text == null)
                    {
                        return null;
                    }
                    message.FromUserName = text;
                    //接收者
                    text = firstNode.GetInnerText("ToUserName");
                    if (text == null)
                    {
                        return null;
                    }
                    message.ToUserName = text;
                    //创建时间
                    text = firstNode.GetInnerText("CreateTime");
                    if (text == null)
                    {
                        return null;
                    }
                    message.CreateTime = Convert.ToInt64(text);

                    ////Url
                    //tempNode = firstNode.SelectSingleNode("URL");
                    //if (tempNode != null)
                    //{
                    //    message.Url = tempNode.InnerText;
                    //}


                    return message.Parse();
                }
                return message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        static RequestMessageBase GetEncodingInstance(string context, IEncodingKeyProvider encodingKeyProvider)
        {
            if (encodingKeyProvider == null)
            {
                return null;
            }
            string xml = encodingKeyProvider.Decrypt(context);
            if (xml == null)
            {

            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            //return GetEncodingInstance(doc, encodingKeyProvider);
            return GetInstance(doc, encodingKeyProvider, true);
        }

        private static RequestMessageBase GetInstance(MessageType type)
        {
            switch (type)
            {
                case MessageType.Text: return new RequestTextMessage();
                case MessageType.Image: return new RequestImageMessage();
                case MessageType.Link: return new RequestLinkMessage();
                case MessageType.Location: return new RequestLocationMessage();
                //case MessageType.Music: return new RequestMusicMessage();
                //case MessageType.News: return null;
                case MessageType.Video: return new RequestVideoMessage();
                case MessageType.Voice: return new RequestVoiceMessage();
                case MessageType.Event: return new RequestEventMessage();
                default: return null;
            }
        }

        #endregion

    }
}

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

        /// <summary>
        /// 获取或设置加密解密消息提供者
        /// </summary>
        internal IEncodingAESKeyProvider EncodingAESKeyProvider { get; set; }

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
                EncodingAESKeyProvider = EncodingAESKeyProvider
            };
        }

        #region Instance

        /// <summary>
        /// 得到具体的消息处理实例
        /// </summary>
        /// <param name="xmlStream"></param>
        /// <returns></returns>
        public static RequestMessageBase GetInstance(Stream xmlStream, IEncodingAESKeyProvider encodingAESKeyProvider)
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
            return GetInstance(doc, encodingAESKeyProvider);
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
        public static RequestMessageBase GetInstance(string xml, IEncodingAESKeyProvider encodingAESKeyProvider)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return GetInstance(doc, encodingAESKeyProvider);
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

        static RequestMessageBase GetInstance(XmlDocument doc, IEncodingAESKeyProvider encodingAESKeyProvider)
        {
            RequestMessageBase message = null;
            try
            {
                XmlNode firstNode = doc.FirstChild;
                if (firstNode == null)
                {
                    return null;
                }

                var encryptNode = firstNode.SelectSingleNode("Encrypt");

                if (encryptNode != null)
                {
                    return GetEncodingInstance(encryptNode.InnerText, encodingAESKeyProvider);
                }

                //消息类型
                XmlNode tempNode = firstNode.SelectSingleNode("MsgType");
                if (tempNode == null)
                {
                    return null;
                }
                message = GetInstance(WeChatHelper.ToEnum<MessageType>(tempNode.InnerText));
                if (message != null)
                {
                    message.Node = firstNode;
                    //发送者
                    tempNode = firstNode.SelectSingleNode("FromUserName");
                    if (tempNode == null)
                    {
                        return null;
                    }
                    message.FromUserName = tempNode.InnerText;
                    //接收者
                    tempNode = firstNode.SelectSingleNode("ToUserName");
                    if (tempNode == null)
                    {
                        return null;
                    }
                    message.ToUserName = tempNode.InnerText;
                    //创建时间
                    tempNode = firstNode.SelectSingleNode("CreateTime");
                    if (tempNode == null)
                    {
                        return null;
                    }
                    message.CreateTime = Convert.ToInt64(tempNode.InnerText);
                    return message.Parse();
                }
                return message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        static RequestMessageBase GetEncodingInstance(string encryptXml, IEncodingAESKeyProvider encodingAESKeyProvider)
        {
            string xml = encodingAESKeyProvider.Decrypt(encryptXml);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return GetEncodingInstance(doc, encodingAESKeyProvider);
        }
        static RequestMessageBase GetEncodingInstance(XmlDocument doc, IEncodingAESKeyProvider encodingAESKeyProvider)
        {
            RequestMessageBase message = null;
            try
            {
                XmlNode firstNode = doc.FirstChild;
                if (firstNode == null)
                {
                    return null;
                }
                //消息类型
                XmlNode tempNode = firstNode.SelectSingleNode("MsgType");
                if (tempNode == null)
                {
                    return null;
                }
                message = GetInstance(WeChatHelper.ToEnum<MessageType>(tempNode.InnerText));
                if (message != null)
                {
                    message.Node = firstNode;
                    message.EncodingAESKeyProvider = encodingAESKeyProvider;
                    //发送者
                    tempNode = firstNode.SelectSingleNode("FromUserName");
                    if (tempNode == null)
                    {
                        return null;
                    }
                    message.FromUserName = tempNode.InnerText;
                    //接收者
                    tempNode = firstNode.SelectSingleNode("ToUserName");
                    if (tempNode == null)
                    {
                        return null;
                    }
                    message.ToUserName = tempNode.InnerText;
                    //创建时间
                    tempNode = firstNode.SelectSingleNode("CreateTime");
                    if (tempNode == null)
                    {
                        return null;
                    }
                    message.CreateTime = Convert.ToInt64(tempNode.InnerText);
                    return message.Parse();
                }
                return message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static RequestMessageBase GetInstance(MessageType type)
        {
            switch (type)
            {
                case MessageType.Text: return new RequestTextMessage();
                //case MessageType.Image: return new RequestImageMessage();
                //case MessageType.Link: return new RequestLinkMessage();
                //case MessageType.Location: return new RequestLocationMessage();
                //case MessageType.Music: return new RequestMusicMessage();
                //case MessageType.News: return null;
                //case MessageType.Video: return new RequestVideoMessage();
                //case MessageType.Voice: return new RequestVoiceMessage();
                //case MessageType.Event: return new EventMessage();
                default: return null;
            }
        }

        #endregion

    }
}

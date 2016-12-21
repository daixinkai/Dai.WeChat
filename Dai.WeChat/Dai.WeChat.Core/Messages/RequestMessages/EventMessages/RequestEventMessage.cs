using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dai.WeChat.Request
{
    /// <summary>
    /// 表示一个接收的事件消息(subscribe/unsubscribe/CLICK/SCAN/LOCATION/CLICK)
    /// </summary>
    public class RequestEventMessage : RequestMessageBase
    {
        internal RequestEventMessage() { }
        public override MessageType MsgType
        {
            get
            {
                return MessageType.Event;
            }
        }

        public EventType Event { get; set; }


        #region parse

        protected override RequestMessageBase Parse()
        {

            var node = this.Node;

            //事件(subscribe/unsubscribe/CLICK)
            var tempNode = node.SelectSingleNode("Event");
            if (tempNode == null)
            {
                return null;
            }

            this.Event = WeChatHelper.ToEnum<EventType>(tempNode.InnerText);

            return this.ToMessage(node);

        }

        /// <summary>
        /// 返回具体事件类型
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected RequestMessageBase ToMessage(XmlNode node)
        {
            RequestMessageBase message = null;
            switch (this.Event)
            {
                case EventType.Click:
                    message = this.Copy<RequestClickEventMessage>(o =>
                    {
                        o.EventKey = GetValue(node, "EventKey");
                    });
                    break;
                case EventType.Scan:
                    //是二维码扫描事件
                    message = this.Copy<RequestQCodeEventMessage>(o =>
                    {
                        o.Ticket = GetValue(node, "Ticket");
                        o.EventKey = GetValue(node, "EventKey");
                    });
                    break;
                case EventType.Location:
                    //是地理位置事件
                    message = this.Copy<RequestLocationEventMessage>(o =>
                    {
                        o.Latitude = Convert.ToDouble(GetValue(node, "Latitude"));
                        o.Longitude = Convert.ToDouble(GetValue(node, "Longitude"));
                        o.Precision = Convert.ToDouble(GetValue(node, "Precision"));
                    });
                    break;
                case EventType.View:
                    message = this.Copy<RequestViewEventMessage>(o =>
                    {
                        o.EventKey = GetValue(node, "EventKey");
                    });
                    break;
                case EventType.Subscribe:
                    //分2种  用户未关注时，进行关注后的事件推送 / 关注事件
                    string ticekt = GetValue(node, "Ticket");
                    if (ticekt == null)
                    {
                        //是关注事件
                        message = this.Copy<RequestSubscribeEventMessage>(o =>
                        {
                            o.Subscribe = true;
                        });
                    }
                    else
                    {
                        message = this.Copy<RequestQCodeEventMessage>(o =>
                        {
                            o.Ticket = GetValue(node, "Ticket");
                            o.EventKey = GetValue(node, "EventKey");
                        });
                    }
                    break;
                case EventType.UnSubscribe:
                    //是取消关注事件
                    message = this.Copy<RequestSubscribeEventMessage>();
                    break;
                default:
                    message = this;
                    break;
            }


            return message;
        }

        #endregion

        protected string GetValue(XmlNode node, string nodeName)
        {
            XmlNode tempNode = node.SelectSingleNode(nodeName);
            return tempNode == null ? null : tempNode.Value;
        }
        private T Copy<T>() where T : RequestEventMessage, new()
        {
            T t = new T();
            t.CreateTime = this.CreateTime;
            t.Event = this.Event;
            t.FromUserName = this.FromUserName;
            //t.MsgType = this.MsgType;
            t.ToUserName = this.ToUserName;
            t.Node = this.Node;
            return t;
        }

        private T Copy<T>(Action<T> action) where T : RequestEventMessage, new()
        {
            T t = Copy<T>();
            if (action != null)
            {
                action(t);
            }
            return t;
        }

        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                                "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                                "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                                "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                                "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                                "<Event><![CDATA[{4}]]></Event>" + Environment.NewLine +
                                "</xml>", ToUserName, FromUserName, CreateTime, MsgType, Event.ToString());
        }
    }
}

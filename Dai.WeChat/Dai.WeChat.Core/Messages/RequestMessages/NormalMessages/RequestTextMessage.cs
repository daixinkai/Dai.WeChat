using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dai.WeChat.Request
{
    /// <summary>
    /// 表示一个文本消息,可以用于回复
    /// </summary>
    public class RequestTextMessage : RequestNormalMessageBase
    {
        internal RequestTextMessage() { }
        public override MessageType MsgType
        {
            get { return MessageType.Text; }
        }

        public string Content { get; set; }

        protected override RequestMessageBase Parse()
        {
            var node = this.Node;

            //消息内容
            var text = node.GetInnerText("Content");
            if (text == null)
            {
                return null;
            }

            this.Content = text;

            //消息ID
            text = node.GetInnerText("MsgId");
            if (text == null)
            {
                return null;
            }
            this.MsgId = text;

            return this;
        }
        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                             "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                             "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                             "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                             "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                             "<Content><![CDATA[{4}]]></Content>" + Environment.NewLine +
                             "<MsgId>{5}</MsgId>" + Environment.NewLine +
                             "</xml>", ToUserName, FromUserName, CreateTime, MsgType, Content, MsgId);
        }



    }
}

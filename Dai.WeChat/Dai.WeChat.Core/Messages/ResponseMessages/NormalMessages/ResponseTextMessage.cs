using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Response
{
    /// <summary>
    /// 回复的文本消息
    /// </summary>
    public class ResponseTextMessage : ResponseNormalMessageBase
    {
        public override MessageType MsgType
        {
            get
            {
                return MessageType.Text;
            }
        }

        public string Content { get; set; }

        protected override string GetResponseInternal()
        {
            return string.Format("<xml>" + Environment.NewLine +
                                     "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                                     "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                                     "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                                     "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                                     "<Content><![CDATA[{4}]]></Content>" + Environment.NewLine +
                                     "<MsgId>{5}</MsgId>" + Environment.NewLine +
                                     "</xml>", ToUserName, FromUserName, CreateTime, MsgType.ToString().ToLower(), Content, MsgId);
        }
    }
}

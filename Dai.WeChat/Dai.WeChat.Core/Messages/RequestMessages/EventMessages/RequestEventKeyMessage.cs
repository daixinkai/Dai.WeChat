using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Request
{
    /// <summary>
    /// 带EventKey 的事件消息
    /// </summary>
    public abstract class RequestEventKeyMessage : RequestEventMessage
    {
        /// <summary>
        /// 事件KEY值
        /// </summary>
        public string EventKey { get; set; }

        protected override RequestMessageBase Parse()
        {

            return base.Parse();
        }

        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                                "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                                "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                                "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                                "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                                "<Event><![CDATA[{4}]]></Event>" + Environment.NewLine +
                                "<EventKey>{5}</EventKey>" + Environment.NewLine +
                                "</xml>", ToUserName, FromUserName, CreateTime, MsgType, Event.ToString(), EventKey);
        }
    }
}

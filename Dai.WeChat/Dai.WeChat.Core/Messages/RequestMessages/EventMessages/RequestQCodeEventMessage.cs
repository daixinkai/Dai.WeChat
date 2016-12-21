using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Request
{
    /// <summary>
    /// 表示一个扫描带参数二维码事件
    /// 如果用户还未关注公众号，则用户可以关注公众号，关注后微信会将带场景值关注事件推送给开发者。
    /// 如果用户已经关注公众号，则微信会将带场景值扫描事件推送给开发者。
    /// </summary>
    public class RequestQCodeEventMessage : RequestEventKeyMessage
    {
        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { get; set; }

        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                                "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                                "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                                "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                                "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                                "<Event><![CDATA[{4}]]></Event>" + Environment.NewLine +
                                "<EventKey>{5}</EventKey>" + Environment.NewLine +
                                "<Ticket>{6}</Ticket>" + Environment.NewLine +
                                "</xml>", ToUserName, FromUserName, CreateTime, MsgType, Event.ToString(), EventKey, Ticket);
        }


    }
}

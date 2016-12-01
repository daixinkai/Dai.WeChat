using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    /// <summary>
    /// 一个接口,表示消息
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// 开发者微信号
        /// </summary>
        string ToUserName { get; set; }
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        long CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        MessageType MsgType { get; }
    }
}

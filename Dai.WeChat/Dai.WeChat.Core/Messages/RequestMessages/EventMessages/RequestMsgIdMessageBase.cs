using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Request
{
    /// <summary>
    /// 带有消息Id的消息
    /// </summary>
    public abstract class RequestMsgIdMessageBase : RequestMessageBase
    {
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; set; }
    }
}

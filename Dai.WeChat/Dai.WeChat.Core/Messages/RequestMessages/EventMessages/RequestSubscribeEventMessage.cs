using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Request
{
    /// <summary>
    /// 表示关注/取消关注事件
    /// 用户在关注与取消关注公众号时，微信会把这个事件推送到开发者填写的URL。方便开发者给用户下发欢迎消息或者做帐号的解绑。
    /// </summary>
    public class RequestSubscribeEventMessage : RequestEventMessage
    {
        /// <summary>
        /// 是否关注
        /// </summary>
        public bool Subscribe { get; set; }
    }
}

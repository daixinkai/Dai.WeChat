using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Response
{
    /// <summary>
    /// 回复的普通消息
    /// </summary>
    public abstract class ResponseNormalMessageBase : ResponseMessageBase
    {
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; set; }

        protected override string GetResponseInternal()
        {
            return this.ToString();
        }

    }
}

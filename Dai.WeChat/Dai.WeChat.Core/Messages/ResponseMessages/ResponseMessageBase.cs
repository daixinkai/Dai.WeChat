using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Response
{
    /// <summary>
    /// 表示发送的消息
    /// </summary>
    public abstract class ResponseMessageBase : MessageBase, IRespond
    {
        public abstract string GetResponse();
    }
}

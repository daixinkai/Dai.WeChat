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
        /// <summary>
        /// 获取或设置加密解密消息提供者
        /// </summary>
        public IEncodingAESKeyProvider EncodingAESKeyProvider { get; set; }
        public abstract string GetResponse();
    }
}

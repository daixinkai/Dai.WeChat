using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Response
{
    /// <summary>
    /// 告诉微信已收到消息
    /// </summary>
    public sealed class SuccessResponseMessage : IRespond
    {
        private SuccessResponseMessage()
        {
        }

        public static readonly SuccessResponseMessage Instance = new SuccessResponseMessage();


        public string GetResponse()
        {
            return "success";
        }

        public string GetResponse(IEncodingKeyProvider encodingKeyProvider)
        {
            return "success";
        }
    }
}

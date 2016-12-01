using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Api
{
    /// <summary>
    /// 带过期时间的微信Api调用响应对象
    /// </summary>
    public class WeChatApiExpireResponse : WeChatApiResponse
    {
        public int expires_in { get; set; }
    }
}

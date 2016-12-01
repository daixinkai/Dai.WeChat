using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Api
{

    /// <summary>
    /// 微信Api调用响应对象
    /// </summary>
    public class WeChatApiResponse
    {
        public Errcode errcode { get; set; }

        public string errmsg { get; set; }
    }
}

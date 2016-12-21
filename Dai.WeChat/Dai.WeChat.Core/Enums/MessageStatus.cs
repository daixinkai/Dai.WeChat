using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    /// <summary>
    /// 表示消息状态
    /// </summary>
    public enum MessageStatus
    {
        Success = 1,
        /// <summary>
        /// 用户拒收
        /// </summary>
        UserBlock,
        /// <summary>
        /// 失败
        /// </summary>
        SystemFailed
    }
}

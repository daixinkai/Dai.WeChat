using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    /// <summary>
    /// 一个接口,表示一个按钮
    /// </summary>
    public interface IWeChatButton
    {
        /// <summary>
        /// 显示名
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        ButtonType Type { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum ButtonType
    {
        /// <summary>
        /// 事件菜单(点击会向服务器发送事件)
        /// </summary>
        Click = 1,
        /// <summary>
        /// 网页菜单(点击直接跳转url)
        /// </summary>
        View = 2,

        /// <summary>
        /// 包含子菜单的菜单
        /// </summary>
        Parent = 3
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    /// <summary>
    /// 事件菜单
    /// </summary>
    public sealed class WeChatClickButton : WeChatButton
    {

        public override ButtonType Type
        {
            get { return ButtonType.Click; }
        }
        /// <summary>
        /// 当前按钮的KEY 
        /// (当点击按钮时,微信会返回此KEY)
        /// </summary>
        public string Key { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Name) || string.IsNullOrEmpty(this.Key))
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"type\":\"" + this.Type + "\",\"name\":\"" + this.Name + "\",\"key\":\"" + this.Key + "\"}");
            return sb.ToString();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    public sealed class WeChatViewButton : WeChatButton
    {
        public override ButtonType Type
        {
            get { return ButtonType.View; }
        }
        /// <summary>
        /// 获取或设置此菜单链接的URL地址
        /// </summary>
        public string Url { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Name) || string.IsNullOrEmpty(this.Url))
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"type\":\"" + this.Type + "\",\"name\":\"" + this.Name + "\",\"url\":\"" + this.Url + "\"}");
            return sb.ToString();
        }
    }
}

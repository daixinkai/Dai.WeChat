using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    /// <summary>
    /// 表示自定义菜单
    /// </summary>
    public sealed class CustomMenu : IEnumerable<IWeChatButton>
    {
        public CustomMenu()
        {
            Buttons = new List<IWeChatButton>();
        }
        /// <summary>
        /// 获取当前菜单的按钮集合
        /// </summary>
        public ICollection<IWeChatButton> Buttons { get; private set; }


        public bool Add(IWeChatButton button)
        {
            if (this.Buttons.Count > this.MaxCount)
            {
                return false;
            }
            this.Buttons.Add(button);
            return true;
        }


        /// <summary>
        /// 获取或设置最大菜单数量
        /// </summary>
        public int MaxCount { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"button\":[");
            int count = this.Buttons.Count;
            if (count > 0)
            {
                int index = 0;
                foreach (var item in this.Buttons)
                {
                    index++;
                    if (index > MaxCount)
                    {
                        break;
                    }
                    sb.Append(item.ToString());
                    if (index < count && index < MaxCount)
                    {
                        sb.Append(",");
                    }
                }
            }
            sb.Append("]}");
            return sb.ToString();
        }

        public IEnumerator<IWeChatButton> GetEnumerator()
        {
            return Buttons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

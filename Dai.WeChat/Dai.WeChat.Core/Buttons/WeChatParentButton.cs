using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    /// <summary>
    /// 拥有二级菜单的按钮
    /// </summary>
    public sealed class WeChatParentButton : WeChatButton, ICollection<IWeChatButton>
    {

        public WeChatParentButton()
        {
            this.Sub_button = new Collection<IWeChatButton>();
            this.MaxCount = 5;
        }

        public override ButtonType Type
        {
            get { return ButtonType.Parent; }
        }

        public int MaxCount { get; set; }

        /// <summary>
        /// 下级菜单
        /// </summary>
        ICollection<IWeChatButton> Sub_button { get; set; }

        public void Add(IWeChatButton button)
        {
            if (button is WeChatParentButton)
            {
                throw new Exception("不能包含三级菜单");
            }

            this.Sub_button.Add(button);

        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"name\":\"" + this.Name + "\",\"sub_button\":[");
            int count = this.Sub_button.Count;
            if (count > 0)
            {
                int index = 0;
                foreach (var item in this.Sub_button)
                {
                    index++;
                    if (index > MaxCount)
                    {

                    }
                    if (item is WeChatParentButton)
                    {
                        continue;
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



        public void Clear()
        {
            this.Sub_button.Clear();
        }

        public bool Contains(IWeChatButton item)
        {
            return this.Sub_button.Contains(item);
        }

        public void CopyTo(IWeChatButton[] array, int arrayIndex)
        {
            this.Sub_button.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.Sub_button.Count; }
        }

        public bool IsReadOnly
        {
            get { return this.Sub_button.IsReadOnly; }
        }

        public bool Remove(IWeChatButton item)
        {
            return this.Sub_button.Remove(item);
        }

        public IEnumerator<IWeChatButton> GetEnumerator()
        {
            return this.Sub_button.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.Sub_button).GetEnumerator();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    /// <summary>
    /// 新闻实体
    /// </summary>
    public class NewsMessageItem
    {
        /// <summary>
        /// 图文消息标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 图文消息描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 点击图文消息跳转链接
        /// </summary>
        public string Url { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.Description))
            {
                this.Description = this.Description.TrimEnd();
            }

            return string.Format("<item>{0}<Title><![CDATA[{1}]]></Title>{0}<Description><![CDATA[{2}]]></Description>{0}<PicUrl><![CDATA[{3}]]></PicUrl>{0}<Url><![CDATA[{4}]]></Url>{0}</item>", Environment.NewLine, Title, Description, PicUrl, Url);
        }
    }
}
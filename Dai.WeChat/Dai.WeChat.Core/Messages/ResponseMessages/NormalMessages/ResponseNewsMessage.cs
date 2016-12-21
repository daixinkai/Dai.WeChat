using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Response
{
    /// <summary>
    /// 回复的新闻消息
    /// </summary>
    public class ResponseNewsMessage : ResponseNormalMessageBase
    {
        protected override void Initialization()
        {
            this.Articles = new List<NewsMessageItem>();
            this.IsMore = false;
        }

        public override MessageType MsgType
        {
            get { return MessageType.News; }
        }

        int _articleCount;

        /// <summary>
        /// 图文消息个数，限制为10条以内
        /// </summary>
        public int ArticleCount
        {
            get
            {
                if (_articleCount <= 0)
                {
                    _articleCount = this.Articles.Count;
                }
                return _articleCount;
            }
            set
            {
                _articleCount = value;
            }
        }

        /// <summary>
        /// 是否有查看更多按钮
        /// </summary>
        public bool IsMore { get; set; }
        /// <summary>
        /// 查看更多的链接
        /// </summary>
        public string MoreUrl { get; set; }
        /// <summary>
        /// 新闻消息
        /// </summary>
        public ICollection<NewsMessageItem> Articles { get; private set; }

        public override string ToString()
        {
            string value = string.Empty;
            int count = this.Articles.Count;
            int index = 0;
            foreach (var item in this.Articles)
            {
                value += item.ToString();
                index++;
                if (count > index)
                {
                    value += Environment.NewLine;
                }
            }
            if (this.IsMore)
            {
                this.ArticleCount++;
                value += string.Format("<item>{0}<Title><![CDATA[{1}]]></Title>{0}<Url><![CDATA[{2}]]></Url>{0}</item>", Environment.NewLine, "查看更多", this.MoreUrl) + Environment.NewLine;
            }

            return string.Format("<xml>" + Environment.NewLine +
                                 "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                                 "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                                 "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                                 "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                                  "<ArticleCount><![CDATA[{4}]]></ArticleCount>" + Environment.NewLine +
                                 "<Articles>" + Environment.NewLine +
                                 value + Environment.NewLine +
                                 "</Articles>" + Environment.NewLine +
                                 "</xml>", ToUserName, FromUserName, CreateTime, MsgType, ArticleCount);
        }
    }
}

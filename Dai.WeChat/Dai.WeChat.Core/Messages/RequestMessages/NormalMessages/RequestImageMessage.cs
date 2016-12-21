using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dai.WeChat.Request
{
    /// <summary>
    /// 表示图片消息
    /// </summary>
    public class RequestImageMessage : RequestMediaMessage
    {
        public override MessageType MsgType
        {
            get
            {
                return MessageType.Image;
            }
        }

        /// <summary>
        /// 图片链接
        /// </summary>
        public string PicUrl { get; set; }

        protected override RequestMessageBase Parse()
        {
            var node = this.Node;
            //媒体ID
            var tempNode = node.SelectSingleNode("MediaId");
            if (tempNode == null)
            {
                return null;
            }
            this.MediaId = tempNode.InnerText;

            this.CreateTime = Convert.ToInt64(tempNode.InnerText);

            //图片链接
            tempNode = node.SelectSingleNode("PicUrl");
            if (tempNode == null)
            {
                return null;
            }

            this.PicUrl = tempNode.InnerText;

            //消息ID
            tempNode = node.SelectSingleNode("MsgId");
            if (tempNode == null)
            {
                return null;
            }
            this.MsgId = tempNode.InnerText;

            return this;
        }


        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                             "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                             "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                             "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                             "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                             "<PicUrl><![CDATA[{4}]]></PicUrl>" + Environment.NewLine +
                             "<MediaId><![CDATA[{5}]]></MediaId>" + Environment.NewLine +
                             "<MsgId>{6}</MsgId>" + Environment.NewLine +
                             "</xml>", ToUserName, FromUserName, CreateTime, MsgType, PicUrl, MediaId, MsgId);
        }

    }
}

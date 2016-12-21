using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dai.WeChat.Request
{
    /// <summary>
    /// 表示一个定位消息
    /// </summary>
    public class RequestLocationMessage : RequestNormalMessageBase
    {
        public override MessageType MsgType
        {
            get { return MessageType.Location; }
        }

        /// <summary>
        /// 纬度
        /// </summary>
        public double Location_X { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Location_Y { get; set; }
        public double Scale { get; set; }

        /// <summary>
        /// 位置信息
        /// </summary>
        public string Label { get; set; }

        protected override RequestMessageBase Parse()
        {
            var node = this.Node;

            //纬度
            var text = node.GetInnerText("Location_X");
            if (text == null)
            {
                return null;
            }
            this.Location_X = Convert.ToDouble(text);

            //经度
            text = node.GetInnerText("Location_Y");
            if (text == null)
            {
                return null;
            }
            this.Location_Y = Convert.ToDouble(text);

            //经度
            text = node.GetInnerText("Scale");
            if (text == null)
            {
                return null;
            }
            this.Scale = Convert.ToDouble(text);

            //位置信息
            text = node.GetInnerText("Label");
            if (text != null)
            {
                this.Label = text;
            }

            return this;
        }

        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                           "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                           "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                           "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                           "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                           "<Location_X><![CDATA[{4}]]></Location_X>" + Environment.NewLine +
                           "<Location_Y><![CDATA[{5}]]></Location_Y>" + Environment.NewLine +
                           "<Scale>{6}</Scale>" + Environment.NewLine +
                           "<Label><![CDATA[{7}]]></Label>" + Environment.NewLine +
                           "<MsgId><![CDATA[{8}]]></MsgId>" + Environment.NewLine +
                           "</xml>", ToUserName, FromUserName, CreateTime, MsgType, Location_X, Location_Y, Scale, Label, MsgId);
        }
    }
}

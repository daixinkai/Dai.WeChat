using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dai.WeChat.Request
{
    /// <summary>
    /// 表示语音识别的消息
    /// </summary>
    public class RequestVoiceRecognitionMessage : RequestMediaMessage
    {
        public override MessageType MsgType
        {
            get { return MessageType.Voice; }
        }

        /// <summary>
        /// 语音格式：amr
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// 语音识别结果，UTF8编码
        /// </summary>
        public string Recognition { get; set; }


        protected override RequestMessageBase Parse()
        {
            var node = this.Node;

            //语音格式，如amr，speex等
            var tempNode = node.SelectSingleNode("Format");
            if (tempNode == null)
            {
                return null;
            }

            this.Format = tempNode.InnerText;

            //媒体ID
            tempNode = node.SelectSingleNode("MediaId");
            if (tempNode == null)
            {
                return null;
            }
            this.MediaId = tempNode.InnerText;

            //消息ID
            tempNode = node.SelectSingleNode("MsgId");
            if (tempNode == null)
            {
                return null;
            }

            //识别结果
            tempNode = node.SelectSingleNode("Recognition");
            if (tempNode == null)
            {
                return null;
            }

            this.Recognition = tempNode.InnerText;

            return this;
        }


        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                             "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                             "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                             "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                             "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                             "<MediaId><![CDATA[{4}]]></MediaId>" + Environment.NewLine +
                             "<Format><![CDATA[{5}]]></Format>" + Environment.NewLine +
                             "<MsgId>{6}</MsgId>" + Environment.NewLine +
                             "<Recognition>{7}</Recognition>" + Environment.NewLine +
                             "</xml>", ToUserName, FromUserName, CreateTime, MsgType, MediaId, Format, MsgId, Recognition);
        }
    }
}

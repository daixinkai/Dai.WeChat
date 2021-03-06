﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dai.WeChat.Request
{
    /// <summary>
    /// 表示视频消息
    /// </summary>
    public class RequestVideoMessage : RequestMediaMessage
    {
        public override MessageType MsgType
        {
            get { return MessageType.Video; }
        }

        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId { get; set; }


        /// <summary>
        /// 视频消息的标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 视频消息的描述
        /// </summary>
        public string Description { get; set; }

        protected override RequestMessageBase Parse()
        {
            var node = this.Node;
            //语音格式，如amr，speex等
            var text = node.GetInnerText("ThumbMediaId");
            if (text == null)
            {
                return null;
            }

            this.ThumbMediaId = text;

            //媒体ID
            text = node.GetInnerText("MediaId");
            if (text == null)
            {
                return null;
            }
            this.MediaId = text;

            //消息ID
            text = node.GetInnerText("MsgId");
            if (text == null)
            {
                return null;
            }
            this.MsgId = text;

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
                             "<ThumbMediaId><![CDATA[{5}]]></ThumbMediaId>" + Environment.NewLine +
                             "<MsgId>{6}</MsgId>" + Environment.NewLine +
                             "</xml>", ToUserName, FromUserName, CreateTime, MsgType, MediaId, ThumbMediaId, MsgId);
        }
    }
}

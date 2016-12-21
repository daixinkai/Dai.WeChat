using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Response
{
    /// <summary>
    /// 回复的音乐消息
    /// </summary>
    public class ResponseMusicMessage : ResponseMediaMessage
    {
        public override MessageType MsgType
        {
            get { return MessageType.Music; }
        }

        /// <summary>
        /// 音乐标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 音乐描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 音乐链接
        /// </summary>
        public string MusicUrl { get; set; }

        /// <summary>
        /// 高质量音乐链接，WIFI环境优先使用该链接播放音乐
        /// </summary>
        public string HQMusicUrl { get; set; }
        /// <summary>
        /// 缩略图的媒体id，通过上传多媒体文件，得到的id
        /// </summary>
        public string ThumbMediaId { get; set; }

        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                             "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                             "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                             "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                             "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                             "<Title><![CDATA[{4}]]></Title>" + Environment.NewLine +
                             "<Description><![CDATA[{5}]]></Description>" + Environment.NewLine +
                             "<MusicUrl><![CDATA[{6}]]></MusicUrl>" + Environment.NewLine +
                             "<HQMusicUrl><![CDATA[{7}]]></HQMusicUrl>" + Environment.NewLine +
                             "<ThumbMediaId><![CDATA[{8}]]></ThumbMediaId>" + Environment.NewLine +
                             "<MediaId><![CDATA[{9}]]></MediaId>" + Environment.NewLine +
                             "<MsgId>{10}</MsgId>" + Environment.NewLine +
                             "</xml>", ToUserName, FromUserName, CreateTime, MsgType, Title, Description, MusicUrl, HQMusicUrl, ThumbMediaId, MediaId, MsgId);
        }
    }
}

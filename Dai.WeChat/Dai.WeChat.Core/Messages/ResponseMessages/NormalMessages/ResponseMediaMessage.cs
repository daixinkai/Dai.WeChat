﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Response
{
    /// <summary>
    /// 回复的媒体消息
    /// </summary>
    public abstract class ResponseMediaMessage : ResponseNormalMessageBase
    {
        /// <summary>
        /// 媒体id，可以调用多媒体文件下载接口拉取该媒体
        /// </summary>
        public string MediaId { get; set; }
    }
}

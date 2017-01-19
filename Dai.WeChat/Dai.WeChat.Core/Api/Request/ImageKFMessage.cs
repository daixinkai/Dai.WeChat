using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Api
{
    /// <summary>
    /// 图片消息
    /// </summary>
    public class ImageKFMessage : KFMessage
    {
        public override MessageType Msgtype
        {
            get { return MessageType.Image; }
        }

        public ImageModel Image { get; set; }

        public class ImageModel
        {
            public string Media_ID { get; set; }
        }
    }
}

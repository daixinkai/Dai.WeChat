using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Api
{
    public class VideoKFMessage : KFMessage
    {
        public override MessageType Msgtype
        {
            get { return MessageType.Video; }
        }

        public VideoModel Video { get; set; }

        public class VideoModel
        {
            public string Media_ID { get; set; }

            public string Thumb_Media_ID { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }
        }


    }

}

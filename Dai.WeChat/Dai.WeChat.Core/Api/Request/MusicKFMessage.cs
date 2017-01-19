using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Api
{
    /// <summary>
    /// 音乐消息
    /// </summary>
    public class MusicKFMessage : KFMessage
    {

        public override MessageType Msgtype
        {
            get { return MessageType.Music; }
        }

        public MusicModel Music { get; set; }

        public class MusicModel
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string MusicUrl { get; set; }

            public string HqMusicUrl { get; set; }

            public string Thumb_Media_ID { get; set; }


        }


    }
}

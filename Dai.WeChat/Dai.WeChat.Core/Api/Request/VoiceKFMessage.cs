using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Api
{
    public class VoiceKFMessage : KFMessage
    {
        public override MessageType Msgtype
        {
            get { return MessageType.Voice; }
        }

        public VoiceModel Voice { get; set; }

        public class VoiceModel
        {
            public string Media_ID { get; set; }
        }


    }
}

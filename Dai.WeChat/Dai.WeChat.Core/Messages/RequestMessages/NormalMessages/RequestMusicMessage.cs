using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Request
{
    [Obsolete]
    public class RequestMusicMessage : RequestNormalMessageBase
    {
        public override MessageType MsgType
        {
            get
            {
                return MessageType.Music;
            }
        }
    }
}

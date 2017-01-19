using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Api
{
    public class TextKFMessage : KFMessage
    {
        public override MessageType Msgtype
        {
            get { return MessageType.Text; }
        }
        public TextModel Text { get; set; }
        public class TextModel
        {
            public string Content { get; set; }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Request
{
    public class RequestEventMessage : RequestMessageBase
    {
        public override MessageType MsgType
        {
            get
            {
                return MessageType.Event;
            }
        }
    }
}
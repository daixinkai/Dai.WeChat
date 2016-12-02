using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dai.WeChat.Request;
using Dai.WeChat.Response;

namespace Dai.WeChat.Directives
{
    class TestDirective : IDirective
    {
        public int Order
        {
            get
            {
                return 1;
            }
        }

        public IRespond GetResponse(RequestMessageBase requestMessage)
        {

            var requestTextMessage = requestMessage as RequestTextMessage;

            var response = requestMessage.ToResponseMessage<ResponseTextMessage>();

            response.MsgId = requestTextMessage.MsgId;

            response.Content = "测试指令 : " + requestTextMessage.Content;

            return response;
        }

        public bool IsMatch(RequestMessageBase requestMessage)
        {
            return requestMessage is RequestTextMessage;
        }
    }
}

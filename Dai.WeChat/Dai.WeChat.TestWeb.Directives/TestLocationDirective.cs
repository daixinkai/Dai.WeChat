using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dai.WeChat.Request;
using Dai.WeChat.Response;

namespace Dai.WeChat.TestWeb.Directives
{
    class TestLocationDirective : IDirective
    {
        public int Order
        {
            get
            {
                return 2;
            }
        }

        public IRespond GetResponse(RequestMessageBase requestMessage)
        {
            var requestLocationMessage = requestMessage as RequestLocationMessage;

            var responseMessage = requestLocationMessage.ToResponseMessage<ResponseTextMessage>();

            responseMessage.Content = "当前位置 : " + requestLocationMessage.Label;

            return responseMessage;
        }

        public bool IsMatch(RequestMessageBase requestMessage)
        {
            return requestMessage is RequestLocationMessage;
        }
    }
}

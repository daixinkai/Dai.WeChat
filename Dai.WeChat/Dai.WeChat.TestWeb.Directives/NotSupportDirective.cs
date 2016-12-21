using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dai.WeChat.Request;
using Dai.WeChat.Response;

namespace Dai.WeChat.TestWeb.Directives
{
    class NotSupportDirective : IDirective
    {
        public int Order
        {
            get
            {
                return 100;
            }
        }

        public IRespond GetResponse(RequestMessageBase requestMessage)
        {
            var responseMessage = requestMessage.ToResponseMessage<ResponseTextMessage>();
            responseMessage.Content = "无法识别的消息";
            return responseMessage;
        }

        public bool IsMatch(RequestMessageBase requestMessage)
        {
            return true;
        }
    }
}

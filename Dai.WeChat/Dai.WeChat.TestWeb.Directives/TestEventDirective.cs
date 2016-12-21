using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dai.WeChat.Request;
using Dai.WeChat.Response;

namespace Dai.WeChat.TestWeb.Directives
{
    class TestEventDirective : IDirective
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
            var requestEventKeyMessage = requestMessage as RequestEventKeyMessage;

            var response = requestMessage.ToResponseMessage<ResponseTextMessage>();


            response.Content = "测试指令 :  key= " + requestEventKeyMessage.EventKey;

            return response;
        }

        public bool IsMatch(RequestMessageBase requestMessage)
        {
            return requestMessage is RequestEventKeyMessage;
        }
    }
}

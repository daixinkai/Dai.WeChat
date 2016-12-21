using Dai.WeChat.Request;
using Dai.WeChat.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.TestWeb.Directives
{
    class TestTextDirective : IDirective
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

            if (requestTextMessage.Content == "新闻")
            {
                var newsResponseMessage = requestTextMessage.ToResponseMessage<ResponseNewsMessage>();

                newsResponseMessage.Articles.Add(new NewsMessageItem()
                {
                    Description = "马化腾回忆创业:曾假扮女孩子陪聊",
                    PicUrl = "http://daixinkai.cn/file/image/A015B5EB46EDDD4405831D720810CC55.jpg",
                    Title = "马化腾回忆创业:....",
                    Url = "http://tech.163.com/15/0601/07/AR0O2L7200094OE0.html"
                });

                return newsResponseMessage;
            }


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

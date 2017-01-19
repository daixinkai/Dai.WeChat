using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Api
{
    public class NewsKFMessage : KFMessage
    {
        public override MessageType Msgtype
        {
            get { return MessageType.News; }
        }

        public NewsModel News { get; set; }

        public class NewsModel
        {
            public List<NewsMessageItem> Articles { get; set; }

        }
    }
}

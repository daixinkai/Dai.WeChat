using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    public abstract class WeChatRespondBase : IRespond
    {
        public virtual string GetResponse()
        {
            throw new NotImplementedException();
        }

        public string GetResponse(IEncodingKeyProvider encodingKeyProvider)
        {
            return encodingKeyProvider.Encrypt(GetResponse());
        }
    }
}

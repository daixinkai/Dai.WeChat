using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Response
{
    /// <summary>
    /// 表示回复的消息
    /// </summary>
    public abstract class ResponseMessageBase : MessageBase, IRespond
    {
        /// <summary>
        /// 获取或设置加密解密消息提供者
        /// </summary>
        public IEncodingKeyProvider EncodingKeyProvider { get; set; }


        long _createTime;

        public override long CreateTime
        {
            get
            {
                if (_createTime <= 0)
                {
                    _createTime = WeChatHelper.ConvertDateTimeInt(DateTime.Now);
                }
                return _createTime;
            }

            set
            {
                _createTime = value;
            }
        }

        protected abstract string GetResponseInternal();

        public string GetResponse()
        {
            if (EncodingKeyProvider != null)
            {
                return EncodingKeyProvider.Encrypt(GetResponseInternal());
            }
            return GetResponseInternal();
        }


        public string GetResponse(IEncodingKeyProvider encodingKeyProvider)
        {
            return encodingKeyProvider.Encrypt(GetResponseInternal());
        }

    }
}

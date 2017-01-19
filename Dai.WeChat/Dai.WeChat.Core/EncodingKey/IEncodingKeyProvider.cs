using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    /// <summary>
    /// 提供EncodingKey加密解密操作
    /// </summary>
    public interface IEncodingKeyProvider
    {

        string AppId { get; }

        string TimeStamp { get; set; }

        string Nonce { get; set; }

        string MsgSignature { get; set; }

        string Encrypt(string value);

        string Decrypt(string value);

        string GetEchoString(string value);

    }
}

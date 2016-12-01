using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    /// <summary>
    /// 提供EncodingAESKey加密解密操作
    /// </summary>
    public interface IEncodingAESKeyProvider
    {
        string Encrypt(string value);

        string Decrypt(string value);
    }
}

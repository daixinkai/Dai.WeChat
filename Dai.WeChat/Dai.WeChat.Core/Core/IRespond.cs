using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    /// <summary>
    /// 一个接口,支持响应操作
    /// </summary>
    public interface IRespond
    {
        /// <summary>
        /// 得到响应内容
        /// </summary>
        /// <returns></returns>
        string GetResponse();

        /// <summary>
        /// 得到加密响应内容
        /// </summary>
        /// <returns></returns>
        string GetResponse(IEncodingKeyProvider encodingKeyProvider);
    }
}

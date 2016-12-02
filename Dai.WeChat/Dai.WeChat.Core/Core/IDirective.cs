using Dai.WeChat.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    /// <summary>
    /// 一个接口,表示操作指令
    /// </summary>
    public interface IDirective
    {

        int Order { get; }

        /// <summary>
        /// 检查指令是否与消息相匹配
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        bool IsMatch(RequestMessageBase requestMessage);
        /// <summary>
        /// 分析消息内容并返回响应内容
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        IRespond GetResponse(RequestMessageBase requestMessage);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Request
{
    /// <summary>
    /// 模版消息发送任务完成后,微信服务器会将是否送达成功作为通知
    /// </summary>
    public sealed class RequestTemplateSendJobFinishMessage : RequestMsgIdMessageBase
    {

        internal RequestTemplateSendJobFinishMessage(RequestEventMessage message, string status)
        {
            this.CreateTime = message.CreateTime;
            this.FromUserName = message.FromUserName;
            this.ToUserName = message.ToUserName;
            this.Status = ConvertToStatus(status);
        }

        public override MessageType MsgType
        {
            get
            {
                return MessageType.Event;
            }
        }

        public MessageStatus Status { get; set; }

        public EventType Event
        {
            get
            {
                return EventType.TEMPLATESENDJOBFINISH;
            }
        }

        internal static MessageStatus ConvertToStatus(string value)
        {
            if (value.Equals("success", StringComparison.OrdinalIgnoreCase))
            {
                return MessageStatus.Success;
            }

            string[] split = value.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            if (split[1].Equals("user block", StringComparison.OrdinalIgnoreCase))
            {
                return MessageStatus.UserBlock;
            }


            return MessageStatus.SystemFailed;
        }

    }
}

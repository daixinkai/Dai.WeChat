using Dai.WeChat.Request;
using Dai.WeChat.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    public static class DirectiveCenter
    {

        /// <summary>
        /// 获取或设置是否响应默认消息
        /// </summary>
        public static bool ResponseSuccessMessage { get; set; }

        static readonly ICollection<IDirective> _directives;

        static DirectiveCenter()
        {
            _directives = GetAllDirectives().Where(o => !o.GetType().IsDefined(typeof(IgnoreDirectiveAttribute), false)).OrderBy(o => o.Order).ToList();
            ResponseSuccessMessage = true;
        }


        static IEnumerable<IDirective> GetAllDirectives()
        {
            foreach (var item in WeChatHelper.GetReferencedAssemblies(true))
            {
                foreach (var instance in WeChatHelper.GetInstanceFromAssembly<IDirective>(item))
                {
                    yield return instance;
                }
            }
        }


        public static IRespond GetResponse(RequestMessageBase requestMessage)
        {
            foreach (var item in _directives)
            {
                if (item.IsMatch(requestMessage))
                {
                    return item.GetResponse(requestMessage);
                }
            }

            if (ResponseSuccessMessage)
            {
                return SuccessResponseMessage.Instance;
            }

            return null;
        }

    }
}

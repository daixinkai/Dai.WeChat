using Dai.WeChat.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    public static class DirectiveCenter
    {
        static readonly ICollection<IDirective> _directives;

        static DirectiveCenter()
        {
            _directives = GetAllDirectives().Where(o => !o.GetType().IsDefined(typeof(IgnoreDirectiveAttribute), false)).OrderBy(o => o.Order).ToList();
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
            return null;
        }

    }
}

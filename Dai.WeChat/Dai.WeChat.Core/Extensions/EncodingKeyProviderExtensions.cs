using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dai.WeChat
{
    internal static class EncodingKeyProviderExtensions
    {
        internal static void InitFromXmlNode(this IEncodingKeyProvider encodingKeyProvider, XmlNode node)
        {
            if (string.IsNullOrEmpty(encodingKeyProvider.AppId))
            {
                //接收者
                var toUserNode = node.SelectSingleNode("ToUserName");
                if (toUserNode != null)
                {
                    encodingKeyProvider.AppId = toUserNode.InnerText;
                }
            }

        }
    }
}

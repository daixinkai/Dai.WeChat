using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dai.WeChat
{
    internal static class XmlExtensions
    {
        internal static string GetInnerText(this XmlNode node, string nodeName)
        {
            XmlNode tempNode = node.SelectSingleNode(nodeName);
            return tempNode == null ? null : tempNode.InnerText;
        }

        internal static string GetInnerXml(this XmlNode node, string nodeName)
        {
            XmlNode tempNode = node.SelectSingleNode(nodeName);
            return tempNode == null ? null : tempNode.InnerXml;
        }
    }
}

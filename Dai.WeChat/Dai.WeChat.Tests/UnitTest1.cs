using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dai.WeChat.Request;
using System.Collections.Specialized;
using System.Web;
using System.Xml;

namespace Dai.WeChat.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string xml = @"<xml><ToUserName><![CDATA[wxb43ab71368baff54]]></ToUserName><Encrypt><![CDATA[2s12P2bDaKRD0sP+tb7j2wAfeQDCpqS8JdLV2HPgd0SRekMk9Zee0R11AV5XEBXcKCQa1aH9nxrnk7GiBhLQ22cm5SYrBDWlWdNGaJBvHkZABszXKoVp7ZJPEc54ayQKWwwy7a0SWXJmNp+9QIVPr7CS95xnsfs0O6yqpO2lPSkfiS0HqHC7Yq1vk5uFccNcFkI34Tx0kQcUiRUcbbsuy/AJ8ilSZhZgnzVeLre/oNNEcuKffabv6FCzzsbyJtyIDAollbkCk1AhxYJrdBNn2HJSOd/y2t9R3hVpJJqbi22X/oPgN9hiSPwT9+cNx9Mxcpl7rA4iitGHPcNJfkN2K6ghNM19/xq5xMFH50ivlerK0AtOObXsayTBxq1cLBzXMRfSRFcbzwDo1fB+xmAriObfRAkYTPfb7dxAi2Zw5fSUTs0tyvFrTHPIBXzpXBCAmQLuVs8pJZEqQEWSPWRykqPlhPAJkPDB6WADaF/0xRcmjaAon7L/S8lXssDm1IKy]]></Encrypt></xml>";

            string queryString = "signature=e2d7a4d5fc02ae9ccb34133a94709c932467aa79&timestamp=1480667966&nonce=431731761&encrypt_type=aes&msg_signature=4745eb93d065c3937f3f23bf450a7ad0a06899df";


            //RequestMessageBase.GetInstance(xml);


            var msg_signature = "4745eb93d065c3937f3f23bf450a7ad0a06899df";
            var timestamp = "1480667966";
            var nonce = "431731761";
            string sToken = "daixinkai";
            string appId = "wxb43ab71368baff54";
            string sEncodingAESKey = "gGnOmL5YyOlkAAcLhbogPU2wmLeboUzYlnTDwZ0231t";

            DefaultEncodingAESKeyProvider encodingAESKeyProvider = new DefaultEncodingAESKeyProvider(appId, sToken, sEncodingAESKey, msg_signature, timestamp, nonce);

            //encodingAESKeyProvider.AppId = appId;

            var instance = RequestMessageBase.GetInstance(xml, encodingAESKeyProvider);

            var value = encodingAESKeyProvider.Decrypt(xml);

        }

        [TestMethod]
        public void TestMethod2()
        {
            //公众平台上开发者设置的token, appID, EncodingAESKey
            string sToken = "QDG6eK";
            string sAppID = "wx5823bf96d3bd56c7";
            string sEncodingAESKey = "jWmYm7qr5nMoAUwZRjGtBxmz3KA1tkAj3ykkR6q2B2C";

            Tencent.WXBizMsgCrypt wxcpt = new Tencent.WXBizMsgCrypt(sToken, sEncodingAESKey, sAppID);

            /* 1. 对用户回复的数据进行解密。
            * 用户回复消息或者点击事件响应时，企业会收到回调消息，假设企业收到的推送消息：
            * 	POST /cgi-bin/wxpush? msg_signature=477715d11cdb4164915debcba66cb864d751f3e6&timestamp=1409659813&nonce=1372623149 HTTP/1.1
               Host: qy.weixin.qq.com
               Content-Length: 613
            *
            * 	<xml>
                   <ToUserName><![CDATA[wx5823bf96d3bd56c7]]></ToUserName>
                   <Encrypt><![CDATA[RypEvHKD8QQKFhvQ6QleEB4J58tiPdvo+rtK1I9qca6aM/wvqnLSV5zEPeusUiX5L5X/0lWfrf0QADHHhGd3QczcdCUpj911L3vg3W/sYYvuJTs3TUUkSUXxaccAS0qhxchrRYt66wiSpGLYL42aM6A8dTT+6k4aSknmPj48kzJs8qLjvd4Xgpue06DOdnLxAUHzM6+kDZ+HMZfJYuR+LtwGc2hgf5gsijff0ekUNXZiqATP7PF5mZxZ3Izoun1s4zG4LUMnvw2r+KqCKIw+3IQH03v+BCA9nMELNqbSf6tiWSrXJB3LAVGUcallcrw8V2t9EL4EhzJWrQUax5wLVMNS0+rUPA3k22Ncx4XXZS9o0MBH27Bo6BpNelZpS+/uh9KsNlY6bHCmJU9p8g7m3fVKn28H3KDYA5Pl/T8Z1ptDAVe0lXdQ2YoyyH2uyPIGHBZZIs2pDBS8R07+qN+E7Q==]]></Encrypt>
               </xml>
            */
            string sReqMsgSig = "477715d11cdb4164915debcba66cb864d751f3e6";
            string sReqTimeStamp = "1409659813";
            string sReqNonce = "1372623149";
            string sReqData = "<xml><ToUserName><![CDATA[wx5823bf96d3bd56c7]]></ToUserName><Encrypt><![CDATA[RypEvHKD8QQKFhvQ6QleEB4J58tiPdvo+rtK1I9qca6aM/wvqnLSV5zEPeusUiX5L5X/0lWfrf0QADHHhGd3QczcdCUpj911L3vg3W/sYYvuJTs3TUUkSUXxaccAS0qhxchrRYt66wiSpGLYL42aM6A8dTT+6k4aSknmPj48kzJs8qLjvd4Xgpue06DOdnLxAUHzM6+kDZ+HMZfJYuR+LtwGc2hgf5gsijff0ekUNXZiqATP7PF5mZxZ3Izoun1s4zG4LUMnvw2r+KqCKIw+3IQH03v+BCA9nMELNqbSf6tiWSrXJB3LAVGUcallcrw8V2t9EL4EhzJWrQUax5wLVMNS0+rUPA3k22Ncx4XXZS9o0MBH27Bo6BpNelZpS+/uh9KsNlY6bHCmJU9p8g7m3fVKn28H3KDYA5Pl/T8Z1ptDAVe0lXdQ2YoyyH2uyPIGHBZZIs2pDBS8R07+qN+E7Q==]]></Encrypt></xml>";
            string sMsg = "";  //解析之后的明文
            int ret = 0;
            ret = wxcpt.DecryptMsg(sReqMsgSig, sReqTimeStamp, sReqNonce, sReqData, ref sMsg);



            DefaultEncodingAESKeyProvider encodingAESKeyProvider = new DefaultEncodingAESKeyProvider(sAppID, sToken, sEncodingAESKey, sReqMsgSig, sReqTimeStamp, sReqNonce);

            var value = encodingAESKeyProvider.Decrypt(sReqData);

            if (ret != 0)
            {
                System.Console.WriteLine("ERR: Decrypt fail, ret: " + ret);
                return;
            }
            System.Console.WriteLine(sMsg);


            /*
             * 2. 企业回复用户消息也需要加密和拼接xml字符串。
             * 假设企业需要回复用户的消息为：
             * 		<xml>
             * 		<ToUserName><![CDATA[mycreate]]></ToUserName>
             * 		<FromUserName><![CDATA[wx5823bf96d3bd56c7]]></FromUserName>
             * 		<CreateTime>1348831860</CreateTime>
                    <MsgType><![CDATA[text]]></MsgType>
             *      <Content><![CDATA[this is a test]]></Content>
             *      <MsgId>1234567890123456</MsgId>
             *      </xml>
             * 生成xml格式的加密消息过程为：
             */
            string sRespData = "<xml><ToUserName><![CDATA[mycreate]]></ToUserName><FromUserName><![CDATA[wx582测试一下中文的情况，消息长度是按字节来算的396d3bd56c7]]></FromUserName><CreateTime>1348831860</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[this is a test]]></Content><MsgId>1234567890123456</MsgId></xml>";
            string sEncryptMsg = ""; //xml格式的密文
            ret = wxcpt.EncryptMsg(sRespData, sReqTimeStamp, sReqNonce, ref sEncryptMsg);
            System.Console.WriteLine("sEncryptMsg");
            System.Console.WriteLine(sEncryptMsg);

            /*测试：
             * 将sEncryptMsg解密看看是否是原文
             * */
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sEncryptMsg);
            XmlNode root = doc.FirstChild;
            string sig = root["MsgSignature"].InnerText;
            string enc = root["Encrypt"].InnerText;
            string timestamp = root["TimeStamp"].InnerText;
            string nonce = root["Nonce"].InnerText;
            string stmp = "";
            ret = wxcpt.DecryptMsg(sig, timestamp, nonce, sEncryptMsg, ref stmp);
            System.Console.WriteLine("stemp");
            System.Console.WriteLine(stmp + ret);

        }

        [TestMethod]
        public void TestMethod3()
        {
            string xml = "<xml><ToUserName><![CDATA[gh_7b44a2edbf75]]></ToUserName><Encrypt><![CDATA[fADvCAUGNUXjpj9fktXOroeDbsFgxGwAwN9Z6TeI5+sBjb1MeRTw0lUdqlr5C0TpprJ9VZuwCjzBc6PDcigBE5cfda2FtY42hbxdyJQ87/Gdc3sBpgZzt8FnKPqDOAZ7o3M9xdWqwlwtYq7mhYNO6Qs0yOkW5RefkccgS7DCDoekWt6vjDRhEv7LWoQQlwbUNQWSqGz8DLDkiOg462wdYRtzOU6UInLAKH85EYoUFEXcBeI39R9CUKHEd/wvTdPOxPLuZYTFSygcG8jPA5tOWQz13lpb4s7ZyUM1uP9GwqYocwgp6r8zkRzwamBAED6BQ5eNYTCSMFqPUmn22LVhyJe2JO05dLmFbx1z2MwsywTQPeGt4/WCsmKRE7L1pzF+3j1FR+rWLcH1t2CA1nEyqZKiCQWCFvZ+PcOwNEOOCb0=]]></Encrypt></xml>";

            string sAppId = "wxb43ab71368baff54";
            string sToken = "daixinkai";
            //"8148081e1e0307789026db4f63ce40fb"
            string sEncodingAESKey = "jqrj2EPPEAByFF0gN1KIqZMpiR5EuFImJlPacD7OaVz";

            string queryString = "signature=b8f61d04bf4a84f0c0262a8930377ebc36b1bd2f&timestamp=1484810001&nonce=1632765309&openid=oRCT_jrmHyguNfexhImv2NRiwGFM&encrypt_type=aes&msg_signature=1bf0583fbaf37dfee33c7a9d33e76cfab416749f";

            HttpRequest request = new HttpRequest("", "http://www.baidu.com", queryString);

            DefaultEncodingAESKeyProvider encodingAESKeyProvider = new DefaultEncodingAESKeyProvider(sAppId, sToken, sEncodingAESKey, request.QueryString);



            var value = encodingAESKeyProvider.Decrypt(xml);


            var instance = RequestMessageBase.GetInstance(xml, encodingAESKeyProvider);

        }


    }
}

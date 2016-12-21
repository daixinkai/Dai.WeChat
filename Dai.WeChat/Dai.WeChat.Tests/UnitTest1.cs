using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dai.WeChat.Request;
using System.Collections.Specialized;

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

            DefaultEncodingAESKeyProvider encodingAESKeyProvider = new DefaultEncodingAESKeyProvider(sToken, sEncodingAESKey, msg_signature, timestamp, nonce);

            //encodingAESKeyProvider.AppId = appId;

            var instance = RequestMessageBase.GetInstance(xml, encodingAESKeyProvider);

            var value = encodingAESKeyProvider.Decrypt(xml);

        }

        [TestMethod]
        public void TestMethod2()
        {
            string xml = @"<xml><ToUserName><![CDATA[gh_751653ce20c7]]></ToUserName><FromUserName><![CDATA[oJOypjpjy_lGb6zhygFXB4q0zz64]]></FromUserName><CreateTime>1482289557</CreateTime><MsgType><![CDATA[event]]></MsgType><Event><![CDATA[CLICK]]></Event><EventKey><![CDATA[Help]]></EventKey></xml>";

          
            var instance = RequestMessageBase.GetInstance(xml);

        }
    }
}

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
            //string xml = @"<xml><ToUserName><![CDATA[gh_751653ce20c7]]></ToUserName><FromUserName><![CDATA[oJOypjpjy_lGb6zhygFXB4q0zz64]]></FromUserName><CreateTime>1482289557</CreateTime><MsgType><![CDATA[event]]></MsgType><Event><![CDATA[CLICK]]></Event><EventKey><![CDATA[Help]]></EventKey></xml>";

            string xml = "<xml><ToUserName><![CDATA[gh_7b44a2edbf75]]></ToUserName><Encrypt><![CDATA[i9tRB+g/Y/aFIiMg/95ZsXJc1myEL7UwIMBH+lsAD00tW++D41emQVOIAPpDSNX3x5W+l/iR3UuinTguReHQHEjpKgEk0q8ZKYyd6wp4Vt2GoogwLeH7ZaitIfH3cS34uvd9Q9Op5Z8zaB81n+YooDGM4YIdVlQvB3ydkGYpp15NIkrW3ivorHeEL9VwXc+BDog44WwW3U/UMFy+ns+tnvOectK7VCA4DHuDaaumNIF0u+FWzlYLRGDDV4mNb0+V1JURerlzFvhMX0mTNOzFlx6eftfAgmFj8EI0MulcQmbOo1WMEHXYAeYPeE4u3OC0XFw6XM4w8pcuc1O5IojuXup+z3Yl7q6ngo/nABUI558eBpyb9Qc+aOacUQhLS3AyLDq8rty4JeYJPWL8Ptl7xxdS18nGIf+GNJHi1CnsqRQ=]]></Encrypt></xml>";

            string sToken = "daixinkai";
            string sEncodingAESKey = "jqrj2EPPEAByFF0gN1KIqZMpiR5EuFImJlPacD7OaVz";

            NameValueCollection nameValue = new NameValueCollection();

            nameValue.Add("signature", "e38161882b1dc6fd3a0a95f7caf325b99f3a3f57");
            nameValue.Add("timestamp", "1484734150");
            nameValue.Add("nonce", "66184180");
            nameValue.Add("openid", "oRCT_jrmHyguNfexhImv2NRiwGFM");
            nameValue.Add("encrypt_type", "aes");
            nameValue.Add("msg_signature", "d9a62410ec2f2cf7e258054c54f32871eed74a3a");


            //"signature=7a52eaf1b6e67b366f03ae360265bd80fd6f0350&timestamp=1484733943&nonce=729502389&openid=oRCT_jrmHyguNfexhImv2NRiwGFM&encrypt_type=aes&msg_signature=fb6cc65ce40687701c20b981bb097c2cf67700cf"

            DefaultEncodingAESKeyProvider encodingAESKeyProvider = new DefaultEncodingAESKeyProvider(sToken, sEncodingAESKey, nameValue);

            var instance = RequestMessageBase.GetInstance(xml, encodingAESKeyProvider);

        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dai.WeChat.Request;

namespace Dai.WeChat.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string xml = @"<xml><ToUserName><![CDATA[wx2b39b54549e3dfd3]]></ToUserName><Encrypt><![CDATA[HoZSSc2tQvV+w9hY+OZwiAVUgU8I54lxbi+cTLKO07nsTbkf9xpq4vsQbN4rl9+1qfXml3hIBrt23m3D6CLFqXwFKQ+oq1TeCj+7/z/weoBUUuIYJqU9ZYkPnWgqOKqwiroBZu8/MdEp/5wa6zTSL3Ng/yJVRM8Ctk7EENl6phBXkOewxun69g+Wmi6xtbK02ECl8iGdz/bq9UnPEFRr5CuiJJc5WTZpldQkmzSrRF9HdKYpzF+MsY78w5UDBLSDTn4Ep8d6Z3Iu762RWp9RMhnBvfAyIeR7z155+VCYBB2AjgVqxmRkWZvcp0vLWUeJzm6zd/hTl+FVrJECDPbaUzIbRPzj00bt6e8VCtRJ/YI1587UxybAm6ReVk4SXaDIc71cspy6Mto3kSBqMmVt6ZtVgYdfzT2H6YtUnaNLC8o0PKF7RXwj4ZrJu9nl5TWTh2nMdKhfIPHm4uD8Oe0+4Q==]]></Encrypt></xml>";

            string queryString = "signature=0bf3272848b0e5aa06f7a8790ee4bfe270eee57a&timestamp=1480586740&nonce=1743926060&encrypt_type=aes&msg_signature=0d085c3c418ebd0079f21617c3e64904083d85c2";

            RequestMessageBase.GetInstance(xml);

        }
    }
}

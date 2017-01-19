using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    /// <summary>
    /// AES
    /// </summary>
    public sealed class DefaultEncodingAESKeyProvider : IEncodingKeyProvider
    {

        public DefaultEncodingAESKeyProvider(string appId, string token, string encodingAesKey, NameValueCollection nameValueCollection)
        {
            AppId = appId;
            Token = token;
            EncodingAesKey = encodingAesKey;
            MsgSignature = nameValueCollection["msg_signature"];
            TimeStamp = nameValueCollection["timestamp"];
            Nonce = nameValueCollection["nonce"];
        }

        public DefaultEncodingAESKeyProvider(string appId, string token, string encodingAesKey, string msgSignature, string timeStamp, string nonce)
        {
            Token = token;
            EncodingAesKey = encodingAesKey;
            AppId = appId;
            MsgSignature = msgSignature;
            TimeStamp = timeStamp;
            Nonce = nonce;
        }


        public string Token { get; private set; }

        public string EncodingAesKey { get; private set; }

        public string AppId { get; private set; }

        public string MsgSignature { get; set; }

        public string TimeStamp { get; set; }

        public string Nonce { get; set; }

        public string Decrypt(string value)
        {
            string result = "";
            var code = new WXBizMsgCrypt(Token, EncodingAesKey, AppId).DecryptMsg(MsgSignature, TimeStamp, Nonce, value, ref result);
            if (code == 0)
            {
                return result;
            }
            return null;
        }

        public string Encrypt(string value)
        {
            string result = "";
            var code = new WXBizMsgCrypt(Token, EncodingAesKey, AppId).EncryptMsg(value, TimeStamp, Nonce, ref result);
            if (code == 0)
            {
                return result;
            }
            return null;
        }

        public string GetEchoString(string value)
        {
            string result = "";
            var code = new WXBizMsgCrypt(Token, EncodingAesKey, AppId).VerifyURL(MsgSignature, TimeStamp, Nonce, value, ref result);
            if (code == 0)
            {
                return result;
            }
            return null;
        }
    }
}

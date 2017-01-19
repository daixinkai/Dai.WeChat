using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    public sealed class AccessToken
    {

        private AccessToken() { }
        static AccessToken()
        {
            _cache = CacheFactory.Instance.CreateExpireMemoryCache<Tuple<string, string>, AccessToken>(new TimeSpan(2, 0, 0));
        }

        static readonly IExpireCache<Tuple<string, string>, AccessToken> _cache;

        public string AppId { get; private set; }

        public string AppSecret { get; private set; }

        string _jsapi_ticket;
        public string jsapi_ticket
        {
            get
            {
                if (string.IsNullOrEmpty(_jsapi_ticket))
                {
                    _jsapi_ticket = WeiXinApiHelper.Getjsapi_ticket(_accessToken);
                }
                return _jsapi_ticket;
            }
        }

        string _accessToken;

        public static AccessToken Get(string appId, string appSecret)
        {

            return _cache.Get(new Tuple<string, string>(appId, appSecret), () =>
            {
                var accessToken = new AccessToken()
                {
                    AppId = appId,
                    AppSecret = appSecret
                };

                //获取数据
                var token = WeiXinApiHelper.GetAccessToken(appId, appSecret);

                if (string.IsNullOrEmpty(token))
                {
                    throw new Exception("获取Access_Token失败!");
                }
                accessToken._accessToken = token;
                return accessToken;
            });

        }

        public override string ToString()
        {
            return _accessToken;
        }


    }
}

using Dai.WeChat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat
{
    public static class WeiXinApiHelper
    {
        public const string ApiUrl = "https://api.weixin.qq.com/";

        public static string GetAccessToken(string appId, string appSecret)
        {
            var url = ApiUrl + "cgi-bin/token?grant_type=client_credential";

            url += "&appid=" + appId;

            url += "&secret=" + appSecret;

            string response = DownloadString(url);

            try
            {
                return DeSerialize<AccessTokenResponse>(response).access_token;
            }
            catch
            {
                return null;
            }

        }

        public static string Getjsapi_ticket(string accessToken)
        {
            var url = ApiUrl + "cgi-bin/ticket/getticket?access_token=" + accessToken;

            url += "&type=jsapi";

            string response = DownloadString(url);

            try
            {
                return DeSerialize<WeChatApiTicketResponse>(response).ticket;
            }
            catch
            {
                return null;
            }
        }

        static string DownloadString(string url)
        {
            WebClient client = new WebClient();

            try
            {
                return client.DownloadString(url);
            }
            catch
            {
                return null;
            }
            finally
            {
                client.Dispose();
            }
        }

        /// <summary>
        /// 下载Json资源
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        static string DownJsonData(string url, string data = null)
        {
            WebClient client = new WebClient();
            client.Headers["Content-Type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    return client.DownloadString(url);
                }
                else
                {
                    return client.UploadString(url, data);
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                client.Dispose();
            }
        }

        static T DeSerialize<T>(string json)
        {
            return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<T>(json);
        }

        class AccessTokenResponse
        {
            public string access_token { get; set; }

            public int expires_in { get; set; }
        }


        public static WeChatApiResponse CreateMenu(string access_Token, CustomMenu menu)
        {
            string url = ApiUrl + "cgi-bin/menu/create?access_token=" + access_Token;

            string response = DownJsonData(url, menu.ToString());

            return DeSerialize<WeChatApiResponse>(response);
        }


        /// <summary>
        /// 返回当前公众号的用户列表
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="next_OpenID">第一个拉取的OPENID，不填默认从头开始拉取</param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static UserList GetUserList(string access_Token, string next_OpenID, out WeChatApiResponse state)
        {
            state = null;
            string url = ApiUrl + "cgi-bin/user/get?access_token=" + access_Token + "&next_openid=" + next_OpenID;

            string response = DownJsonData(url);
            try
            {
                return DeSerialize<UserList>(response);
            }
            catch (Exception ex)
            {
                state = DeSerialize<WeChatApiResponse>(response);
                return null;
            }
        }

        /// <summary>
        /// 返回当前公众号的用户列表从头开始拉取
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static UserList GetUserList(string access_Token, out WeChatApiResponse state)
        {
            state = null;
            string url = ApiUrl + "cgi-bin/user/get?access_token=" + access_Token;
            string response = DownJsonData(url);
            try
            {
                return DeSerialize<UserList>(response);
            }
            catch (Exception ex)
            {
                state = DeSerialize<WeChatApiResponse>(response);
                return null;
            }
        }

        /// <summary>
        /// 获取用户基本信息（包括UnionID机制）
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="openID">用户openID</param>
        /// <param name="lang">语言</param>
        /// <param name="state">返回状态</param>
        /// <returns></returns>
        public static User GetUser(string access_Token, string openID, Lang lang, out WeChatApiResponse state)
        {
            state = null;
            string url = ApiUrl + "cgi-bin/user/info?access_token=" + access_Token + "openid=" + openID + "&lang=" + lang.ToString();
            string response = DownJsonData(url);
            try
            {
                return DeSerialize<User>(response);
            }
            catch (Exception ex)
            {
                state = DeSerialize<WeChatApiResponse>(response);
                return null;
            }
        }

        /// <summary>
        /// 获取用户基本信息（包括UnionID机制）
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="openID">用户openID</param>
        /// <param name="lang">语言</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public static User GetUser(string access_Token, string openID, out WeChatApiResponse state)
        {
            return GetUser(access_Token, openID, Lang.Zh_CN, out state);
        }

        /// <summary>
        /// 创建客服
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="account"></param>
        /// <returns></returns>
        public static WeChatApiResponse CreateKFAccount(string access_Token, KFAccount account)
        {
            string post = account.ToString();

            string url = ApiUrl + "customservice/kfaccount/add?access_token=" + access_Token;

            string response = DownJsonData(url, post);

            return DeSerialize<WeChatApiResponse>(response);
        }

        /// <summary>
        /// 更新客服
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="account"></param>
        /// <returns></returns>
        public static WeChatApiResponse UpdateKFAccount(string access_Token, KFAccount account)
        {
            string post = account.ToString();

            string url = ApiUrl + "customservice/kfaccount/update?access_token=" + access_Token;

            string response = DownJsonData(url, post);

            return DeSerialize<WeChatApiResponse>(response);
        }

        /// <summary>
        /// 删除客服
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="account"></param>
        /// <returns></returns>
        public static WeChatApiResponse DeleteKFAccount(string access_Token, KFAccount account)
        {
            string post = account.ToString();

            string url = ApiUrl + "customservice/kfaccount/del?access_token=" + access_Token;

            string response = DownJsonData(url, post);

            return DeSerialize<WeChatApiResponse>(response);
        }

        /// <summary>
        /// 发送客服消息
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="account"></param>
        /// <returns></returns>
        public static WeChatApiResponse SendMessage(string access_Token, string openID, KFMessage message)
        {
            string post = message.ToString();

            string url = ApiUrl + "customservice/kfaccount/del?access_token=" + access_Token;

            string response = DownJsonData(url, post);

            return DeSerialize<WeChatApiResponse>(response);
        }

        ///// <summary>
        ///// 发送客服消息
        ///// </summary>
        ///// <param name="account">微信帐号</param>
        ///// <param name="account"></param>
        ///// <returns></returns>
        //public static WeChatApiResponse SendMessage(WeiXinAccount account, string openID, CustomMessage message)
        //{
        //    return SendMessage(GetAccessToken(account).Access_Token, openID, message);
        //}

    }
}

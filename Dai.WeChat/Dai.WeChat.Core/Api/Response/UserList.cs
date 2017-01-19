using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Api
{
    /// <summary>
    /// 表示获取用户列表结果
    /// </summary>
    public class UserList
    {
        /// <summary>
        /// 关注该公众账号的总用户数
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 拉取的OPENID个数，最大值为10000
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 列表数据，OPENID的列表
        /// </summary>
        public UserList.User Data { get; set; }

        /// <summary>
        /// 拉取列表的后一个用户的OPENID
        /// </summary>
        public string Next_OpenID { get; set; }

        public class User
        {
            public List<string> OpenID { get; set; }
        }

    }
}

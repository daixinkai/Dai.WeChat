using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dai.WeChat.Api
{
    /// <summary>
    /// 客服账号
    /// </summary>
    public class KFAccount
    {
        /// <summary>
        /// 客服账号
        /// </summary>
        public string KF_Account { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        public override string ToString()
        {
            return Tools.ToJson(this);
        }
    }
}

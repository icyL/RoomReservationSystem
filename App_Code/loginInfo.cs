using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 网上订房系统.App_Code
{
    public class loginInfo
    {
        public string Lid { set; get; }//身份证号
        public string Laccount { set; get; }//手机账号
        public string Lpassword { set; get; }//登录密码

        public loginInfo(string id,string account, string password)
        {
            this.Lid = id;
            this.Laccount = account;
            this.Lpassword = password;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 网上订房系统.App_Code
{
    public class userInfo
    {
        public string Uid { get; set; }//身份证号
        public string Uname { get; set; }//姓名
        public string Usex { get; set; }//性别
        public DateTime Ubirthday { get; set; }//出生日期
        public string Uemail { get; set; }//电子邮箱

    }
}
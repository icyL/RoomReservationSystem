using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 网上订房系统.App_Code
{
    public class User
    {            
        //根据手机账号查询身份证号码
        public string getCardId(string telephone/*手机账号*/)
        {
            string sql_0 = "select Lid from LoginInfo where Laccount='" + telephone + "'";
            DataTable table = DatabaseLink.GetData(sql_0);//将查询结果存于table表中
            string id = table.Rows[0][0].ToString();//取table表中的查询结果
            return id;//返回身份证号码
        }

       
        //查询用户是否完善过个人信息
        public bool isImproved(string id/*身份证号*/)
        {
            string sql = "select Uid from UserInfo where Uid='" + id + "'";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            if (table.Rows.Count > 0)
            {//有完善过
                return true;
            }
            else
                return false;
        }

        //添加个人信息
        public bool addUserInfo(userInfo s/*个人信息对象*/)
        {
            string sql = "insert into UserInfo values('" + s.Uid +"','"+ s.Uname + "','" + s.Usex + "','" + s.Ubirthday + "','" + s.Uemail + "')";
            int num = DatabaseLink.UpdateData(sql);
            if (num > 0)
                return true;
            else
                return false;
        }
       
     
        //查询个人信息，用于显示在完善个人信息界面
        public DataTable searchUserInfo(string id/*身份证号码*/)
        {
            string sql = "select * from UserInfo where Uid='" + id + "'";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            return table;
        }

        //修改个人基本信息
        public bool updateUserInfo(userInfo s, string id/*根据登录名查询的身份证号*/)
        {
            string sql = "update UserInfo set Uname='" + s.Uname + "',Usex='" + s.Usex + "',Ubirthday='" + s.Ubirthday + "',Uemail='" + s.Uemail + "' where Uid='" + id + "'";
            int num = DatabaseLink.UpdateData(sql);
            if (num > 0)
                return true;
            else
                return false;
        }

        //查询手机号
        public string searchTelephone(string id/*身份证号*/)
        {
            string sql = "select Laccount from LoginInfo where Lid='" + id + "'";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            string telephone = table.Rows[0][0].ToString();//取table表中的查询结果
            return telephone;//返回手机号
        }

        //修改账号绑定的手机号
        public bool updateLoginAccount(string newTelephone/*新手机号*/, string id/*身份证号*/)
        {
            string sql = "update LoginInfo set Laccount='" + newTelephone + "' where Lid='" + id + "'";
            int num = DatabaseLink.UpdateData(sql);
            if (num > 0)
                return true;
            else
                return false;
        }

        //查询密码
        public string searchPassword(string id/*身份证号*/)
        {
            string sql = "select Lpassword from LoginInfo where Lid='" + id + "'";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            string password = table.Rows[0][0].ToString();//取table表中的查询结果
            return password;//返回密码
        }

        //修改密码
        public bool updatePassword(string newPassword/*新密码*/, string id/*身份证号*/)
        {
            string sql = "update LoginInfo set Lpassword='" + newPassword + "' where Lid='" + id + "'";
            int num = DatabaseLink.UpdateData(sql);
            if (num > 0)
                return true;
            else
                return false;
        }
    }
}

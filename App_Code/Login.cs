using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 网上订房系统.App_Code
{
    public class Login
    {
        //判断登录账号是否存在
        public bool getLoginAccount(string telephone/*注册时输入的手机号码*/)
        {
            string sql_0 = "select Laccount from LoginInfo where Laccount='" + telephone + "'";
            DataTable table_0 = DatabaseLink.GetData(sql_0); //将查询结果存于table表中
            if (table_0.Rows.Count > 0)
            {
                //此手机账号存在
                return true;

            }
            else
                return false;
        }

        //判断登录账号与密码是否正确
        public int getLoginPassword(string telephone, string password)
        {
            string sql_0 = "select Laccount from LoginInfo where Laccount='" + telephone + "'";
            DataTable table_0 = DatabaseLink.GetData(sql_0);//将查询结果存于table表中
            if (table_0.Rows.Count > 0)
            {//有此手机账号
                string sql_1 = "select Lpassword from LoginInfo where Laccount='" + telephone + "'";
                DataTable table_1 = DatabaseLink.GetData(sql_1);//将查询结果存于table表中
                string pw = table_1.Rows[0][0].ToString();//取table表中的查询结果
                if (password.Equals(pw.Trim()))
                    return 1;//密码正确
                else
                    return 0;//密码错误
            }
            else
                return -1;//无此手机账号
        }

        //身份证号查重
        public bool getCardId(string id/*注册时输入的身份证号*/)
        {
            string sql = "select Lid from LoginInfo where Lid='" + id + "'";
            DataTable table_0 = DatabaseLink.GetData(sql);//将查询结果存于table表中
            if (table_0.Rows.Count > 0)
            {//此身份证号存在
                return true;
            }
            else
                return false;
        }

        //注册，添加登录信息
        public bool addLoginInfo(loginInfo g)
        {
            string sql = "insert into LoginInfo values('" + g.Lid + "','" + g.Laccount + "','" + g.Lpassword + "')";
            int num = DatabaseLink.UpdateData(sql);
            if (num > 0)
                return true;
            else
                return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 网上订房系统.App_Code;//引用App_Code里的类文件

namespace 网上订房系统
{
    public partial class LoginMain : System.Web.UI.Page
    {
        App_Code.Login login = new App_Code.Login();
        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;//使用前台约束控件，如是否为空，是否相同等控件时必须加上这句
        }
        protected void Login_Click(object sender, EventArgs e)
        {                    
            //验证数据库登录信息表中 的手机账号+密码
            if (login.getLoginPassword(Account.Text.Trim(), Password.Text.Trim()) == 1)//手机账号存在且密码正确
            {
                string telephone = Account.Text.ToString().Trim();//手机号账户
                Session["cardId"] = user.getCardId(telephone);//根据手机账号获取身份证号,需要传值到个人信息页面、手机换绑和密码修改页面、填写订单页面、订单查看页面
                Response.Redirect("Login/UserMain.aspx");
            }
            else if (login.getLoginPassword(Account.Text.Trim(), Password.Text.Trim()) == 0)//手机账号存在但密码错误
            {
                // Response.Write("<script>alert('密码错误！');</script>");
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('密码错误！');</script>");
            }
            else//手机账号不存在
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('此用户不存在！');</script>");
            }
        }
    }
}
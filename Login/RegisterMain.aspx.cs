using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 网上订房系统.App_Code;

namespace 网上订房系统
{
    public partial class RegisterMain : System.Web.UI.Page
    {
        App_Code.Login login = new App_Code.Login();      
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
       
        protected void Register_Click(object sender, EventArgs e)
        {
            string id = CardId.Text.Trim();//输入的身份证号
            string account = Telephone.Text.Trim();//输入的手机号
            string password = Password.Text.Trim();//密码
            string verify = VerifyPassword.Text.Trim();//确认密码

            loginInfo g = new loginInfo(id, account, password);

                if (!login.getLoginAccount(g.Laccount) && !login.getCardId(g.Lid)) //手机号码和身份证号都不存在
               {
                           login.addLoginInfo(g);//添加登录信息表
                           Response.Redirect("LoginMain.aspx");
               }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('用户名或身份证号已被注册！');</script>");
                }
            }              
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 网上订房系统.App_Code;

namespace 网上订房系统
{
    public partial class ModifyPassword : System.Web.UI.Page
    {
        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            string id = Session["cardId"].ToString();//个人信息页面的身份证号
            OldPassword.Text = user.searchPassword(id).Trim();//查询现密码,放在不可见的标签里
        }   
        protected void Save_Click(object sender, EventArgs e)
        {
            if (OldPassword.Text != CurrentPassword.Text)//输入现密码不正确            
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('现密码输入错误！');</script>");
            else
            {
                string id = Session["cardId"].ToString();//个人信息页面的身份证号
                string newPassword = NewPassword.Text.Trim();//新密码
                user.updatePassword(newPassword, id);//修改登录信息表的密码
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('修改成功！');</script>");
            }
        }
    }
 }
    
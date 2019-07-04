using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 网上订房系统.App_Code;

namespace 网上订房系统
{
    public partial class ChangeTelephone : System.Web.UI.Page
    {
        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            string id = Session["cardId"].ToString();//登录页面后台的身份证号
            string oldTelephone= user.searchTelephone(id).Trim();//查询原手机号
            OldTelephone.Text = oldTelephone;//填入原手机号
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string id = Session["cardId"].ToString();//个人信息页面的身份证号
            string newTelephone =NewTelephone.Text.Trim();//新的手机号
            user.updateLoginAccount(newTelephone, id);//修改登录信息表的手机号
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('换绑成功！');</script>");

            string oldTelephone = user.searchTelephone(id).Trim();//查询现手机号
            OldTelephone.Text = oldTelephone;//填入原手机号
            NewTelephone.Text = "";//清空新手机号
        }
    }
}
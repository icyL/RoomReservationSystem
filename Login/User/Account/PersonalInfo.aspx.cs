using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 网上订房系统.App_Code;

namespace 网上订房系统
{
    public partial class PersonalInfo : System.Web.UI.Page
    {
        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            DateTime tnow = DateTime.Now;//现在时间 
            ArrayList alyear = new ArrayList();
            int i;
            for (i = 1970; i <= 2019; i++)
                alyear.Add(i);
            ArrayList almonth = new ArrayList();
            for (i = 1; i <= 12; i++)
                almonth.Add(i);
            if (!this.IsPostBack)
            {
                DropDownList1.DataSource = alyear;
                DropDownList1.DataBind();//绑定年 
                //选择当前年 
                DropDownList1.SelectedValue = tnow.Year.ToString();
                DropDownList2.DataSource = almonth;
                DropDownList2.DataBind();//绑定月 
                //选择当前月 
                DropDownList2.SelectedValue = tnow.Month.ToString();
                int year, month;
                year = Int32.Parse(DropDownList1.SelectedValue);
                month = Int32.Parse(DropDownList2.SelectedValue);
                binddays(year, month);//绑定天 
                //选择当前日期 
                DropDownList3.SelectedValue = tnow.Day.ToString();


                CardId.Text = Session["cardId"].ToString();//接收来自登录界面后台的身份证号传值

                if (user.isImproved(CardId.Text) == true)//如果用户完善过个人信息
                {
                    DataTable table = user.searchUserInfo(CardId.Text.Trim());//根据身份证号查询用户信息表
                    //填入姓名
                    UserName.Text = table.Rows[0][1].ToString();
                    //选中性别
                    if (table.Rows[0][2].ToString() == "男")
                        Sex1.Checked = true;
                    if (table.Rows[0][2].ToString() == "女")
                        Sex2.Checked = true;
                    //填入出生日期
                    string date = table.Rows[0][3].ToString();
                    string[] splitStrings = date.Trim().Split(' ');
                    string[] s = splitStrings[0].Trim().Split('/');
                    DropDownList1.Text = s[0];
                    DropDownList2.Text = s[1];
                    DropDownList3.Text = s[2];
                    //填入电子邮箱
                    Email.Text = table.Rows[0][4].ToString();

                    UpdateButton.Visible = true;
                    SaveButton.Visible = false;
                    UserName.Enabled = false;
                    Sex1.Enabled = false;
                    Sex2.Enabled = false;
                    DropDownList1.Enabled = false;
                    DropDownList2.Enabled = false;
                    DropDownList3.Enabled = false;
                    Email.Enabled = false;
                }
                else
                {
                    UpdateButton.Visible = false;
                    SaveButton.Visible = true;
                    UserName.Enabled = true;
                    Sex1.Enabled = true;
                    Sex2.Enabled = true;
                    DropDownList1.Enabled = true;
                    DropDownList2.Enabled = true;
                    DropDownList3.Enabled = true;
                    Email.Enabled = true;
                }
            }
        }

        //判断闰年 
        private bool checkleap(int year)
        {
            if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
                return true;
            else return false;
        }

        //绑定每月的天数 
        private void binddays(int year, int month)
        {
            int i;
            ArrayList alday = new ArrayList();
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    for (i = 1; i <= 31; i++)
                        alday.Add(i);
                    break;
                case 2:
                    if (checkleap(year))
                    {
                        for (i = 1; i <= 29; i++)
                            alday.Add(i);
                    }
                    else
                    {
                        for (i = 1; i <= 28; i++)
                            alday.Add(i);
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    for (i = 1; i <= 30; i++)
                        alday.Add(i);
                    break;
            }
            DropDownList3.DataSource = alday;
            DropDownList3.DataBind();
        }

        //选择年 
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year, month;
            year = Int32.Parse(DropDownList1.SelectedValue);
            month = Int32.Parse(DropDownList2.SelectedValue);
            binddays(year, month);
        }

        //选择月 
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year, month;
            year = Int32.Parse(DropDownList1.SelectedValue);
            month = Int32.Parse(DropDownList2.SelectedValue);
            binddays(year, month);
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            UpdateButton.Visible = false;
            SaveButton.Visible = true;
            UserName.Enabled = true;
            Sex1.Enabled = true;
            Sex2.Enabled = true;
            DropDownList1.Enabled = true;
            DropDownList2.Enabled = true;
            DropDownList3.Enabled = true;
            Email.Enabled = true;
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            userInfo s = new userInfo();
            //身份证号
            s.Uid = CardId.Text;
            //姓名
            s.Uname = UserName.Text;
            //性别
            if (Sex1.Checked)
                s.Usex = Sex1.Text;
            if (Sex2.Checked)
                s.Usex = Sex2.Text;
            //出生日期
            string str = (DropDownList1.Text + "-" + DropDownList2.Text + "-" + DropDownList3.Text).ToString();
            DateTime date = Convert.ToDateTime(str);
            s.Ubirthday = date;
            //电子邮箱
            s.Uemail = Email.Text;

            if (user.isImproved(CardId.Text))//如果完善过个人信息
                user.updateUserInfo(s, CardId.Text);//修改记录
            else
                user.addUserInfo(s);//向用户信息表插入一条新记录

            UpdateButton.Visible = true;
            SaveButton.Visible = false;

            UserName.Enabled = false;
            Sex1.Enabled = false;
            Sex2.Enabled = false;
            DropDownList1.Enabled = false;
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;
            Email.Enabled = false;

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('保存成功！');</script>");
        }
      
    }
}
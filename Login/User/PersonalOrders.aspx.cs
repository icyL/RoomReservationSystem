using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 网上订房系统.App_Code;

namespace 网上订房系统
{
    public partial class PersonalOrders : System.Web.UI.Page
    {
        Order order = new Order();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Session["cardId"].ToString();//登录页面后台的身份证号
            DataTable table = order.searchPersonalOrderInfo(id);//根据身份证号查询个人订单
            this.GridView1.DataSource = table;
            this.GridView1.DataBind();//数据绑定
        }

    }
}
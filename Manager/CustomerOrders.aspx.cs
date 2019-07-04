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
    public partial class CustomerOrders : System.Web.UI.Page
    {
        Order order = new Order();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable table = order.searchUserOrderInfo();
            this.GridView1.DataSource = table;
            this.GridView1.DataBind();//数据绑定
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            string bycardId = SearchByCardId.Value.Trim();//身份证号
            DataTable ds = order.searchUserOrderInfo(bycardId);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();//数据重新绑定
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            SearchByCardId.Value = "";
        }
    }
}
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
    public partial class RoomReservation : System.Web.UI.Page
    {
        Hotel hotel = new Hotel();
        Room room = new Room();
        Order order = new Order();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request["HotelId"];//接收来自在线订房页面a链接传递过来的酒店编号           
                DataTable table = hotel.searchHotelById(id);
                Name.Text = table.Rows[0]["Hname"].ToString();
                Province.Text = table.Rows[0]["Hprovince"].ToString();
                Price.Text = table.Rows[0]["Hprice"].ToString();
                Address.Text = table.Rows[0]["Haddress"].ToString();
                Contact.Text = table.Rows[0]["Hcontact"].ToString();
                Introduce.Text = table.Rows[0]["Hintroduce"].ToString();
                HotelImg.ImageUrl = "~/images/" + Request["HotelImgUrl"];//接收来自在线订房页面a链接传递过来的酒店图片url 

                InitGridView();//酒店客房信息表数据加载
            }

            string cardId = Session["cardId"].ToString();//登录页面后台的身份证号
            UserName.Text = order.searchUserName(cardId);//姓名
            Telephone.Text = order.searchTelephone(cardId);//联系方式
            CardId.Text = cardId;//身份证号
            OrderDate.Text = System.DateTime.Now.ToString("d");//获得当前系统日期作为预订日期
        }

        //合并表头
        protected void Merge_Header(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                TableCellCollection tcHeader = e.Row.Cells;
                //清除自动生成的表头
                tcHeader.Clear();

                tcHeader.Add(new TableHeaderCell());
                tcHeader[0].RowSpan = 2;
                tcHeader[0].Text = "客房编号";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[1].RowSpan = 2;
                tcHeader[1].Text = "客房图片";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[2].RowSpan = 2;
                tcHeader[2].Text = "客房类型";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[3].RowSpan = 2;
                tcHeader[3].Text = "床位数量";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[4].ColumnSpan = 5;
                tcHeader[4].Text = "客房配置";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[5].RowSpan = 2;
                tcHeader[5].Text = "每晚价格";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[6].RowSpan = 2;
                tcHeader[6].Text = "备注";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[7].RowSpan = 2;
                tcHeader[7].Text = "可预约数量";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[8].RowSpan = 2;
                tcHeader[8].Text = "选择</th></tr><tr>";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[9].Text = "空调";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[10].Text = "电视机";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[11].Text = "电吹风";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[12].Text = "电话";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[13].Text = "WIFI";

                //背表头颜色
                for (int i = 0; i < 14; i++)
                {
                    tcHeader[i].BackColor = System.Drawing.Color.Blue;
                    tcHeader[i].ForeColor = System.Drawing.Color.White;
                }
            }
        }

        //显示酒店客房信息表,酒店客房信息和客房类型两表连接查询
        protected void InitGridView()
        {
            string id = Request["HotelId"];//接收来自酒店信息页面a链接传递过来的酒店编号    
            DataTable table = room.searchHotelRoomById(id);
            this.GridView1.DataSource = table;
            this.GridView1.DataBind();//数据绑定
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView1.SelectedIndex;//选中的数据行索引

            RoomType.Text = GridView1.Rows[index].Cells[2].Text;//客房类型
            Monetary.Text = GridView1.Rows[index].Cells[9].Text;//每晚价格

            Session["hotelRoomId"] = GridView1.Rows[index].Cells[0].Text;//酒店客房编号
            Session["singlePrice"]= GridView1.Rows[index].Cells[9].Text;//选择的客房每晚价格
            Session["vacantNum"] = GridView1.Rows[index].Cells[11].Text;//可预约数，即当前空房数量
        }

        //计算预订金额
        protected void Calculate(object sender, EventArgs e)
        {
            double price = Double.Parse(Session["singlePrice"].ToString());//选中的客房单价
            int number = Int32.Parse(OrderNumber.Text.Trim());//预订数量
            int duration= Int32.Parse(StayDuration.Text.Trim());//入住时长
            Monetary.Text = (number * duration * price).ToString();//预订总金额=入住时长*每晚价格
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            string id = Request["HotelId"];//接收来自酒店信息页面a链接传递过来的酒店编号    
            DataTable table = room.searchHotelRoomById(id);
            if (table != null && table.Rows.Count > 0)//当前表里有数据时
            {     
                if (RoomType.Text == "")//没有选择客房类型
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请选择您要预订的客房！');</script>");
                else
                {
                    int oldVacantNum = Int32.Parse(Session["vacantNum"].ToString());//原先空房数 
                    if (CheckInDate.Text == "")//没有选择入住日期
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请选择您要入住的日期！');</script>");
                    else if (Int32.Parse(OrderNumber.Text.Trim())<=0||Int32.Parse(OrderNumber.Text.Trim()) > oldVacantNum)//预订数量小等于0或预订数量大于空房数           
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('当前空房数无法满足您的需求！');</script>");
                    else if (Int32.Parse(StayDuration.Text.Trim()) <= 0)//入住时长小等于0          
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('入住时长需大于0!');</script>");
                    else
                    {
                        orderInfo d = new orderInfo();
                        DateTime date = Convert.ToDateTime(OrderDate.Text);//预订日期
                        d.OorderDate = date;
                        d.Uid = CardId.Text.Trim();//身份证号                  
                        d.Hid = Request["HotelId"];//接收来自在线订房页面a链接传递过来的酒店编号                    
                        d.Tid = room.searchRoomTypeId(RoomType.Text);//根据客房类型查询客房类型编号
                        d.Onumber = Int32.Parse(OrderNumber.Text.Trim());//预订数量
                        d.OcheckInDate = Convert.ToDateTime(CheckInDate.Text);//入住日期
                        d.OstayDuration = Int32.Parse(StayDuration.Text.Trim());//入住时长
                        d.Oprice = Double.Parse(Monetary.Text);//预订总金额

                        //订单编号设置为=身份证后四位+选择的酒店编号后三位+客房编号+预约的月日时分
                        String month = date.ToString("MM"); //取月
                        String day = date.Day.ToString(); //取日 
                        string hour = DateTime.Now.Hour.ToString(); //获取当前小时
                        string minute = DateTime.Now.Minute.ToString(); //获取当前分钟
                        string lastHotelId = d.Hid.Remove(0, d.Hid.Length - 3);//酒店编号后三位
                        string lastCardId = d.Uid.Remove(0, d.Uid.Length - 4);//客户身份证后四位
                        d.Oid =lastCardId + lastHotelId + d.Tid + month + day + hour + minute ;//订单编号

                        order.addOrderInfo(d);//增加订单记录
                        Response.Write("<script>alert('预订成功！');</script>");

                        int currentVacantNum = oldVacantNum - d.Onumber;//当前空房数=原先空房数-客户预订数量                
                        if (currentVacantNum > 0)//还有空房
                            room.updateVacantNum(currentVacantNum, Session["hotelRoomId"].ToString());//修改空房数             
                        else
                            room.deleteHotelRoomInfo(Session["hotelRoomId"].ToString());//删除该客房信息

                        RoomType.Text = "";
                        CheckInDate.Text = "";
                        OrderNumber.Text = "1";
                        StayDuration.Text = "1";
                        Monetary.Text = "";
                        InitGridView();//重新加载   
                        this.GridView1.SelectedIndex = -1;
                    }
                }               
            }
            else
               Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('当前没有酒店客房信息，无法预订！');</script>");
        }
    }
}
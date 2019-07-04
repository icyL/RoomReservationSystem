using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 网上订房系统.App_Code;

namespace 网上订房系统
{
    public partial class HotelInfo : System.Web.UI.Page
    {
        Hotel hotel = new Hotel();
        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteButton.Attributes["OnClick"] = "return confirm('删除这家酒店的信息将连同其客房信息一并删除，您确定删除吗?')";//给删除按钮点击事件添加删除确认框            
            DataTable table = hotel.searchHotelInfo();//查询到的所有酒店信息
            CreateElement(table);//动态加载html标签
        }

        //动态添加前端元素标签
        protected void CreateElement(DataTable table)
        {
            StringBuilder str = new StringBuilder(); //创建一个实例       
            if (table != null && table.Rows.Count > 0) //判断是否有数据
            {
                str.Append("<ul>");
                for (int i = 0; i < table.Rows.Count; i++) //将数据库表中的数据循环赋给str
                {
                    //将数据库表中值赋给新的变量
                    string id = table.Rows[i]["Hid"].ToString();//酒店编号，需要传值到酒店客房信息管理页面
                    Session["hotelId"] = id;//传到下方删除按钮事件中
                    string name = table.Rows[i]["Hname"].ToString();//酒店名称
                    string province = table.Rows[i]["Hprovince"].ToString();//所处省市
                    string price = table.Rows[i]["Hprice"].ToString();//价位
                    string imageUrl = table.Rows[i]["HimageUrl"].ToString();//酒店本地图片地址，需要传值到酒店客房信息管理页面

                    str.Append("<li>"); //li标签
                    str.Append("<a id='a" + i + "' runat = 'server' href='./RoomInfo.aspx?HotelId=" + id + "&HotelImgUrl=" + imageUrl + "'>"); //a标签,顺便将酒店编号进行带参传值到要跳转的页面
                    str.Append("<img id='image" + i + "' runat = 'server' alt='' src='../images/" + imageUrl + "' />"); //img标签
                    str.Append("<label id='label" + i + "' runat = 'server'>");//lable标签
                    str.Append(province + "&nbsp;&nbsp;" + name + "&nbsp;&nbsp;价位:" + price);//酒店简介
                    str.Append("</label > ");
                    str.Append("</a>");
                    str.Append("<br/>");
                    str.Append("<input id='button" + i + "' runat = 'server' type='button' value='删除' onclick='document.getElementById(\"DeleteButton\").click();'/> ");
                    str.Append("</li>");//可进行拼接
                }
                str.Append("</ul>");
                this.HotelsShow.Text = str.ToString(); //最终将str内容赋给前台的标签显示
            }
            else          
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('没有找到您要查询的酒店！');</script>");
        }

        //删除按钮的点击事件
        protected void Delete_Click(object sender, EventArgs e)
        {
           
            string id = Session["hotelId"].ToString();//接收上面传来的选中的酒店编号     
            hotel.deleteHotelInfo(id);//删除选中的酒店信息
            DataTable table = hotel.searchHotelInfo();//查询到的内容
            CreateElement(table);//重新动态加载html标签
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            string byprovince= SearchByProvince.Value.Trim();//酒店所在省市关键词
            string byname = SearchByName.Value.Trim();//酒店名称关键词
            if (byprovince != "" || byname != "")
            {
                DataTable table = hotel.searchHotelByKey(byprovince, byname);//根据酒店所在省市和名称模糊查询获取到的酒店信息
                CreateElement(table);//动态加载html标签                                   
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请输入关键词！');</script>");            
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            SearchByProvince.Value = "";
            SearchByName.Value = "";
        }
    }
}